using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exam.Core.Infrastructure;
using Exam.Business.UserInfo;

namespace Exam.Business.Test
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IUserInfoBusiness _userInfo = EngineContext.Current.Resolve<IUserInfoBusiness>();
        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
