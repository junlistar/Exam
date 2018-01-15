using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 回答表
    /// </summary>
    public class Reply : IAggregateRoot
    {
        public virtual int ReplyId { get; set; }
        public virtual string Content { get; set; }
        public virtual int UserInfoId { get; set; } 
        public virtual int QuestionId { get; set; }
        public virtual int Reads { get; set; }
        public virtual int Sort { get; set; }

        public virtual DateTime CTime { get; set; }

        public virtual Question Question { get; set; }

        public virtual UserInfo UserInfo { get; set; }

    }
}
