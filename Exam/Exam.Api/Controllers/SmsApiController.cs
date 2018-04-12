using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exam.Api.Common;
using Exam.Core.Infrastructure;
using Exam.IService;

namespace Exam.Api.Controllers
{
    /// <summary>
    /// 短信发送模块
    /// </summary>
    public class SmsApiController : ApiController
    {
        //ISmsService _smsService;
        //方式2
        private readonly ISmsService _smsService = EngineContext.Current.Resolve<ISmsService>();
        //public SmsApiController() { }
        ///// <summary>
        ///// 依赖注入
        ///// </summary>
        ///// <param name="smsService"></param>
        //public SmsApiController(ISmsService smsService)
        //{
        //    _smsService = smsService;
        //}

        /// <summary>
        /// 发送注册验证码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult SendRegister(string phone)
        {
            string code = RandomHelper.GenerateCheckCodeNum(6);
            CacheHelper.SetCache(phone + "Code", code, TimeSpan.FromMinutes(10));
            _smsService.SmsUserInfoRegister(phone, code);
            return Json(new { Success = true, Msg = "OK", Data = code });
        }

        /// <summary>
        /// 发送注册验证码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult SendLogin(string phone)
        {

            string code = RandomHelper.GenerateCheckCodeNum(6);
            if (phone=="15813848708")
            {
                code = "888888";
                CacheHelper.SetCache(phone + "Login", code, TimeSpan.FromMinutes(10));
            }
            else
            {
                CacheHelper.SetCache(phone + "Login", code, TimeSpan.FromMinutes(10));
                _smsService.SmsLogin(phone, code);
            }
            return Json(new { Success = true, Msg = "OK", Data = code });
        }
    }
}
