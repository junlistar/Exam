﻿using System;
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

            var model= _problemCollectService.IsProblemCollect(delProblemCollectDto.UserInfoId, delProblemCollectDto.ProblemId);
            if (model != null)
            {
                _problemCollectService.Delete(model);
                return Json(new { Success = true, Msg = "OK", Data = "" });
            }
            else {
                return Json(new { Success = false, Msg = "您还没有收藏此题目", Data = "" });
            }
            
        }

        /// <summary>
        /// 查询收藏列表
        /// </summary>
        /// <param name="selProblemCollectDto"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetMyProblemCollectList([FromUri]SelProblemCollectDto selProblemCollectDto)
        {
            ResultJson<ProblemCollectVM> list = new ResultJson<ProblemCollectVM>();
            int count = 0;
            //list.Data = _problemCollectService.GetProblemCollectList(selProblemCollectDto.UserInfoId, selProblemCollectDto.PageIndex, selProblemCollectDto.PageSize, out count);
            list.RCount = count;
            list.PCount = count % selProblemCollectDto.PageSize == 0 ? (count / selProblemCollectDto.PageSize) : (count / selProblemCollectDto.PageSize + 1);//(count + pageDto.PageIndex - 1) / pageDto.PageSize;


            var problemCollectList = _problemCollectService.GetProblemCollectList(selProblemCollectDto.UserInfoId, 1, 10000, out count);

            List<ProblemCollectVM> problemRecordVMlist = new List<ProblemCollectVM>();
            foreach (var result in problemCollectList)
            {
                if (result.Problem != null)
                {
                    ProblemCollectVM problem = new ProblemCollectVM();
                    problem.ProblemId = result.ProblemId;
                    problem.Title = result.Problem.Title;
                    problem.ProblemCategoryId = result.Problem.ProblemCategoryId;
                    problem.ProblemCategory = result.Problem.ProblemCategory;
                    problem.Analysis = result.Problem.Analysis;

                    List<AnswerVM> childList = new List<AnswerVM>();
                    foreach (var item in result.Problem.AnswerList)
                    {

                        childList.Add(new AnswerVM
                        {
                            ProblemId = item.ProblemId,
                            IsCorrect = item.IsCorrect,
                            Title = item.Title,
                            AnswerId = item.AnswerId

                        });
                    }
                    problem.AnswerList = childList;
                    problemRecordVMlist.Add(problem);
                }
            }
            list.Data = problemRecordVMlist;
            return Json(new { Success = true, Msg = "OK", Data = problemRecordVMlist });
        }
    }
}
