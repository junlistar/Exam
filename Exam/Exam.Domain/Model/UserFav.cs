using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    public class UserFav : IAggregateRoot
    {
        public virtual int UserFavId { get; set; }
        public virtual string FavName { get; set; }
        public virtual int UserInfoId { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}
