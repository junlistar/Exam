using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 等级表 学员，老师
    /// </summary>
    public class Grade : IAggregateRoot
    {
        public virtual int GradeId { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime CTime { get; set; }
        public virtual DateTime UTime { get; set; }

         
    }
}
