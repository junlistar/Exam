using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    public class SysGroupMenu : IAggregateRoot
    {
        public virtual int SysGroupMenuId { get; set; } 
        public virtual int SysMenuId { get; set; }
        public virtual int SysGroupId { get; set; } 
        public virtual DateTime CTime { get; set; }
        public virtual DateTime UTime { get; set; }

         
    }
}
