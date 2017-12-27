using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 题目类别--单选，多选，判断，问答，
    /// </summary>
    public class ProblemCategory : IAggregateRoot
    {
        public virtual int ProblemCategoryId { get; set; }
        public virtual string Title { get; set; } 
        public virtual int Sort { get; set; }  
        public virtual DateTime CTime { get; set; } 
        public virtual DateTime UTime { get; set; }

    }
}
