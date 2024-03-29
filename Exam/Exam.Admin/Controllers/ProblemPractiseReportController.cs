﻿using Exam.Admin.Models;
using Exam.Business;
using Exam.Common;
using Exam.Core.Infrastructure;
using Exam.Core.Utils;
using Exam.Domain;
using Exam.Domain.Model;
using Exam.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.Admin.Controllers
{
    public class ProblemPractiseReportController : Controller
    {
        //方式1
        IUserInfoService _userService;
        IProblemRecordService _problemRecordService;


        public ProblemPractiseReportController(IUserInfoService userService, IProblemRecordService problemRecordService)
        {
            _userService = userService;
            _problemRecordService = problemRecordService;
        }

        /// <summary>
        /// 获取题目做题统计
        /// </summary>
        /// <param name="_ProblemRecordVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(ProblemRecordVM _ProblemRecordVM, int pn = 1)
        {
            int totalCount,
                pageIndex = pn,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _problemRecordService.GetProblemPractiseReportList(_ProblemRecordVM.QueryProblemId, pageIndex, pageSize, out totalCount);
            var paging = new Paging<ProblemPractiseReportModel>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _ProblemRecordVM.ProblemPractiseReportModelPaging = paging;
            return View(_ProblemRecordVM);
        }

        /// <summary>
        /// 获取题目做题统计(正确或者错误的题目列表)
        /// </summary>
        /// <param name="_ProblemRecordVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult ProblemList(ProblemRecordVM _ProblemRecordVM, int pn = 1)
        {
            int totalCount,
                pageIndex = pn,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _problemRecordService.GetProblemPractiseReportList(_ProblemRecordVM.Id, _ProblemRecordVM.YesNo, pageIndex, pageSize, out totalCount);
            var paging = new Paging<ProblemRecord>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _ProblemRecordVM.DetailPaging = paging;
            return View(_ProblemRecordVM);
        }
    }
}