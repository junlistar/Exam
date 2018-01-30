﻿using Exam.Admin.Models;
using Exam.Common;
using Exam.Core.Utils;
using Exam.Domain;
using Exam.Domain.Model;
using Exam.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IProblemLibraryService _ProblemLibraryService;
        private readonly IAnswerService _AnswerService;

        public ProblemController(IProblemService ProblemService,
            IProblemCategoryService ProblemCategoryService,
            IBelongService BelongService,
            IChapterService ChapterService,
            IProblemLibraryService ProblemLibraryService,
            IAnswerService AnswerService)
        {
            _ProblemService = ProblemService;
            _ProblemCategoryService = ProblemCategoryService;
            _BelongService = BelongService;
            _ChapterService = ChapterService;
            _ProblemLibraryService = ProblemLibraryService;
            _AnswerService = AnswerService;
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
                    entity.Sort = model.Sort;
                    entity.UTime = DateTime.Now;
                    _ProblemService.Update(entity);
                }
                else
                {
                    if (_ProblemService.IsExistName(model.Title,model.ChapterId))
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

        /// <summary>
        /// 同步题库数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SyncProblemData(int id = 0)
        {
            try
            {
                Task.Run(() =>
                {
                    NewMethod();
                });


                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new
                {
                    Status = Successed.Error
                }, JsonRequestBehavior.AllowGet);
            }
        }

        private void NewMethod()
        {
            //获取题目类型
            var qtypelist = _ProblemCategoryService.GetAll().ToList();
            //章节列表
            var chapterlist = _ChapterService.GetAll().ToList();
            //题目类别（注会、初级、中级等）
            var belonglist = _BelongService.GetAll().ToList();


            //注会数据（临时表）
            var fromList = _ProblemLibraryService.GetAll().Where(p => p.BelongId == 1000).ToList();

            if (fromList != null && fromList.Count > 0)
            {
                foreach (var item in fromList)
                {
                    switch (item.c_qustiontype)
                    {
                        //目前只判断了单选和多选
                        case 4:
                        case 5:
                            Problem pitem = new Problem();
                            pitem.Title = item.Title;
                            pitem.Analysis = item.c_tips;
                            pitem.BelongId = item.BelongId;
                            if (!chapterlist.Any(p => p.Title == item.c_sctname))
                            {
                                //_ChapterService.Insert(new Chapter
                                //{
                                //    CTime = DateTime.Now,
                                //    Title = item.c_sctname,
                                //    Sort = 1,
                                //    UTime = DateTime.Now
                                //});
                                //chapterlist= _ChapterService.GetAll().ToList();
                                chapterlist.Add(_ChapterService.Insert(new Chapter
                                {
                                    CTime = DateTime.Now,
                                    Title = item.c_sctname,
                                    Sort = 1,
                                    UTime = DateTime.Now
                                }));
                            }
                            pitem.ChapterId = chapterlist.Where(p => p.Title == item.c_sctname).FirstOrDefault().ChapterId;
                            pitem.ProblemCategoryId = item.c_qustiontype == 4 ? 1000 : 1001;  //等于4 单选，等于5 多选 
                            pitem.Score = decimal.Parse(item.c_score);
                            pitem.Sort = 1;
                            pitem.IsHot = 0;
                            pitem.CTime = DateTime.Now;
                            pitem.UTime = DateTime.Now;

                            //写入题目
                            if (!_ProblemService.IsExistName(pitem.Title, pitem.ChapterId))
                            {
                                var returnProblemModel = _ProblemService.Insert(pitem);

                                var _options = item.c_options;
                                var _answer = item.c_answer;

                                if (!string.IsNullOrWhiteSpace(_answer))
                                {
                                    var _correctlist = _answer.Split('|');
                                    var _optionlist = _options.Split('|');
                                    for (int i = 0; i < _optionlist.Length; i++)
                                    {
                                        Answer _answermodel = new Answer();
                                        _answermodel.ProblemId = returnProblemModel.ProblemId;
                                        _answermodel.Title = _optionlist[i];
                                        _answermodel.IsCorrect = _correctlist.Contains((i + 1).ToString()) ? 1 : 0;
                                        //添加答案
                                        _AnswerService.Insert(_answermodel);
                                    }
                                }
                            }

                            //更新标识状态
                            item.IsUse = 1;
                            _ProblemLibraryService.Update(item);


                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}