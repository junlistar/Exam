using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exam.Api.Common;

namespace Exam.Api.Controllers
{
    public class UserApiController : ApiController
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Register(string phone="",string code="")
        {
            string pcode = CacheHelper.GetCache(phone + "Code").ToString();
            if (!string.IsNullOrWhiteSpace(phone))
            {
                if (!string.IsNullOrWhiteSpace(code) && code == pcode)
                {
                    return Json(new { Success = true, Msg = "验证码正确", Data = "" });
                }
                else
                {
                    return Json(new { Success = false, Msg = "验证码不正确", Data = "" });
                }
            }
            else {
                return Json(new { Success = false, Msg = "手机号码不正确", Data = "" });
            }
        }
    }
}
