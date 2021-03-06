﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exam.Api.Models;
using Exam.Core.Infrastructure;
using Exam.Domain.Model;
using Exam.IService;

namespace Exam.Api.Controllers
{
    /// <summary>
    /// 问题模块
    /// </summary>
    public class ProblemApiController : ApiController
    {
        //方式2

        private readonly IUserInfoAnswerRecordService userInfoAnswerRecordService = EngineContext.Current.Resolve<IUserInfoAnswerRecordService>();

        private readonly IProblemService problemService = EngineContext.Current.Resolve<IProblemService>();

        private readonly IBelongService belongService = EngineContext.Current.Resolve<IBelongService>();

        private readonly IChapterService chapterService = EngineContext.Current.Resolve<IChapterService>();



        private readonly IProblemRecordService problemRecordService = EngineContext.Current.Resolve<IProblemRecordService>();

        private readonly IAnswerRecordService answerRecordService = EngineContext.Current.Resolve<IAnswerRecordService>();

        private readonly IProblemCollectService problemCollectService = EngineContext.Current.Resolve<IProblemCollectService>();

        private readonly ISubjectInfoService subjectInfoService = EngineContext.Current.Resolve<ISubjectInfoService>();

        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetbelongList()
        {
            return Json(new { Success = true, Msg = "OK", Data = belongService.GetAll() });
        }

        /// <summary>
        /// 获取章节列表
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetchapterList()
        {
            return Json(new { Success = true, Msg = "OK", Data = chapterService.GetAll() });
        }

        /// <summary>
        /// 根据分类id获取科目列表
        /// </summary>
        /// <param name="BelongId"></param>
        /// <returns></returns>
        public IHttpActionResult GetSubjectInfoList(int BelongId = 0)
        {
            var list = subjectInfoService.GetSubjectInfoList(BelongId);
            List<SubjectInfoVM> subjectInfoList = new List<SubjectInfoVM>();
            if (list != null)
            {
                foreach (var item in list)
                {
                    SubjectInfoVM model = new SubjectInfoVM();
                    model.BelongId = item.BelongId;
                    model.Sort = item.Sort;
                    model.SubjectInfoId = item.SubjectInfoId;
                    model.Title = item.Title;

                    List<ChapterVM> childChapter = new List<ChapterVM>();
                    if (item.ChapterList != null)
                    {
                        List<Chapter> stuList = (from s in item.ChapterList orderby s.ChapterId select s).ToList<Chapter>();
                        foreach (var childItem in stuList)
                        {
                            childChapter.Add(new ChapterVM
                            {
                                ChapterId = childItem.ChapterId,
                                Sort = childItem.Sort,
                                Title = childItem.Title
                            });
                        }
                    }
                    model.ChapterList = childChapter;
                    subjectInfoList.Add(model);
                }
            }
            return Json(new { Success = true, Msg = "OK", Data = subjectInfoList });
        }

        /// <summary>
        /// 获取题目列表
        /// </summary>
        /// <param name="SelctProblemVM"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetProblemList([FromUri]SelctProblemVM SelctProblemVM)
        {
            if (SelctProblemVM != null)
            {
                int count = 0;
                var problemCollectList = problemCollectService.GetProblemCollectList(SelctProblemVM.UserInfoId, 1, 10000, out count);
                //ProblemVM
                var problemList = problemService.GetProblemList(SelctProblemVM.belongId, SelctProblemVM.ChapterId, SelctProblemVM.SubjectInfoId);

                List<ProblemVM> problemVMlist = new List<ProblemVM>();
                foreach (var result in problemList)
                {
                    int IsCollect = 0;
                    if (problemCollectList != null && problemCollectList.Count > 0)
                    {
                        var problemCollect = (from a in problemCollectList
                                              where a.ProblemId == result.ProblemId
                                              select a).FirstOrDefault();
                        if (problemCollect != null)
                        {
                            IsCollect = 1;
                        }
                    }
                    ProblemVM problem = new ProblemVM();
                    problem.ProblemId = result.ProblemId;
                    problem.Title = result.Title;
                    problem.ProblemCategoryId = result.ProblemCategoryId;
                    problem.ProblemCategory = result.ProblemCategory;
                    problem.Analysis = result.Analysis;
                    ChapterVM chapterVM = new ChapterVM();

                    if (result.Chapter != null)
                    {
                        chapterVM.ChapterId = result.Chapter.ChapterId;
                        chapterVM.Title = result.Chapter.Title;
                        chapterVM.Sort = result.Chapter.Sort;
                    }
                    problem.Chapter = chapterVM;
                    problem.IsCollect = IsCollect;
                    List<AnswerVM> childList = new List<AnswerVM>();
                    if (result.AnswerList != null)
                    {
                        foreach (var item in result.AnswerList)
                        {

                            childList.Add(new AnswerVM
                            {
                                AnswerId = item.AnswerId,
                                ProblemId = item.ProblemId,
                                IsCorrect = item.IsCorrect,
                                Title = item.Title
                            });
                        }
                    }
                    problem.AnswerList = childList;
                    problemVMlist.Add(problem);
                }
                return Json(new { Success = true, Msg = "OK", Data = problemVMlist });
            }
            else
            {
                return Json(new { Success = false, Msg = "参数不对", Data = "" });
            }
        }
        /// <summary>
        /// 获取题目和用户答题记录
        /// </summary>
        /// <param name="SelctProblemVM">用户编号，章节编号必填</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetProblemAndRecord([FromUri]SelctProblemVM SelctProblemVM)
        {
            if (SelctProblemVM != null)
            {
                int count = 0;
                var problemCollectList = problemCollectService.GetProblemCollectList(SelctProblemVM.UserInfoId, 1, 10000, out count);
                //ProblemVM
                var problemList = problemService.GetProblemList(SelctProblemVM.belongId, SelctProblemVM.ChapterId, SelctProblemVM.SubjectInfoId);

                List<ProblemVM> problemVMlist = new List<ProblemVM>();
                foreach (var result in problemList)
                {
                    int IsCollect = 0;
                    if (problemCollectList != null && problemCollectList.Count > 0)
                    {
                        var problemCollect = (from a in problemCollectList
                                              where a.ProblemId == result.ProblemId
                                              select a).FirstOrDefault();
                        if (problemCollect != null)
                        {
                            IsCollect = 1;
                        }
                    }
                    ProblemVM problem = new ProblemVM();
                    problem.ProblemId = result.ProblemId;
                    problem.Title = result.Title;
                    problem.ProblemCategoryId = result.ProblemCategoryId;
                    problem.ProblemCategory = result.ProblemCategory;
                    problem.Analysis = result.Analysis;
                    ChapterVM chapterVM = new ChapterVM();

                    if (result.Chapter != null)
                    {
                        chapterVM.ChapterId = result.Chapter.ChapterId;
                        chapterVM.Title = result.Chapter.Title;
                        chapterVM.Sort = result.Chapter.Sort;
                    }
                    problem.Chapter = chapterVM;
                    problem.IsCollect = IsCollect;
                    List<AnswerVM> childList = new List<AnswerVM>();
                    if (result.AnswerList != null)
                    {
                        foreach (var item in result.AnswerList)
                        {

                            childList.Add(new AnswerVM
                            {
                                AnswerId = item.AnswerId,
                                ProblemId = item.ProblemId,
                                IsCorrect = item.IsCorrect,
                                Title = item.Title
                            });
                        }
                    }
                    problem.AnswerList = childList;
                    problemVMlist.Add(problem);
                }
                //获取用户此分类的答题记录
                var answerRecordModel = userInfoAnswerRecordService.GetUserLastRecord(SelctProblemVM.ChapterId, SelctProblemVM.UserInfoId);
                LastAnswerRecordVM lar = new LastAnswerRecordVM();
                //获取答题记录详细
                if (answerRecordModel != null)
                {
                    var uifa = new UserInfoAnswerVM();
                    uifa.ChapterId = answerRecordModel.ChapterId;
                    uifa.UserInfoAnswerRecordId = answerRecordModel.UserInfoAnswerRecordId;
                    uifa.UserInfoId = answerRecordModel.UserInfoId;
                    uifa.CTime = answerRecordModel.CTime;
                    uifa.UTime = answerRecordModel.UTime;
                    //通过编号获取详细
                    var problemRecordList = problemRecordService.GetForUserInfoRecordId(answerRecordModel.UserInfoAnswerRecordId);
                    var prList = new List<ProblemRecordVM>();
                    foreach (ProblemRecord item in problemRecordList)
                    {
                        prList.Add(new ProblemRecordVM()
                        {
                            ProblemId = item.ProblemId,
                            ProblemRecordId = item.ProblemRecordId,
                            CorrectAnswer = item.CorrectAnswer,
                            ErrorAnswer = item.ErrorAnswer,
                            YesOrNo = item.YesOrNo,
                        });
                    }
                    lar.problemsRecord = prList;
                    lar.userInfoAnswerRecord = uifa;
                }
                ProblemAndRecord par = new ProblemAndRecord();
                par.problemsvm = problemVMlist;
                par.lastAnswervm = lar;
                return Json(new { Success = true, Msg = "OK", Data = par });
            }
            else
            {
                return Json(new { Success = false, Msg = "参数不对", Data = "" });
            }
        }


        /// <summary>
        /// 添加答题记录
        /// </summary>
        /// <param name="addUserInfoAnswerRecordDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult AddUserInfoAnswerRecord(AddUserInfoAnswerRecordDto addUserInfoAnswerRecordDto)
        {
            var belong = belongService.GetById(addUserInfoAnswerRecordDto.BelongId);
            var chapter = chapterService.GetById(addUserInfoAnswerRecordDto.ChapterId);
            string title = (belong != null ? belong.Title : "") + "-" + (chapter != null ? chapter.Title : "");
            var userInfoAnswerRecord = userInfoAnswerRecordService.GetById(addUserInfoAnswerRecordDto.UserInfoAnswerRecordId);
            if (userInfoAnswerRecord == null)
            {
                userInfoAnswerRecord = new UserInfoAnswerRecord();
                userInfoAnswerRecord = userInfoAnswerRecordService.Insert(new Domain.Model.UserInfoAnswerRecord
                {
                    BelongId = addUserInfoAnswerRecordDto.BelongId,
                    ChapterId = addUserInfoAnswerRecordDto.ChapterId,
                    Score = 0,
                    CTime = DateTime.Now,
                    UTime = DateTime.Now,
                    UserInfoId = addUserInfoAnswerRecordDto.UserInfoId,
                    Title = title
                });
            }
            var problemlist = problemService.GetProblemList(addUserInfoAnswerRecordDto.BelongId, addUserInfoAnswerRecordDto.ChapterId, addUserInfoAnswerRecordDto.SubjectInfoId);

            foreach (var item in addUserInfoAnswerRecordDto.AddProblemRecordDto)
            {
                var problem = (from a in problemlist
                               where a.ProblemId == item.ProblemId
                               select a).FirstOrDefault();

                if (problem != null)
                {
                    int ErrorAnswer = item.ProblemId;
                    if (problem.ProblemId == item.ProblemId)
                    {
                        ErrorAnswer = problem.ProblemId;
                    }
                    var answer = (from b in problem.AnswerList
                                  where b.IsCorrect == 1
                                  select b).ToList();

                    string CorrectAnswer = string.Empty;
                    foreach (var a in answer)
                    {
                        CorrectAnswer += a.AnswerId + ",";
                    }
                    if (CorrectAnswer.Length > 0)
                    {
                        CorrectAnswer = CorrectAnswer.Substring(0, CorrectAnswer.Length - 1);
                    }
                    var problemRecord = problemRecordService.Insert(new Domain.Model.ProblemRecord
                    {
                        CTime = DateTime.Now,
                        UTime = DateTime.Now,
                        Title = problem.Title,
                        CorrectAnswer = CorrectAnswer,
                        ErrorAnswer = item.AnswerIds,
                        ProblemCategoryId = problem.ProblemCategoryId,
                        ProblemId = item.ProblemId,
                        UserInfoAnswerRecordId = userInfoAnswerRecord.UserInfoAnswerRecordId,
                        Analysis = problem.Analysis,
                        YesOrNo = item.YesOrNo,
                        UserInfoId = addUserInfoAnswerRecordDto.UserInfoId
                    });

                    foreach (var itemChild in problem.AnswerList)
                    {
                        answerRecordService.Insert(new Domain.Model.AnswerRecord
                        {
                            AnswerId = itemChild.AnswerId,
                            ProblemId = problem.ProblemId,
                            IsCorrect = itemChild.IsCorrect,
                            ProblemRecordId = problemRecord.ProblemRecordId,
                            Title = itemChild.Title
                        });
                    }
                }
            }
            return Json(new { Success = true, Msg = "OK", Data = "" });
        }

        /// <summary>
        /// 获取答题记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetUserInfoAnswerRecord([FromUri]SelUserInfoAnswerRecordDto selUserInfoAnswerRecordDto)
        {
            ResultJson<UserInfoAnswerRecord> list = new ResultJson<UserInfoAnswerRecord>();
            int count = 0;
            list.Data = userInfoAnswerRecordService.GetListForUserInfoId(selUserInfoAnswerRecordDto.UserInfoId, selUserInfoAnswerRecordDto.PageIndex, selUserInfoAnswerRecordDto.PageSize, out count);
            list.RCount = count;
            list.PCount = count % selUserInfoAnswerRecordDto.PageSize == 0 ? (count / selUserInfoAnswerRecordDto.PageSize) : (count / selUserInfoAnswerRecordDto.PageSize + 1);//(count + pageDto.PageIndex - 1) / pageDto.PageSize;

            return Json(new { Success = true, Msg = "OK", Data = list });
        }

        /// <summary>
        /// 根据答题记录id获取答题
        /// </summary>
        /// <param name="UserInfoAnswerRecordId"></param>
        /// <param name="UserInfoId"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetProblemRecord(int UserInfoAnswerRecordId = 0, int UserInfoId = 0)
        {
            //var problemRecordList = problemRecordService.GetForUserInfoRecordId(UserInfoAnswerRecordId);

            //int count = 0;
            //var problemCollectList = problemCollectService.GetProblemCollectList(UserInfoId, 1, 10000, out count);

            //List<ProblemRecordVM> problemRecordVMlist = new List<ProblemRecordVM>();
            //foreach (var result in problemRecordList)
            //{
            //    int IsCollect = 0;
            //    if (problemCollectList != null && problemCollectList.Count > 0)
            //    {
            //        var problemCollect = (from a in problemCollectList
            //                              where a.ProblemId == result.ProblemId
            //                              select a).FirstOrDefault();
            //        if (problemCollect != null)
            //        {
            //            IsCollect = 1;
            //        }
            //    }
            //    ProblemRecordVM problem = new ProblemRecordVM();
            //    problem.ProblemRecordId = result.ProblemRecordId;
            //    problem.Title = result.Title;
            //    problem.ProblemCategoryId = result.ProblemCategoryId;
            //    problem.ProblemCategory = result.ProblemCategory;
            //    problem.Analysis = result.Analysis;
            //    problem.IsCollect = IsCollect;

            //    List<AnswerRecordVM> childList = new List<AnswerRecordVM>();
            //    foreach (var item in result.AnswerRecordList)
            //    {

            //        childList.Add(new AnswerRecordVM
            //        {
            //            ProblemRecordId = item.ProblemRecordId,
            //            IsCorrect = item.IsCorrect,
            //            Title = item.Title,
            //            AnswerRecordId = item.AnswerRecordId

            //        });
            //    }
            //    problem.AnswerRecordList = childList;
            //    problemRecordVMlist.Add(problem);
            //}

            return Json(new { Success = true, Msg = "OK", Data = "" });
        }

        /// <summary>
        /// 根据级别获取必刷的题目
        /// </summary>
        /// <param name="belongId">注会 1000 整数的</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetIntensive([FromUri]int belongId = 0)
        {
            if (belongId != 0)
            {
                var problemlist = problemService.GetIntensive(belongId);

                List<ProblemVM> problemVMlist = new List<ProblemVM>();
                foreach (var result in problemlist)
                {
                    int IsCollect = 0;

                    ProblemVM problem = new ProblemVM();
                    problem.ProblemId = result.ProblemId;
                    problem.Title = result.Title;
                    problem.ProblemCategoryId = result.ProblemCategoryId;
                    problem.ProblemCategory = result.ProblemCategory;
                    problem.Analysis = result.Analysis;
                    problem.IsCollect = IsCollect;
                    List<AnswerVM> childList = new List<AnswerVM>();
                    foreach (var item in result.AnswerList)
                    {

                        childList.Add(new AnswerVM
                        {
                            AnswerId = item.AnswerId,
                            ProblemId = item.ProblemId,
                            IsCorrect = item.IsCorrect,
                            Title = item.Title
                        });
                    }
                    problem.AnswerList = childList;
                    problemVMlist.Add(problem);
                }
                return Json(new { Success = true, Msg = "OK", Data = problemVMlist });
            }
            else
            {
                return Json(new { Success = false, Msg = "请输入对应的级别", Data = "" });
            }
        }

    }
}
