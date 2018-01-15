using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Api.Models
{
    public class AddReplyDto
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserInfoId { get; set; }
        /// <summary>
        /// 问题id
        /// </summary>
        public int QuestionId { get; set; }
    }
}