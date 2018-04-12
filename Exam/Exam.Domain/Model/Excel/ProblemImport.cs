using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model.Excel
{
    public class ProblemImport
    { 
        public string Title { get; set; }
        public string Category { get; set; }
        public string Belong { get; set; }
        public string Subject { get; set; }
        public string Chapter { get; set; }
        public string Answers { get; set; }
        public string Correct { get; set; }
        public string Analysis { get; set; }
        public string IsImportant { get; set; }

    }

    public class ImportResponseModel {
        public int ImportSuccessCount { get; set; }

        public int ImportFailCount { get; set; }

        public bool Result { get; set; }
        public string Message { get; set; }
    }
}
