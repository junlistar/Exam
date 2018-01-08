using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exam.Api.Common;
using Exam.Api.Models;
using Exam.Core.Infrastructure;
using Exam.Domain.Model;
using Exam.IService;

namespace Exam.Api.Controllers
{
    public class UserApiController : ApiController
    {

        //方式2
        private readonly IUserInfoService _userInfo = EngineContext.Current.Resolve<IUserInfoService>(); 

        //方式1
        IUserInfoService _userService;

        public UserApiController() { }
        public UserApiController(IUserInfoService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Register(string phone = "", string code = "")
        {
            string pcode = CacheHelper.GetCache(phone + "Code").ToString();
            if (!string.IsNullOrWhiteSpace(phone))
            {
                if (!string.IsNullOrWhiteSpace(code) && code == pcode)
                {
                    if (_userInfo.IsExistPhone(phone))
                    {
                        return Json(new { Success = false, Msg = "电话号码已经存在", Data = "" });
                    }
                    else
                    {
                        UserInfo userInfo = _userInfo.Insert(new UserInfo
                        {
                            CTime = DateTime.Now,
                            Gender = 0,
                            ImageInfoId = 1000,
                            IsEnable = 1,
                            Phone = phone,
                            UTime = DateTime.Now
                        });
                        return Json(new { Success = true, Msg = "验证码正确", Data = userInfo });
                    }
                }
                else
                {
                    return Json(new { Success = false, Msg = "验证码不正确", Data = "" });
                }
            }
            else
            {
                return Json(new { Success = false, Msg = "手机号码不正确", Data = "" });
            }
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult UpdateUserInfo(UpdateUserInfoVM updateUserInfoVM)
        {
            var userInfo=_userInfo.GetById(updateUserInfoVM.UserInfoId);

            if (userInfo != null)
            {
                return Json(new { Success = false, Msg = "电话号码已经存在", Data = "" });
            }
            else {
                return Json(new { Success = false, Msg = "电话号码已经存在", Data = "" });
            }
        }
    }
}
