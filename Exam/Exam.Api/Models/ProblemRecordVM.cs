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

        public int ProblemId { get; set; }
        public string CorrectAnswer { get; set; }
        public string ErrorAnswer { get; set; }
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