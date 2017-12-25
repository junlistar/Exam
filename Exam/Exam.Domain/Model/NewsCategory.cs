using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    public class NewsCategory : IAggregateRoot
    {
        public virtual int NewsCategoryId { get; set; }
        public virtual string Title { get; set; } 
        public virtual int Sort { get; set; } 
        public virtual DateTime CTime { get; set; }
        public virtual DateTime UTime { get; set; }
         
    }
}
