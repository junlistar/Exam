using Exam.Admin.Infrastructure;
using Exam.Core.Infrastructure;
using Exam.Domain.Model;
using Exam.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.Admin.Controllers
{
    [AccountAuthorize]
    public class BaseController : Controller
    {
        private ILogService _logService;
        /// <summary>
        /// 异步调用写日志服务
        /// </summary>  
        protected virtual void WriteLogAnysc(Log log)
        {
            if (_logService == null)
            {
                _logService = EngineContext.Current.Resolve<ILogService>();
            }
            //System.Threading.Tasks.Task.Run(() =>
            //{
            //写日志
            _logService.Insert(log);
           // });
        }
    }
}