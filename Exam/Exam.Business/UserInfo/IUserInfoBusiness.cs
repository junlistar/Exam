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


        UserInfo GetUserByID(int id);

        UserInfo AddUser(UserInfo model);
    }
}
