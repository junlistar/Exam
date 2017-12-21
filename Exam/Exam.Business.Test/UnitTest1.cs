using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exam.Core.Infrastructure;
using Exam.Domain.Model;

namespace Exam.Business.Test
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IUserInfoBusiness _userInfo = EngineContext.Current.Resolve<IUserInfoBusiness>();
        [TestMethod]
        public void AddUserTest()
        {
            Random rd = new Random();


            UserInfo userInfo = new UserInfo();
            userInfo.NikeName = "张大胆" +rd.Next(99999);
            userInfo.Gender = rd.Next(100) > 50 ? 1 : 0;
            userInfo.IsEnable= 1;
            userInfo.CTime = DateTime.Now;

           var addResult = _userInfo.Insert(userInfo);

             
        }
        [TestMethod]
        public void GetUser()
        {
           // int id = 1;

           //var getResult = _userInfo.GetUserByID(id);

           // try
           // {
           //     var list = getResult.UserFavList;
           // }
           // catch (Exception ex)
           // {

           //     throw;
           // }
        }
    }
}
