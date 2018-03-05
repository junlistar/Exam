using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exam.Api.Models;
using Exam.Core.Infrastructure;
using Exam.IService;

namespace Exam.Api.Controllers
{
    /// <summary>
    /// 考试模块
    /// </summary>
    public class UserExamController : ApiController
    {
        private readonly IExamClassService _examClassService = EngineContext.Current.Resolve<IExamClassService>();

        private readonly IExamProblemService _examProblemService = EngineContext.Current.Resolve<IExamProblemService>();

        private readonly IUserExamClassService _userExamClassService = EngineContext.Current.Resolve<IUserExamClassService>();

        private readonly IUserExamProblemService _userExamProblemService = EngineContext.Current.Resolve<IUserExamProblemService>();

        private readonly IUserExamAnswerService _userExamAnswerService = EngineContext.Current.Resolve<IUserExamAnswerService>();

        /// <summary>
        /// 得到考试分类表
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetExamClassList(int BelongId = 0)
        {
            var list = _examClassService.GetExamClassList().Where(c => c.BelongId == BelongId);
            return Json(new { Success = true, Msg = "OK", Data = list });
        }

        /// <summary>
        /// 根据考试分类Id得到题目表
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetExamProblemList(int ExamClassId = 0)
        {
            var list = _examProblemService.GetAll().Where(c => c.ExamClassId == ExamClassId);

            List<ExamProblemVM> examProblemVMList = new List<ExamProblemVM>();

            if (list != null)
            {
                foreach (var item in list)
                {
                    ExamProblemVM model = new ExamProblemVM();
                    model.Analysis = model.Analysis;
                    model.ExamClass = model.ExamClass;
                    model.ExamClassId = model.ExamClassId;
                    model.ExamProblemId = model.ExamProblemId;
                    model.ProblemCategoryId = model.ProblemCategoryId;
                    model.Score = model.Score;
                    model.Sort = model.Sort;
                    model.Title = model.Title;
                    List<ExamAnswerVM> examAnswerVMList = new List<ExamAnswerVM>();

                    if (model.ExamAnswerList != null)
                    {
                        foreach (var cItem in model.ExamAnswerList)
                        {
                            examAnswerVMList.Add(new ExamAnswerVM
                            {
                                ExamAnswerId = cItem.ExamAnswerId,
                                IsCorrect = cItem.IsCorrect,
                                Title = cItem.Title
                            });
                        }

                    }
                    model.ExamAnswerList = examAnswerVMList;

                }
            }
            return Json(new { Success = true, Msg = "OK", Data = examProblemVMList });
        }

        /// <summary>
        /// 添加考试记录
        /// </summary>
        /// <param name="addUserExamDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult AddUserExam(AddUserExamDto addUserExamDto)
        {
            var examClassModel = _examClassService.GetById(addUserExamDto.ExamClassId);

            if (examClassModel != null)
            {
                var userExamClassModel = _userExamClassService.Insert(new Domain.Model.UserExamClass
                {
                    CreateTime = DateTime.Now,
                    EndTime = examClassModel.EndTime,
                    ExamClassId = examClassModel.ExamClassId,
                    IsExam = 1,//1是默认,2是后台审批过的
                    IsShow = 1,//1显示2不显示
                    Score = 0,
                    Sort = 1,
                    StartTime = examClassModel.StartTime,
                    Title = examClassModel.Title,
                    UserInfoId = addUserExamDto.UserInfoId
                });
                var examProblemList = _examProblemService.GetAll().Where(c => c.ExamClassId == addUserExamDto.ExamClassId);

                if (examProblemList != null)
                {
                    foreach (var examProblem in examProblemList)
                    {
                        var problemDto = (from a in addUserExamDto.AddExamProblemDtoList
                                          where a.ExamProblemId == examProblem.ExamProblemId
                                          select a).FirstOrDefault();
                        if (problemDto != null)
                        {
                            int ErrorAnswer = examProblem.ExamProblemId;
                            if (problemDto.ExamProblemId == examProblem.ExamProblemId)
                            {
                                ErrorAnswer = examProblem.ExamProblemId;
                            }
                            var answer = (from b in examProblem.ExamAnswerList
                                          where b.IsCorrect == 1
                                          select b).ToList();
                            string CorrectAnswer = string.Empty;
                            if (answer != null)
                            {
                                foreach (var a in answer)
                                {
                                    CorrectAnswer += a.ExamAnswerId + ",";
                                }
                                CorrectAnswer = CorrectAnswer.Substring(0, CorrectAnswer.Length - 1);
                            }
                            decimal examScore = 0;

                            if (CorrectAnswer == problemDto.ExamAnswerIds)
                            {
                                examScore = examProblem.Score;
                            }
                            var userExamAnswer = _userExamProblemService.Insert(new Domain.Model.UserExamProblem
                            {
                                CTime = DateTime.Now,
                                UTime = DateTime.Now,
                                Title = examProblem.Title,
                                CorrectAnswer = CorrectAnswer,
                                ErrorAnswer = problemDto.ExamAnswerIds,
                                ProblemCategoryId = examProblem.ProblemCategoryId,
                                UserExamClassId = examProblem.ExamClassId,
                                Analysis = examProblem.Analysis,
                                Sort = 1,
                                Score = examScore
                            });

                            foreach (var itemChild in examProblem.ExamAnswerList)
                            {
                                _userExamAnswerService.Insert(new Domain.Model.UserExamAnswer
                                {
                                    UserExamProblemId = userExamAnswer.UserExamProblemId,
                                    IsCorrect = itemChild.IsCorrect,
                                    Title = itemChild.Title,
                                });
                            }
                        }
                    }
                }
                return Json(new { Success = true, Msg = "OK", Data = "" });
            }
            else
            {
                return Json(new { Success = false, Msg = "考试不存在", Data = "" });
            }
        }

        /// <summary>
        /// 通过userinfoId得到考试记录
        /// </summary>
        /// <param name="UserInfoId"></param>
        /// <returns></returns>
        public IHttpActionResult GetUserExamList(int UserInfoId = 0)
        {
            var list = _userExamClassService.GetAll().Where(c => c.UserInfoId == UserInfoId);

            if (list != null)
            {
                List<UserExamClassVM> userExamClassList = new List<UserExamClassVM>();
                foreach (var item in list)
                {
                    List<UserExamProblemVM> userExamProblemList = new List<UserExamProblemVM>();
                    if (item.UserExamProblemList != null)
                    {
                        foreach (var userExamProblem in item.UserExamProblemList)
                        {
                            List<UserExamAnswerVM> UserExamAnswerList = new List<UserExamAnswerVM>();
                            if (userExamProblem.UserExamAnswerList != null)
                            {
                                foreach (var UserExamAnswer in userExamProblem.UserExamAnswerList)
                                {
                                    UserExamAnswerList.Add(new UserExamAnswerVM
                                    {
                                        UserExamAnswerId = UserExamAnswer.UserExamAnswerId,
                                        IsCorrect = UserExamAnswer.IsCorrect,
                                        Title = UserExamAnswer.Title,
                                        UserExamProblemId = UserExamAnswer.UserExamProblemId
                                    });
                                }

                            }
                            userExamProblemList.Add(new UserExamProblemVM
                            {
                                Analysis = userExamProblem.Analysis,
                                CorrectAnswer = userExamProblem.CorrectAnswer,
                                CTime = userExamProblem.CTime,
                                ErrorAnswer = userExamProblem.ErrorAnswer,
                                Score = userExamProblem.Score,
                                Sort = userExamProblem.Sort,
                                ProblemCategoryId = userExamProblem.ProblemCategoryId,
                                Title = userExamProblem.Title,
                                UserExamClassId = userExamProblem.UserExamClassId,
                                UserExamProblemId = userExamProblem.UserExamProblemId,
                                UTime = userExamProblem.UTime,
                                UserExamAnswerList= UserExamAnswerList
                            });
                        }
                    }
                    userExamClassList.Add(new UserExamClassVM
                    {
                        CreateTime = item.CreateTime,
                        EndTime = item.EndTime,
                        ExamClassId = item.ExamClassId,
                        IsExam = item.IsExam,
                        IsShow = item.IsShow,
                        Score = item.Score,
                        Sort = item.Sort,
                        StartTime = item.StartTime,
                        Title = item.Title,
                        UserExamClassId = item.UserExamClassId,
                        UserInfoId = item.UserInfoId,
                        UserExamProblemList = userExamProblemList
                    });

                }
                return Json(new { Success = true, Msg = "OK", Data = userExamClassList });
            }
            else
            {
                return Json(new { Success = false, Msg = "您还没有考试记录", Data = "" });
            }

        }
    }
}
