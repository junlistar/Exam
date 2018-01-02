using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 问题表
    /// </summary>
    public class Problem : IAggregateRoot
    {
        public virtual int ProblemId { get; set; }
        public virtual string Title { get; set; }  
        public virtual int ProblemCategoryId { get; set; }
        public virtual int BelongId { get; set; }
        public virtual int ChapterId { get; set; } 
        public virtual int IsHot { get; set; }  
        public virtual int Sort { get; set; }
        public virtual DateTime CTime { get; set; } 
        public virtual DateTime UTime { get; set; }

        public virtual List<Answer> AnswerList { get; set; }
    }
}
