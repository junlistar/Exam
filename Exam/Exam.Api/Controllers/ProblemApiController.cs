using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exam.Api.Models;
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
        private readonly IProblemService problemService = EngineContext.Current.Resolve<IProblemService>();

        private readonly IBelongService belongService = EngineContext.Current.Resolve<IBelongService>();

        private readonly IChapterService chapterService = EngineContext.Current.Resolve<IChapterService>();


        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetbelongList()
        {
            return Json(new { Success = true, Msg = "OK", Data = belongService.GetAll() });
        }

        /// <summary>
        /// 获取章节列表
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetchapterList()
        {
            return Json(new { Success = true, Msg = "OK", Data = belongService.GetAll() });
        }

        /// <summary>
        /// 获取题目列表
        /// </summary>
        /// <param name="SelctProblemVM"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetProblemList([FromUri]SelctProblemVM SelctProblemVM)
        {
            if (SelctProblemVM != null)
            {
                return Json(new { Success = true, Msg = "OK", Data = problemService.GetProblemList(SelctProblemVM.belongId, SelctProblemVM.ChapterId) });
            }
            else
            {
                return Json(new { Success = false, Msg = "参数不对", Data = "" });
            }
        }
    }
}
