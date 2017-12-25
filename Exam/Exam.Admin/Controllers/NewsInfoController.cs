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
    public class NewsInfoController : BaseController
    {
        // GET: NewsInfo
        private readonly INewsInfoService _NewsInfoService;
        public NewsInfoController(INewsInfoService NewsInfoService)
        {
            _NewsInfoService = NewsInfoService;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_NewsInfoVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(NewsInfoVM _NewsInfoVM, int pn = 1)
        {
            int totalCount,
                pageIndex = (pn - 1) * PagingConfig.PAGE_SIZE,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _NewsInfoService.GetManagerList(_NewsInfoVM.QueryName, pageIndex, pageSize, out totalCount);
            var paging = new Paging<NewsInfo>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _NewsInfoVM.Paging = paging;
            return View(_NewsInfoVM);
        }
      
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="_NewsInfoVM"></param>
        /// <returns></returns>
        public ActionResult Edit(NewsInfoVM _NewsInfoVM)
        {
            _NewsInfoVM.NewsInfo = _NewsInfoService.GetById(_NewsInfoVM.Id) ?? new NewsInfo(); 
            return View(_NewsInfoVM);
        }
        /// <summary>
        /// 添加、修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Edit(NewsInfo model)
        {
            try
            {
                if (model.NewsInfoId > 0)
                {
                    var entity = _NewsInfoService.GetById(model.NewsInfoId);
                    //修改  
                    entity.UTime = DateTime.Now;
                    entity.Title = model.Title;
                    entity.Sort = model.Sort; 
                    _NewsInfoService.Update(entity);
                }
                else
                {
                    if (_NewsInfoService.IsExistName(model.Title))
                        return Json(new { Status = Successed.Repeat }, JsonRequestBehavior.AllowGet);
                    //添加 
                    model.CTime = DateTime.Now;
                    model.UTime = DateTime.Now;

                    _NewsInfoService.Insert(model);
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
                var entity = _NewsInfoService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _NewsInfoService.Delete(entity);

                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        } 
    }
}