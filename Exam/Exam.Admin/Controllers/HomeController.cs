using Exam.Admin.Common;
using Exam.Core.Utils;
using Exam.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.Admin.Controllers
{
    public class HomeController : BaseController
    {

        IUserInfoService _userService;
        ISysMenuService _menuService;


        public HomeController(IUserInfoService userService, ISysMenuService menuService)
        {
            _userService = userService;
            _menuService = menuService;
        }


        public ActionResult Index()
        {
            _menuService.GetManagerList()

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Empty()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
         
    }
}