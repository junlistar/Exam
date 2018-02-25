using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{

    /// <summary>
    /// 题目所属--注会，初级，中级，高级，税务师
    /// </summary>
    public class Belong : IAggregateRoot
    {
        public virtual int BelongId { get; set; }
        public virtual string Title { get; set; }
        public virtual int Sort { get; set; }
        public virtual DateTime CTime { get; set; }
        public virtual DateTime UTime { get; set; }

    }
}
