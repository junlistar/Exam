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
    /// 讲师
    /// </summary>
    public class LecturerApiController : ApiController
    {
        private readonly ILecturerService _lecturerService = EngineContext.Current.Resolve<ILecturerService>();

        /// <summary>
        /// 讲师列表
        /// </summary>
        /// <param name="selLecturerDto"></param>
        /// <returns></returns>
        public IHttpActionResult GetLecturerList([FromUri]SelLecturerDto selLecturerDto)
        {

            ResultJson<Lecturer> list = new ResultJson<Lecturer>();
            int count = 0;
            list.Data = _lecturerService.GetManagerList(selLecturerDto.Name, selLecturerDto.PageIndex, selLecturerDto.PageSize, out count);
            list.RCount = count;
            list.PCount = count % selLecturerDto.PageSize == 0 ? (count / selLecturerDto.PageSize) : (count / selLecturerDto.PageSize + 1);//(count + pageDto.PageIndex - 1) / pageDto.PageSize;

            return Json(new { Success = true, Msg = "OK", Data = list });
        }
    }
}
