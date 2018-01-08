using Exam.Admin.Models;
using Exam.Common;
using Exam.Core.Utils;
using Exam.Domain;
using Exam.Domain.Model;
using Exam.IService;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Exam.Admin.Controllers
{
    /// <summary>
    /// 角色菜单
    /// </summary>
    public class SysMenuController : BaseController
    {
        // GET: SysMenu
        private readonly ISysMenuService _sysMenuService;
        public SysMenuController(ISysMenuService sysMenuService)
        {
            _sysMenuService = sysMenuService;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_sysMenuVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(SysMenuVM _sysMenuVM, int pn = 1)
        {
            int totalCount,
                pageIndex = pn,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _sysMenuService.GetManagerList(_sysMenuVM.QueryName, pageIndex, pageSize, out totalCount);
            var paging = new Paging<SysMenu>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _sysMenuVM.Paging = paging;
            return View(_sysMenuVM);
        }
        /// <summary>
        /// 子菜单列表
        /// </summary>
        /// <param name="_sysMenuVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult ChildList(SysMenuVM _sysMenuVM, int pn = 1)
        {
            int totalCount,
                pageIndex = (pn - 1) * PagingConfig.PAGE_SIZE,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _sysMenuService.GetAll().Where(p => p.Fid == _sysMenuVM.Id).ToList();
            var paging = new Paging<SysMenu>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = 1,
                Index = pn,
            };
            _sysMenuVM.Paging = paging;
            return View(_sysMenuVM);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="_sysMenuVM"></param>
        /// <returns></returns>
        public ActionResult Edit(SysMenuVM _sysMenuVM)
        {
            _sysMenuVM.SysMenu = _sysMenuService.GetById(_sysMenuVM.Id) ?? new SysMenu();
            _sysMenuVM.SysMenus = _sysMenuService.GetAll().Where(p => p.Fid == 0).ToList();
            return View(_sysMenuVM);
        }
        /// <summary>
        /// 添加、修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Edit(SysMenu model)
        {
            try
            {
                if (model.SysMenuId > 0)
                {
                    var entity = _sysMenuService.GetById(model.SysMenuId);
                    //修改 
                    entity.Icon = model.Icon;
                    entity.UTime = DateTime.Now;
                    entity.Name = model.Name;
                    entity.SortNo = model.SortNo;
                    entity.Type = model.Type;
                    entity.Url = model.Url;
                    entity.Fid = model.Fid;
                    _sysMenuService.Update(entity);
                }
                else
                {
                    if (_sysMenuService.IsExistName(model.Name, model.Type))
                        return Json(new { Status = Successed.Repeat }, JsonRequestBehavior.AllowGet);
                    //添加
                    model.IsEnable = (int)EnumHelp.EnabledEnum.有效;
                    model.CTime = DateTime.Now;
                    model.UTime = DateTime.Now;

                    _sysMenuService.Insert(model);
                }
                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(int id = 0)
        {
            try
            {
                var entity = _sysMenuService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _sysMenuService.Delete(entity);

                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 状态修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateStatus(int id = 0, Exam.Domain.EnumHelp.EnabledEnum isEnabled =  EnumHelp.EnabledEnum.有效)
        {
            try
            {
                var entity = _sysMenuService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }
                entity.IsEnable = (int)isEnabled;
                _sysMenuService.Update(entity);
                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}