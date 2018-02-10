using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exam.Core.Infrastructure;
using Exam.IService;

namespace Exam.Api.Controllers
{
    /// <summary>
    /// 版本号
    /// </summary>
    public class VersionTableApiController : ApiController
    {
        private readonly IVersionTableService _versionTableService = EngineContext.Current.Resolve<IVersionTableService>();

        /// <summary>
        /// 根据分类获取广告
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetVersionTableList(string Title="",int TypeId=0)
        {
            int totalCount = 0;
            var list = _versionTableService.GetManagerList(Title, TypeId, 1, 100, out totalCount);
            return Json(new { Success = true, Msg = "OK", Data = list });
        }
    }
}
