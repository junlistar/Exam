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
        public virtual string NikeName { get; set; }
        public virtual int Gender { get; set; }
        public virtual int IsEnable { get; set; } 
        public virtual DateTime CTime { get; set; }

        //public virtual List<UserFav> UserFavList { get; set; }
    }
}
