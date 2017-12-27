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
    public class UserInfoService : IUserInfoService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IUserInfoBusiness _userBiz;

        public UserInfoService(IUserInfoBusiness userBiz)
        {
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
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(UserInfo model)
        {
            this._userBiz.Update(model);
        }
        /// <summary>
        /// 管理后台用户列表
        /// </summary> 
        /// <returns></returns>
        public List<UserInfo> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return _userBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }

    }
}
