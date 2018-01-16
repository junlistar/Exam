using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exam.Domain.Model;

namespace Exam.Api.Models
{
    /// <summary>
    /// 回复模型
    /// </summary>
    public class ReplyVM
    {
        public  int ReplyId { get; set; }
        public  string Content { get; set; }
        public  int UserInfoId { get; set; }
        public  int QuestionId { get; set; }
        public  int Reads { get; set; }
        public  int Sort { get; set; }

        public  DateTime CTime { get; set; }
        public  UserInfo UserInfo { get; set; }
    }
}