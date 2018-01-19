using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exam.Domain.Model;

namespace Exam.Api.Models
{
    public class ProblemRecordVM
    {
        public int ProblemRecordId { get; set; }
        public string Title { get; set; }
        public int ProblemCategoryId { get; set; }

        public string Analysis { get; set; }
        public ProblemCategory ProblemCategory { get; set; }
        public List<AnswerRecordVM> AnswerRecordList { get; set; }
    }

    public class AnswerRecordVM
    {
        public int AnswerRecordId{get;set;}
        public string Title { get; set; }
        public int ProblemRecordId { get; set; }
        public int IsCorrect { get; set; }
    }
}