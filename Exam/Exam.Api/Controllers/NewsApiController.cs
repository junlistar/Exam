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
    /// 资讯模块
    /// </summary>
    public class NewsApiController : ApiController
    {
        //方式1
        INewsInfoService _newsInfoService;
        //方式2
        //private readonly IUserInfoService _userInfo = EngineContext.Current.Resolve<IUserInfoService>();

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="newsInfoService"></param>
        public NewsApiController(INewsInfoService newsInfoService)
        {
            _newsInfoService = newsInfoService;
        }


        public IHttpActionResult GetNewsList()
        {
            return Json(new { Success = false, Msg = "用户名已存在", Data = "" });
        }
    }
}
