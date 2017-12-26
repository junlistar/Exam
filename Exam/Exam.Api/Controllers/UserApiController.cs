using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Exam.Api.Controllers
{
    public class UserApiController : ApiController
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult a()
        {
            throw new Exception("a");
            return Json(new { Success = false, Msg = "用户名已存在", Data = "" });
        }
    }
}
