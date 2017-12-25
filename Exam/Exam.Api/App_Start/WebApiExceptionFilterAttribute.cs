using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;

namespace Exam.Api.App_Start
{
    /// <summary>
    /// 异常处理类
    /// </summary>
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 重写基类的异常处理方法
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseMessage response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.OK);
            string jsonStr = JsonConvert.SerializeObject(new { Success = false, Msg = actionExecutedContext.Exception.Message, Data = "" });
            response.Content = new StringContent(jsonStr, Encoding.UTF8);
            actionExecutedContext.Response = response;
            base.OnException(actionExecutedContext);
        }
    }
}