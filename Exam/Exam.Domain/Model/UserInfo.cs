using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    public class UserInfo: IAggregateRoot
    {
        public virtual int UserInfoId { get; set; }
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual string Comment { get; set; }
        public virtual DateTime CreateTime { get; set; }

        public virtual List<UserFav> UserFavList { get; set; }
    }
}
