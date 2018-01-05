using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exam.IService;

namespace Exam.Api.Controllers
{
    /// <summary>
    /// 短信发送模块
    /// </summary>
    public class SmsApiController : ApiController
    {
        ISmsService _smsService;
        //方式2
        //private readonly IUserInfoService _userInfo = EngineContext.Current.Resolve<IUserInfoService>();

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="smsService"></param>
        public SmsApiController(ISmsService smsService)
        {
            _smsService = smsService;
        }

        /// <summary>
        /// 发送成功
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult SendRegister(string phone) {
            _smsService.SmsUserInfoRegister("18684994985","5555");
            return Json(new { Success = true, Msg = "OK", Data = "" });
        }
    }
}
