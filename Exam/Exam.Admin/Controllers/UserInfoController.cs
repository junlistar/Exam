using Exam.Business;
using Exam.Core.Infrastructure;
using Exam.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.Admin.Controllers
{
    public class UserInfoController : Controller
    {
        //方式1
        IUserInfoService _userService; 
        //方式2
        private readonly IUserInfoService _userInfo = EngineContext.Current.Resolve<IUserInfoService>();
      
        public UserInfoController(IUserInfoService userService)
        {
            _userService = userService; 
        }

        public ActionResult Index()
        {

            var model = _userService.GetUser(1);

            var model2 = _userInfo.GetUser(1);


            return View(model);
        }

       
    }
}