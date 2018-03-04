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
    public class QuestionApiController : ApiController
    {
        private readonly IQuestionService _questionService = EngineContext.Current.Resolve<IQuestionService>();
        //
        private readonly IReplyService _replyService = EngineContext.Current.Resolve<IReplyService>();
        /// <summary>
        /// 新增提问接口
        /// </summary>
        /// <param name="addQuestionDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult AddQuestion(AddQuestionDto addQuestionDto)
        {
            if (string.IsNullOrWhiteSpace(addQuestionDto.Title))
            {
                return Json(new { Success = false, Msg = "标题不能为空！", Data = "" });
            }
            if (string.IsNullOrWhiteSpace(addQuestionDto.Content))
            {
                return Json(new { Success = false, Msg = "内容不能为空！", Data = "" });
            }
            if (addQuestionDto.UserInfoId == 0)
            {
                return Json(new { Success = false, Msg = "用户不能为空！", Data = "" });
            }

            var model = _questionService.Insert(new Domain.Model.Question
            {
                Content = addQuestionDto.Content,
                Sort = 0,
                CTime = DateTime.Now,
                IsHot = 0,
                IsTop = 0,
                Reads = 0,
                Title = addQuestionDto.Title,
                UserInfoId = addQuestionDto.UserInfoId,
                IsEnable = 1
            });
            return Json(new { Success = true, Msg = "OK", Data = model });
        }

        /// <summary>
        /// 新增回答接口
        /// </summary>
        /// <param name="addReplyDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult AddReply([FromUri]AddReplyDto addReplyDto)
        {
            var model = _replyService.Insert(new Domain.Model.Reply
            {
                Content = addReplyDto.Content,
                Sort = 0,
                CTime = DateTime.Now,
                Reads = 0,
                QuestionId = addReplyDto.QuestionId,
                UserInfoId = addReplyDto.UserInfoId
            });
            return Json(new { Success = true, Msg = "OK", Data = model });
        }

        /// <summary>
        /// 查询问题列表
        /// </summary>
        /// <param name="slQuestionVM"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetQuestionList([FromUri]SlQuestionVM slQuestionVM)
        {
            ResultJson<Question> list = new ResultJson<Question>();
            int count = 0;
            list.Data = _questionService.GetQuestionList(slQuestionVM.Title, slQuestionVM.IsTop, slQuestionVM.IsHot, slQuestionVM.UserInfoId, slQuestionVM.PageIndex, slQuestionVM.PageSize, out count);
            list.RCount = count;
            list.PCount = count % slQuestionVM.PageSize == 0 ? (count / slQuestionVM.PageSize) : (count / slQuestionVM.PageSize + 1);//(count + pageDto.PageIndex - 1) / pageDto.PageSize;

            ResultJson<QuestionVM> listVM = new ResultJson<QuestionVM>();
            listVM.RCount = list.RCount;
            listVM.PCount = list.PCount;
            List<QuestionVM> questionVMlist = new List<QuestionVM>();
            if (list.Data != null)
            {
                foreach (var result in list.Data)
                {
                    QuestionVM question = new QuestionVM();
                    question.Content = result.Content;
                    question.Title = result.Title;
                    question.CTime = result.CTime;
                    question.IsHot = result.IsHot;
                    question.IsTop = result.IsTop;
                    question.QuestionId = result.QuestionId;
                    question.Reads = result.Reads;
                    question.Sort = result.Sort;
                    question.UserInfo = result.UserInfo;
                    question.UserInfoId = result.UserInfoId;

                    List<ReplyVM> childList = new List<ReplyVM>();
                    if (result.ReplyList != null)
                    {
                        foreach (var item in result.ReplyList)
                        {
                            childList.Add(new ReplyVM
                            {
                                Content = item.Content,
                                CTime = item.CTime,
                                QuestionId = item.QuestionId,
                                Reads = item.Reads,
                                ReplyId = item.ReplyId,
                                Sort = item.Sort,
                                UserInfo = item.UserInfo,
                                UserInfoId = item.UserInfoId
                            });
                        }
                    }
                    question.ReplyList = childList;
                    questionVMlist.Add(question);
                }
            }
            listVM.Data = questionVMlist;
            return Json(new { Success = true, Msg = "OK", Data = listVM });
        }

        /// <summary>
        /// 获取单个问题的详细
        /// </summary>
        /// <param name="QuestionId"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetQuestion(int QuestionId = 0)
        {
            var result = _questionService.GetById(QuestionId);
            QuestionVM question = new QuestionVM();
            question.Content = result.Content;
            question.Title = result.Title;
            question.CTime = result.CTime;
            question.IsHot = result.IsHot;
            question.IsTop = result.IsTop;
            question.QuestionId = result.QuestionId;
            question.Reads = result.Reads;
            question.Sort = result.Sort;
            question.UserInfo = result.UserInfo;
            question.UserInfoId = result.UserInfoId;
            List<ReplyVM> childList = new List<ReplyVM>();
            if (result.ReplyList != null)
            {
                foreach (var item in result.ReplyList)
                {

                    childList.Add(new ReplyVM
                    {
                        Content = item.Content,
                        CTime = item.CTime,
                        QuestionId = item.QuestionId,
                        Reads = item.Reads,
                        ReplyId = item.ReplyId,
                        Sort = item.Sort,
                        UserInfo = item.UserInfo,
                        UserInfoId = item.UserInfoId
                    });
                }
            }
            question.ReplyList = childList;
            return Json(new { Success = true, Msg = "OK", Data = question });
        }
    }
}
