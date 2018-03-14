using Exam.Admin.Common;
using Exam.Core.Infrastructure;
using Exam.IService;
using System;
using System.Web.Mvc;

namespace Exam.Admin.Infrastructure
{
    /// <summary>
    /// 账号验证
    /// </summary>
    public class AccountAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        { 
            int accountId = Loginer.AccountId;
            if (accountId == 0)
            {
                filterContext.Result = new RedirectResult("/Login/Login");
            }

            base.OnActionExecuting(filterContext);
        }
         
    }
}