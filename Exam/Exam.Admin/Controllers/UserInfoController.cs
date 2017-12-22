﻿using Exam.Admin.Models;
using Exam.Business;
using Exam.Core.Infrastructure;
using Exam.Core.Utils;
using Exam.Domain.Model;
using Exam.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.Admin.Controllers
{
    public class UserInfoController : Controller
    {
        //方式1
        IUserInfoService _userService; 
        //方式2
        private readonly IUserInfoService _userInfo = EngineContext.Current.Resolve<IUserInfoService>();
      
        public UserInfoController(IUserInfoService userService)
        {
            _userService = userService; 
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_userInfoVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(UserInfoVM _userInfoVM, int pn = 1)
        {
            int totalCount,
                pageIndex = (pn - 1) * PagingConfig.PAGE_SIZE,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _userService.GetManagerList(_userInfoVM.QueryLoginName, pageIndex, pageSize, out totalCount);
            var paging = new Paging<UserInfo>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _userInfoVM.Paging = paging;
            return View(_userInfoVM);
        }

    }
}