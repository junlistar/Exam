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
            userInfo.Name = "张大胆" +rd.Next(99999);
            userInfo.Age =32+rd.Next(50);
            userInfo.Comment = "张大胆张大胆张大胆张大胆张大胆张大胆张大胆" + rd.Next(1000000);
            userInfo.CreateTime = DateTime.Now;

           var addResult = _userInfo.AddUser(userInfo);

             
        }
        [TestMethod]
        public void GetUser()
        {
            int id = 1;

           var getResult = _userInfo.GetUserByID(id);

            try
            {
                var list = getResult.UserFavList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
