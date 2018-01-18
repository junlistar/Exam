using System;
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
        private readonly IProblemService problemService = EngineContext.Current.Resolve<IProblemService>();

        private readonly IBelongService belongService = EngineContext.Current.Resolve<IBelongService>();

        private readonly IChapterService chapterService = EngineContext.Current.Resolve<IChapterService>();

        private readonly IUserInfoAnswerRecordService userInfoAnswerRecordService = EngineContext.Current.Resolve<IUserInfoAnswerRecordService>();

        private readonly IProblemRecordService problemRecordService = EngineContext.Current.Resolve<IProblemRecordService>();

        private readonly IAnswerRecordService answerRecordService = EngineContext.Current.Resolve<IAnswerRecordService>();


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
            return Json(new { Success = true, Msg = "OK", Data = belongService.GetAll() });
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
                //ProblemVM
                var problemList = problemService.GetProblemList(SelctProblemVM.belongId, SelctProblemVM.ChapterId);

                List<ProblemVM> problemVMlist = new List<ProblemVM>();
                foreach (var result in problemList)
                {
                    ProblemVM problem = new ProblemVM();
                    problem.ProblemId = result.ProblemId;
                    problem.Title = result.Title;
                    problem.ProblemCategoryId = result.ProblemCategoryId;
                    problem.ProblemCategory = result.ProblemCategory;

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
            var userInfoAnswerRecord = userInfoAnswerRecordService.Insert(new Domain.Model.UserInfoAnswerRecord
            {
                BelongId = addUserInfoAnswerRecordDto.BelongId,
                ChapterId = addUserInfoAnswerRecordDto.ChapterId,
                Score = 0,
                CTime = DateTime.Now,
                UTime = DateTime.Now,
                UserInfoId = addUserInfoAnswerRecordDto.UserInfoId,
                Title = title
            });
            var problemlist = problemService.GetProblemList(addUserInfoAnswerRecordDto.BelongId, addUserInfoAnswerRecordDto.ChapterId);

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
                    CorrectAnswer = CorrectAnswer.Substring(0, CorrectAnswer.Length - 1);
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
                    });

                    foreach (var itemChild in item.AnswerRecordList)
                    {
                        var Answer = (from n in problem.AnswerList
                                      where n.AnswerId == itemChild.AnswerId
                                      select n).FirstOrDefault();
                        answerRecordService.Insert(new Domain.Model.AnswerRecord
                        {
                            AnswerId = itemChild.AnswerId,
                            ProblemId = problem.ProblemId,
                            IsCorrect = Answer.IsCorrect,
                            ProblemRecordId = problemRecord.ProblemRecordId,
                            Title = Answer.Title
                        });
                    }
                }
            }
            return Json(new { Success = true, Msg = "OK", Data = userInfoAnswerRecord });
        }

        /// <summary>
        /// 获取答题记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetUserInfoAnswerRecord(SelUserInfoAnswerRecordDto selUserInfoAnswerRecordDto)
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
        /// <returns></returns>
        public IHttpActionResult GetProblemRecord(int UserInfoAnswerRecordId = 0)
        {
            var problemRecordList = problemRecordService.GetForUserInfoRecordId(UserInfoAnswerRecordId);

            List<ProblemRecordVM> problemRecordVMlist = new List<ProblemRecordVM>();
            foreach (var result in problemRecordList)
            {
                ProblemRecordVM problem = new ProblemRecordVM();
                problem.ProblemRecordId = result.ProblemRecordId;
                problem.Title = result.Title;
                problem.ProblemCategoryId = result.ProblemCategoryId;
                problem.ProblemCategory = result.ProblemCategory;

                List<AnswerRecordVM> childList = new List<AnswerRecordVM>();
                foreach (var item in result.AnswerRecordList)
                {

                    childList.Add(new AnswerRecordVM
                    {
                        ProblemRecordId = item.ProblemRecordId,
                        IsCorrect = item.IsCorrect,
                        Title = item.Title,
                        AnswerRecordId = item.AnswerRecordId

                    });
                }
                problem.AnswerRecordList = childList;
                problemRecordVMlist.Add(problem);
            }

            return Json(new { Success = true, Msg = "OK", Data = problemRecordVMlist });
        }

    }
}
