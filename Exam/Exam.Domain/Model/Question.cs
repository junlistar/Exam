using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 提问表
    /// </summary>
    public class Question : IAggregateRoot
    {
        public virtual int QuestionId { get; set; }
        public virtual string Title { get; set; }  
        public virtual string Content { get; set; }
        public virtual int UserInfoId { get; set; } 
        public virtual int Sort { get; set; }
        public virtual int Reads { get; set; }
        public virtual int IsTop { get; set; }
        public virtual int IsHot { get; set; }
        public virtual int IsEnable { get; set; }

        public virtual DateTime CTime { get; set; }

    }
}
