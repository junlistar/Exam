using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 问题收藏表
    /// </summary>
    public class ProblemCollect : IAggregateRoot
    {
        public virtual int ProblemCollectId { get; set; } 
        public virtual int ProblemId { get; set; }
        public virtual int UserInfoId { get; set; }
        public virtual DateTime CTime { get; set; } 
        public virtual DateTime UTime { get; set; } 

        public virtual Problem Problem { get; set; }
    }
}
