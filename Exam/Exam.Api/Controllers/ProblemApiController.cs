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
    /// 问题模块
    /// </summary>
    public class ProblemApiController : ApiController
    {
        //方式2
        private readonly IProblemService _newsInfoService = EngineContext.Current.Resolve<IProblemService>();



    }
}
