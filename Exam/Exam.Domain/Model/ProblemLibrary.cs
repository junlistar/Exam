using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 题库
    /// </summary>
    public class ProblemLibrary: IAggregateRoot
    {
        public virtual int ProblemLibraryId { get; set; }

        public virtual string Title { get; set; }

        public virtual int ProblemCategoryId { get; set; }

        public virtual int BelongId { get; set; }

        public virtual DateTime CTime { get; set; }

        public virtual string c_tips { get; set; }

        public virtual string c_sortid { get; set; }

        public virtual int c_sctid { get; set; }

        public virtual string c_score { get; set; }

        public virtual int c_qustiontype { get; set; }

        public virtual int c_qid { get; set; }

        public virtual string c_options { get; set; }

        public virtual string c_assistantsortid { get; set; }

        public virtual string c_answer { get; set; }

        public virtual int c_MistakeNum { get; set; }

        public virtual int isVideo { get; set; }

        public virtual int IsUse { get; set; }
    }
}
