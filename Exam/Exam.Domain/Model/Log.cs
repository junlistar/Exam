using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    public class Log : IAggregateRoot
    {
        public virtual int LogId { get; set; }
        public virtual int TargetId { get; set; } 
        public virtual string TargetTitle { get; set; } 
        public virtual int UserInfoId { get; set; }  
        public virtual DateTime CTime { get; set; }


        public virtual UserInfo UserInfo { get; set; }
         
    }
}
