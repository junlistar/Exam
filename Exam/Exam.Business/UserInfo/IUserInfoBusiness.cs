using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public interface IUserInfoBusiness
    {


        UserInfo GetById(int id);

        UserInfo Insert(UserInfo model);

        /// <summary>
        /// 管理后台用户列表
        /// </summary> 
        /// <returns></returns>
        List<UserInfo> GetManagerList(string name, int pageNum, int pageSize, out int totalCount);
    }
}
