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
    /// 广告
    /// </summary>
    public class AdvertisementApiController : ApiController
    {
        private readonly IAdvertisementService _advertisementService = EngineContext.Current.Resolve<IAdvertisementService>();

        /// <summary>
        /// 根据分类获取广告
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public IHttpActionResult GetAdvertisementList([FromUri]SelAdvertisementDto dto)
        {
            ResultJson<Advertisement> list = new ResultJson<Advertisement>();
            int count = 0;
            list.Data = _advertisementService.GetManagerList("", dto.TypeId, dto.PageIndex, dto.PageSize, out count);
            list.RCount = count;
            list.PCount = count % dto.PageSize == 0 ? (count / dto.PageSize) : (count / dto.PageSize + 1);//(count + pageDto.PageIndex - 1) / pageDto.PageSize;

            return Json(new { Success = true, Msg = "OK", Data = list });
        }
    }
}
