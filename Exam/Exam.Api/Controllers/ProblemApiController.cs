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
                //ProblemVM
                var problemList = problemService.GetProblemList(SelctProblemVM.belongId, SelctProblemVM.ChapterId);

                List<ProblemVM> problemVMlist = new List<ProblemVM>();
                foreach (var result in problemList)
                {
                    ProblemVM problem = new ProblemVM();
                    problem.ProblemId = result.ProblemId;
                    problem.Title = result.Title;
                    problem.ProblemCategoryId = result.ProblemCategoryId;
                    problem.ProblemCategory = result.ProblemCategory;

                    List<AnswerVM> childList = new List<AnswerVM>();
                    foreach (var item in result.AnswerList)
                    {

                        childList.Add(new AnswerVM
                        {
                            AnswerId = item.AnswerId,
                            ProblemId = item.ProblemId,
                            IsCorrect = item.IsCorrect,
                            Title = item.Title
                        });
                    }
                    problem.AnswerList = childList;
                    problemVMlist.Add(problem);
                }
                return Json(new { Success = true, Msg = "OK", Data = problemVMlist });
            }
            else
            {
                return Json(new { Success = false, Msg = "参数不对", Data = "" });
            }
        }
    }
}
