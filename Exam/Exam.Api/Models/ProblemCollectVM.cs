using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exam.Domain.Model;

namespace Exam.Api.Models
{
    public class ProblemCollectVM
    {
        public int ProblemCollectId { get; set; }

        public int ProblemId { get; set; }
        public string Title { get; set; }
        public int ProblemCategoryId { get; set; }

        public string Analysis { get; set; }
        public ProblemCategory ProblemCategory { get; set; }
        public List<AnswerVM> AnswerList { get; set; }
    }


}