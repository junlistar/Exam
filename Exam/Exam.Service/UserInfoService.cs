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

        public UserInfo GetById(int Id)
        {
            return _userBiz.GetById(Id);
        }

        public UserInfo Insert(UserInfo model)
        {
            return _userBiz.Insert(model);
        }

        

    }
}
