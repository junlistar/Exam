using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Api.Models
{
    public class AnswerVM
    {
        public int AnswerId { get; set; }
        public string Title { get; set; }
        public int ProblemId { get; set; }
        public int IsCorrect { get; set; }
    }
}