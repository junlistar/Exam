using Exam.Business;
using Exam.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain.Model;

namespace Exam.Service
{
    public class UserInfoService: IUserInfoService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IUserInfoBusiness _userBiz;

        public UserInfoService(IUserInfoBusiness userBiz) {
            _userBiz = userBiz;
        }

        public UserInfo GetUser(int Id)
        {
            return _userBiz.GetUserByID(Id);
        }

        public UserInfo AddUser(UserInfo model)
        {
            return _userBiz.AddUser(model);
        }

        

    }
}
