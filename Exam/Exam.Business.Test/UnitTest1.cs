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
        private readonly IQuestionBusiness _questionInfo = EngineContext.Current.Resolve<IQuestionBusiness>();
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
        public void GetQuestion()
        {
            int id = 1000;

            var getResult = _questionInfo.GetById(id);

            try
            {
                var list = getResult;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
