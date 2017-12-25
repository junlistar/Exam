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
    public class NewsCategoryController : BaseController
    {
        // GET: NewsCategory
        private readonly INewsCategoryService _newsCategoryService;
        public NewsCategoryController(INewsCategoryService NewsCategoryService)
        {
            _newsCategoryService = NewsCategoryService;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_NewsCategoryVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(NewsCategoryVM _NewsCategoryVM, int pn = 1)
        {
            int totalCount,
                pageIndex = (pn - 1) * PagingConfig.PAGE_SIZE,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _newsCategoryService.GetManagerList(_NewsCategoryVM.QueryName, pageIndex, pageSize, out totalCount);
            var paging = new Paging<NewsCategory>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _NewsCategoryVM.Paging = paging;
            return View(_NewsCategoryVM);
        }
      
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="_NewsCategoryVM"></param>
        /// <returns></returns>
        public ActionResult Edit(NewsCategoryVM _NewsCategoryVM)
        {
            _NewsCategoryVM.NewsCategory = _newsCategoryService.GetById(_NewsCategoryVM.Id) ?? new NewsCategory(); 
            return View(_NewsCategoryVM);
        }
        /// <summary>
        /// 添加、修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Edit(NewsCategory model)
        {
            try
            {
                if (model.NewsCategoryId > 0)
                {
                    var entity = _newsCategoryService.GetById(model.NewsCategoryId);
                    //修改  
                    entity.UTime = DateTime.Now;
                    entity.Title = model.Title;
                    entity.Sort = model.Sort; 
                    _newsCategoryService.Update(entity);
                }
                else
                {
                    if (_newsCategoryService.IsExistName(model.Title))
                        return Json(new { Status = Successed.Repeat }, JsonRequestBehavior.AllowGet);
                    //添加 
                    model.CTime = DateTime.Now;
                    model.UTime = DateTime.Now;

                    _newsCategoryService.Insert(model);
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
                var entity = _newsCategoryService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _newsCategoryService.Delete(entity);

                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        } 
    }
}