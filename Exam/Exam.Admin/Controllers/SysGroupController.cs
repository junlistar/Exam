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
    /// 用户分组
    /// </summary>
    public class SysGroupController : BaseController
    {
        // GET: SysGroup
        private readonly ISysGroupService _sysGroupService;
        public SysGroupController(ISysGroupService sysGroupService)
        {
            _sysGroupService = sysGroupService;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_sysGroupVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(SysGroupVM _sysGroupVM, int pn = 1)
        {
            int totalCount,
                pageIndex = (pn - 1) * PagingConfig.PAGE_SIZE,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _sysGroupService.GetManagerList(_sysGroupVM.QueryName, pageIndex, pageSize, out totalCount);
            var paging = new Paging<SysGroup>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _sysGroupVM.Paging = paging;
            return View(_sysGroupVM);
        }
      
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="_sysGroupVM"></param>
        /// <returns></returns>
        public ActionResult Edit(SysGroupVM _sysGroupVM)
        {
            _sysGroupVM.SysGroup = _sysGroupService.GetById(_sysGroupVM.Id) ?? new SysGroup(); 
            return View(_sysGroupVM);
        }
        /// <summary>
        /// 添加、修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Edit(SysGroup model)
        {
            try
            {
                if (model.SysGroupId > 0)
                {
                    var entity = _sysGroupService.GetById(model.SysGroupId);
                    //修改  
                    entity.UTime = DateTime.Now;
                    entity.Name = model.Name;
                    entity.SortNo = model.SortNo; 
                    _sysGroupService.Update(entity);
                }
                else
                {
                    if (_sysGroupService.IsExistName(model.Name))
                        return Json(new { Status = Successed.Repeat }, JsonRequestBehavior.AllowGet);
                    //添加
                    model.IsEnable = (int)EnumHelp.EnabledEnum.有效;
                    model.CTime = DateTime.Now;
                    model.UTime = DateTime.Now;

                    _sysGroupService.Insert(model);
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
                var entity = _sysGroupService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _sysGroupService.Delete(entity);

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
        public JsonResult UpdateStatus(int id = 0, Exam.Domain.EnumHelp.EnabledEnum isEnabled = EnumHelp.EnabledEnum.有效)
        {
            try
            {
                var entity = _sysGroupService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }
                entity.IsEnable = (int)isEnabled;
                _sysGroupService.Update(entity);
                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}