using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exam.Domain.Model;

namespace Exam.Api.Models
{
    public class ProblemRecordVM
    {
        /// <summary>
        /// 问题记录id
        /// </summary>
        public int ProblemRecordId { get; set; }
        /// <summary>
        /// 问题id
        /// </summary>
        public int ProblemId { get; set; }
        /// <summary>
        /// 正确答案
        /// </summary>
        public string CorrectAnswer { get; set; }
        /// <summary>
        /// 用户选择的答案
        /// </summary>
        public string ErrorAnswer { get; set; }
        /// <summary>
        /// 是否正确1对 2错
        /// </summary>
        public int YesOrNo { get; set; }
    }

    public class AnswerRecordVM
    {
        public int AnswerRecordId { get; set; }
        public string Title { get; set; }
        public int ProblemRecordId { get; set; }
        public int IsCorrect { get; set; }
    }
}