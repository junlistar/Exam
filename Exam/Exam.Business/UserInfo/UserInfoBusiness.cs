using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class UserInfoBusiness:IUserInfoBusiness
    {
        private IRepository<UserInfo> _repoUserInfo;

        public UserInfoBusiness(
          IRepository<UserInfo> repoUserInfo
          )
        {
            _repoUserInfo = repoUserInfo;
        }
        /// <summary>
        /// 根据ID查找用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfo GetUserByID(int id)
        {
            return this._repoUserInfo.GetById(id);
        }

        public UserInfo AddUser(UserInfo model)
        {
            return this._repoUserInfo.Insert(model);
        }
    }
}


