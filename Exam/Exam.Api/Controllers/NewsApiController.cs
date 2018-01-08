using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exam.Api.Models;
using Exam.Core.Infrastructure;
using Exam.Domain.Model;
using Exam.IService;

namespace Exam.Api.Controllers
{
    /// <summary>
    /// 资讯模块
    /// </summary>
    public class NewsApiController : ApiController
    {
        //方式1
        //INewsInfoService _newsInfoService;
        //方式2
        private readonly INewsInfoService _newsInfoService = EngineContext.Current.Resolve<INewsInfoService>();

        ///// <summary>
        ///// 依赖注入
        ///// </summary>
        ///// <param name="newsInfoService"></param>
        //public NewsApiController(INewsInfoService newsInfoService)
        //{
        //    _newsInfoService = newsInfoService;
        //}

        /// <summary>
        /// 查询咨询列表
        /// </summary>
        /// <param name="pageDto"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetNewsList([FromUri]PageDto pageDto)
        {
            ResultJson<NewsInfo> list = new ResultJson<NewsInfo>();
            int count = 0;
            list.Data = _newsInfoService.GetManagerList("", pageDto.PageIndex, pageDto.PageSize, out count);
            list.RCount = count;
            list.PCount = count % pageDto.PageSize == 0 ? (count / pageDto.PageSize) : (count / pageDto.PageSize + 1);//(count + pageDto.PageIndex - 1) / pageDto.PageSize;

            return Json(new { Success = true, Msg = "OK", Data = list });
        }
    }
}
