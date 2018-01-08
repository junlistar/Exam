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
    /// ProblemCategory菜单
    /// </summary>
    public class ProblemCategoryController : BaseController
    {
        // GET: ProblemCategory
        private readonly IProblemCategoryService _ProblemCategoryService;
        public ProblemCategoryController(IProblemCategoryService ProblemCategoryService)
        {
            _ProblemCategoryService = ProblemCategoryService;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_ProblemCategoryVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(ProblemCategoryVM _ProblemCategoryVM, int pn = 1)
        {
            int totalCount,
                pageIndex = pn,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _ProblemCategoryService.GetManagerList(_ProblemCategoryVM.QueryName, pageIndex, pageSize, out totalCount);
            var paging = new Paging<ProblemCategory>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _ProblemCategoryVM.Paging = paging;
            return View(_ProblemCategoryVM);
        }
        
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="_ProblemCategoryVM"></param>
        /// <returns></returns>
        public ActionResult Edit(ProblemCategoryVM _ProblemCategoryVM)
        {
            _ProblemCategoryVM.ProblemCategory = _ProblemCategoryService.GetById(_ProblemCategoryVM.Id) ?? new ProblemCategory(); 
            return View(_ProblemCategoryVM);
        }
        /// <summary>
        /// 添加、修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Edit(ProblemCategory model)
        {
            try
            {
                if (model.ProblemCategoryId > 0)
                {
                    var entity = _ProblemCategoryService.GetById(model.ProblemCategoryId);
                    //修改 
                    entity.ProblemCategoryId = model.ProblemCategoryId;
                    entity.Title = model.Title;
                    entity.UTime = DateTime.Now; 
                    entity.Sort= model.Sort; 
                    _ProblemCategoryService.Update(entity);
                }
                else
                {
                    if (_ProblemCategoryService.IsExistName(model.Title))
                        return Json(new { Status = Successed.Repeat }, JsonRequestBehavior.AllowGet);
                    //添加 
                    model.CTime = DateTime.Now;
                    model.UTime = DateTime.Now;

                    _ProblemCategoryService.Insert(model);
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
                var entity = _ProblemCategoryService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _ProblemCategoryService.Delete(entity);

                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
    
    }
}