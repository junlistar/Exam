using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    public class SmsLog : IAggregateRoot
    {
        public virtual int SmsLogId { get; set; }
        public virtual string Phone { get; set; } 
        public virtual int IsSend { get; set; } 
        public virtual string Code { get; set; }  
        public virtual DateTime CreateTime { get; set; }
         
         
    }
}
