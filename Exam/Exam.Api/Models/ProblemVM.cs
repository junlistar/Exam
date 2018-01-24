using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exam.Domain.Model;

namespace Exam.Api.Models
{
    /// <summary>
    /// 题目
    /// </summary>
    public class ProblemVM
    {
        public int ProblemId { get; set; }
        public string Title { get; set; }

        public string Analysis { get; set; }
        public int ProblemCategoryId { get; set; }

        public int IsCollect { get; set; }
        public ProblemCategory ProblemCategory { get; set; }
        public List<AnswerVM> AnswerList { get; set; }
    }
}