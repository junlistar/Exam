﻿using Exam.Admin.Models;
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
    /// Problem菜单
    /// </summary>
    public class ProblemController : BaseController
    {
        // GET: Problem
        private readonly IProblemService _ProblemService;
        private readonly IProblemCategoryService _ProblemCategoryService;
        private readonly IBelongService _BelongService;
        private readonly IChapterService _ChapterService;

        public ProblemController(IProblemService ProblemService,
            IProblemCategoryService ProblemCategoryService,
            IBelongService BelongService,
            IChapterService ChapterService)
        {
            _ProblemService = ProblemService;
            _ProblemCategoryService = ProblemCategoryService;
            _BelongService = BelongService;
            _ChapterService = ChapterService;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_ProblemVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(ProblemVM _ProblemVM, int pn = 1)
        {
            int totalCount,
                pageIndex = pn,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _ProblemService.GetManagerList(_ProblemVM.QueryName, pageIndex, pageSize, out totalCount);
            var paging = new Paging<Problem>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _ProblemVM.Paging = paging;
            return View(_ProblemVM);
        }
        
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="_ProblemVM"></param>
        /// <returns></returns>
        public ActionResult Edit(ProblemVM _ProblemVM)
        {
            _ProblemVM.Problem = _ProblemService.GetById(_ProblemVM.Id) ?? new Problem();

            _ProblemVM.ProblemCategorys = _ProblemCategoryService.GetAll();
            _ProblemVM.Belongs = _BelongService.GetAll();
            _ProblemVM.Chapters = _ChapterService.GetAll();

            return View(_ProblemVM);
        }
        /// <summary>
        /// 添加、修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Edit(Problem model)
        {
            try
            {
                if (model.ProblemId > 0)
                {
                    var entity = _ProblemService.GetById(model.ProblemId);
                    //修改 
                    entity.ChapterId = model.ChapterId;
                    entity.IsHot = model.IsHot;
                    entity.ProblemCategoryId = model.ProblemCategoryId;
                    entity.Title = model.Title;
                    entity.BelongId = model.BelongId;
                    entity.Sort= model.Sort; 
                    entity.UTime= DateTime.Now; 
                    _ProblemService.Update(entity);
                }
                else
                {
                    if (_ProblemService.IsExistName(model.Title))
                        return Json(new { Status = Successed.Repeat }, JsonRequestBehavior.AllowGet);
                    //添加 
                    model.CTime = DateTime.Now;
                    model.UTime = DateTime.Now;

                    _ProblemService.Insert(model);
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
                var entity = _ProblemService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _ProblemService.Delete(entity);

                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 答案列表
        /// </summary> 
        /// <returns></returns>
        public ActionResult AnswerList(ProblemVM _ProblemVM)
        { 

            var entity = _ProblemService.GetById(_ProblemVM.Id);

            _ProblemVM.AnswerList = entity.AnswerList; 
            _ProblemVM.Title = entity.Title;

            return View(_ProblemVM);
        }
    }
}