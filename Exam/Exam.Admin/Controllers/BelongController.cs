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
    /// Belong菜单
    /// </summary>
    public class BelongController : BaseController
    {
        // GET: Belong
        private readonly IBelongService _BelongService;
        public BelongController(IBelongService BelongService)
        {
            _BelongService = BelongService;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_BelongVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(BelongVM _BelongVM, int pn = 1)
        {
            int totalCount,
                pageIndex = (pn - 1) * PagingConfig.PAGE_SIZE,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _BelongService.GetManagerList(_BelongVM.QueryName, pageIndex, pageSize, out totalCount);
            var paging = new Paging<Belong>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _BelongVM.Paging = paging;
            return View(_BelongVM);
        }
        
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="_BelongVM"></param>
        /// <returns></returns>
        public ActionResult Edit(BelongVM _BelongVM)
        {
            _BelongVM.Belong = _BelongService.GetById(_BelongVM.Id) ?? new Belong(); 
            return View(_BelongVM);
        }
        /// <summary>
        /// 添加、修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Edit(Belong model)
        {
            try
            {
                if (model.BelongId > 0)
                {
                    var entity = _BelongService.GetById(model.BelongId);
                    //修改 
                    entity.BelongId = model.BelongId;
                    entity.Title = model.Title;
                    entity.UTime = model.UTime; 
                    entity.Sort= model.Sort; 
                    _BelongService.Update(entity);
                }
                else
                {
                    if (_BelongService.IsExistName(model.Title))
                        return Json(new { Status = Successed.Repeat }, JsonRequestBehavior.AllowGet);
                    //添加 
                    model.CTime = DateTime.Now;
                    model.UTime = model.UTime;

                    _BelongService.Insert(model);
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
                var entity = _BelongService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _BelongService.Delete(entity);

                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
    
    }
}