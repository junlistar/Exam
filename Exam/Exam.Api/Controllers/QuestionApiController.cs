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
        public IHttpActionResult AddQuestion(AddQuestionDto addQuestionDto)
        {
            var model = _questionService.Insert(new Domain.Model.Question
            {
                Content = addQuestionDto.Content,
                Sort = 0,
                CTime = DateTime.Now,
                IsHot = 0,
                IsTop = 0,
                Reads = 0,
                Title = addQuestionDto.Title,
                UserInfoId = addQuestionDto.UserInfoId
            });
            return Json(new { Success = true, Msg = "OK", Data = model });
        }

        /// <summary>
        /// 新增提问接口
        /// </summary>
        /// <param name="addReplyDto"></param>
        /// <returns></returns>
        public IHttpActionResult AddReply(AddReplyDto addReplyDto)
        {
            var model = _replyService.Insert(new Domain.Model.Reply
            {
                Content = addReplyDto.Content,
                Sort = 0,
                CTime = DateTime.Now,
                Reads = 0,
                UserInfoId = addReplyDto.UserInfoId
            });
            return Json(new { Success = true, Msg = "OK", Data = model });
        }
    }
}
