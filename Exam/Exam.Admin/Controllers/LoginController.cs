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
    public class LoginController : Controller
    {

        IUserInfoService _userService;

        public LoginController(IUserInfoService userService)
        {
            _userService = userService;
        }


        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Login(string account = "", string password = "")
        {
            var info = _userService.Login(account, MD5Util.GetMD5_32(password));
            if (info == null)
            {
                //无此账号信息
                return Json(new { Status = -1 }, JsonRequestBehavior.AllowGet);
            }
            if (info.IsEnable == (int)Exam.Domain.EnumHelp.EnabledEnum.无效)
            {
                //该账号被禁用
                return Json(new { Status = -2 }, JsonRequestBehavior.AllowGet);
            } 
            //缓存用户信息(ID,NICKNAME)
            SessionHelper.Add(LoginerConst.ACCOUNT_ID, info.UserInfoId.ToString());
            SessionHelper.Add(LoginerConst.ACCOUNT, info.NikeName); 
            SessionHelper.Add(LoginerConst.GROUP_ID, info.SysGroupId.ToString());
            SessionHelper.Add(LoginerConst.ACCOUNT_IMG, info.ImageInfo==null? "" : info.ImageInfo.Source + info.ImageInfo.Url);
            return Json(new { Status = 1 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SignOut()
        {
            Loginer.DelAccountCache();
            return View("Login");
        }
    }
}