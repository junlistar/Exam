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
    /// 考试模块
    /// </summary>
    public class UserExamController : ApiController
    {
        private readonly IExamClassService _examClassService = EngineContext.Current.Resolve<IExamClassService>();

        private readonly IExamProblemService _examProblemService = EngineContext.Current.Resolve<IExamProblemService>();

        /// <summary>
        /// 得到考试分类表
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetExamClassList()
        {
            var list = _examClassService.GetExamClassList();
            return Json(new { Success = true, Msg = "OK", Data = list });
        }
    }
}
