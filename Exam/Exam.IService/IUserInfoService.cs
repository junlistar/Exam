using Exam.Domain.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.IService
{
    public interface IUserInfoService
    {
        UserInfo GetUser(int Id);

        UserInfo AddUser(UserInfo model);
    }
}
