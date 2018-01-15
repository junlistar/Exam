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

        private readonly INewsCategoryService _NewsCategoryService = EngineContext.Current.Resolve<INewsCategoryService>();

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
        /// <param name="newsVM"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetNewsList([FromUri]NewsVM newsVM)
        {
            ResultJson<NewsInfo> list = new ResultJson<NewsInfo>();
            int count = 0;
            list.Data = _newsInfoService.GetNewsInfoList("", newsVM.NewsCategoryId, newsVM.IsHot,newsVM.PageIndex, newsVM.PageSize, out count);
            list.RCount = count;
            list.PCount = count % newsVM.PageSize == 0 ? (count / newsVM.PageSize) : (count / newsVM.PageSize + 1);//(count + pageDto.PageIndex - 1) / pageDto.PageSize;

            return Json(new { Success = true, Msg = "OK", Data = list });
        }
        /// <summary>
        /// 获取咨询分类列表
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IHttpActionResult GetNewsCategoryList() {
            return Json(new { Success = true, Msg = "OK", Data = _NewsCategoryService.GetAll() });
        }

        /// <summary>
        /// 添加阅读数获取列表
        /// </summary>
        /// <param name="NewsInfoId"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetNewsReads(int NewsInfoId)
        {
             var model= _newsInfoService.GetById(NewsInfoId);
            if (model != null)
            {
                model.Reads = +1;
                _newsInfoService.Update(model);
            }
            return Json(new { Success = true, Msg = "OK", Data = model.Reads });
        }
    }
}
