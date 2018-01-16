using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exam.Domain.Model;

namespace Exam.Api.Models
{
    /// <summary>
    /// 问题模型
    /// </summary>
    public class QuestionVM
    {
        public  int QuestionId { get; set; }
        public  string Title { get; set; }
        public  string Content { get; set; }
        public  int UserInfoId { get; set; }
        public  int Sort { get; set; }
        public  int Reads { get; set; }
        public  int IsTop { get; set; }
        public  int IsHot { get; set; }
        public  int IsEnable { get; set; }

        public  DateTime CTime { get; set; }

        public  UserInfo UserInfo { get; set; }
        public List<ReplyVM> ReplyList { get; set; }
    }
}