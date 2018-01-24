using Exam.Admin.Common;
using Exam.Core.Utils;
using Exam.Domain.Model;
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
        ISysGroupMenuService _groupmenuService;


        public HomeController(IUserInfoService userService, ISysMenuService menuService, ISysGroupMenuService groupmenuService)
        {
            _userService = userService;
            _menuService = menuService;
            _groupmenuService = groupmenuService;
        }


        public ActionResult Index()
        {
            // var menulist = _menuService.GetAll().ToList().Select(p => p.SysMenuId);
            var mylist = from p in _groupmenuService.GetAll().Where(p => p.SysGroupId == Loginer.GroupId)
                         select new SysMenu
                         {
                             SysMenuId = p.SysMenu.SysMenuId,
                             Icon = p.SysMenu.Icon,
                             Fid = p.SysMenu.Fid,
                             Name = p.SysMenu.Name,
                             IsEnable = p.SysMenu.IsEnable,
                             Url = p.SysMenu.Url
                         };
              
            return View(mylist.ToList());
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