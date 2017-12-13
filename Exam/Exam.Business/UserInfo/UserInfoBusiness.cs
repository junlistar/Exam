using Exam.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.UserInfo
{
    public class UserInfoBusiness
    {
        private IRepository<Exam.Domain.UserInfo.UserInfo> _repoUserInfo;

        public UserInfoBusiness(
          IRepository<Exam.Domain.UserInfo.UserInfo> repoUserInfo
          )
        {
            _repoUserInfo = repoUserInfo;
        }

    }
}


