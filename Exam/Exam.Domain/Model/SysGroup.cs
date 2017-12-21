using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    public class SysGroup : IAggregateRoot
    {
        public virtual int SysGroupId { get; set; }
        public virtual string Name { get; set; }
        public virtual int SortNo { get; set; }  
        public virtual int Type { get; set; }
        public virtual int IsEnable { get; set; } 
        public virtual DateTime CTime { get; set; }
        public virtual DateTime UTime { get; set; }

         
    }
}
