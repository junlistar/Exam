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
    /// 收藏模块
    /// </summary>
    public class ProblemCollectApiController : ApiController
    {
        private readonly IProblemCollectService _problemCollectService = EngineContext.Current.Resolve<IProblemCollectService>();

        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult AddProblemCollect(AddProblemCollectDto addProblemCollectDto)
        {
            //var m= _problemCollectService.

            var m = _problemCollectService.IsProblemCollect(addProblemCollectDto.UserInfoId, addProblemCollectDto.ProblemId);

            if (m == null)
            {
                var model = _problemCollectService.Insert(new Domain.Model.ProblemCollect
                {
                    ProblemId = addProblemCollectDto.ProblemId,
                    UserInfoId = addProblemCollectDto.UserInfoId,
                    CTime = DateTime.Now,
                    UTime = DateTime.Now
                });
                return Json(new { Success = true, Msg = "OK", Data = model });
            }
            else {
                return Json(new { Success = false, Msg = "您已收藏过此题目了", Data = "" });
            }
            
        }

        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult DelProblemCollect(DelProblemCollectDto delProblemCollectDto)
        {
            _problemCollectService.Delete(new Domain.Model.ProblemCollect
            {
                ProblemCollectId = delProblemCollectDto.ProblemCollectId,
                UserInfoId = delProblemCollectDto.UserInfoId
            });
            return Json(new { Success = true, Msg = "OK", Data = "" });
        }

        /// <summary>
        /// 查询咨询列表
        /// </summary>
        /// <param name="selProblemCollectDto"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetMyProblemCollectList([FromUri]SelProblemCollectDto selProblemCollectDto)
        {
            ResultJson<ProblemCollect> list = new ResultJson<ProblemCollect>();
            int count = 0;
            list.Data = _problemCollectService.GetProblemCollectList(selProblemCollectDto.UserInfoId, selProblemCollectDto.PageIndex, selProblemCollectDto.PageSize, out count);
            list.RCount = count;
            list.PCount = count % selProblemCollectDto.PageSize == 0 ? (count / selProblemCollectDto.PageSize) : (count / selProblemCollectDto.PageSize + 1);//(count + pageDto.PageIndex - 1) / pageDto.PageSize;

            return Json(new { Success = true, Msg = "OK", Data = list });
        }
    }
}
