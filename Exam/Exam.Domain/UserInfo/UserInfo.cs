using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.UserInfo
{
    public class UserInfo: IAggregateRoot
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual string Comment { get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}
