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
    /// 视频
    /// </summary>
    public class VideoApiController : ApiController
    {
        private readonly IVideoService _videoService = EngineContext.Current.Resolve<IVideoService>();

        /// <summary>
        /// 根据分类获取视频
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GeVideoList([FromUri]SelVideoDto dto)
        {
            ResultJson<Video> list = new ResultJson<Video>();
            int count = 0;
            list.Data = _videoService.GetManagerList("", dto.VideoClassId, dto.PageIndex, dto.PageSize, out count);
            list.RCount = count;
            list.PCount = count % dto.PageSize == 0 ? (count / dto.PageSize) : (count / dto.PageSize + 1);//(count + pageDto.PageIndex - 1) / pageDto.PageSize;

            return Json(new { Success = true, Msg = "OK", Data = list });
        }
    }
}
