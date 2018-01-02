using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 答案表
    /// </summary>
    public class Answer : IAggregateRoot
    {
        public virtual int AnswerId { get; set; }
        public virtual string Title { get; set; }  
        public virtual int ProblemId { get; set; }
        public virtual int IsCorrect { get; set; }


        public virtual Problem Problem { get; set; }
    }
}
