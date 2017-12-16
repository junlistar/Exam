using Exam.Core.Infrastructure;
using Exam.Domain.Model;
using Exam.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Exam.Admin.Infrastructure
{
    /// <summary>
    /// 工作上下文
    /// </summary>
    /// <seealso cref="Exam.Core.Infrastructure.IWorkContext" />
    public class WebWorkContext : IWorkContext
    {
        #region 变量区

        private const string USER_SESSION = "Exam_USER";
        private const string USER_CLIENT_INFO_SESSION = "USER_CLIENT_INFO_SESSION";
        private HttpRequestBase _request;
        private HttpResponseBase _response;
        private UserInfo _user;
        private IUserInfoService _userSvc;

        #endregion

        #region 属性区

        public string UserCookie { get; set; }

        public string UserClientInfoCookie { get; set; }

        /// <summary>
        /// 当前用户Id（登录后必须设置该属性）
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        private int? UserId
        {
            get
            {
                var objUserId = _request.RequestContext.HttpContext.Session[USER_SESSION];

                if (objUserId == null)
                {
                    return null;
                }

                return Convert.ToInt32(objUserId);
            }

            set
            {
                _request.RequestContext.HttpContext.Session[USER_SESSION] = value;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="WebWorkContext"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="userService">The user service.</param>
        /// <param name="response">The response.</param>
        public WebWorkContext(HttpRequestBase request, IUserInfoService userService, HttpResponseBase response)
        {
            _userSvc = userService;
            _request = request;
            _response = response;
        }
         
        /// <summary>
        /// 用户是否登录
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is login; otherwise, <c>false</c>.
        /// </value>
        public bool IsLogin
        {
            get
            {
                return UserId.HasValue;
            }
        }

        /// <summary>
        /// 获取或设置用户信息
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public UserInfo User
        {
            get
            {
                if (_user == null)
                {
                    if (IsLogin)
                    {
                        // 获取当前用户信息
                       
                        var  res = _userSvc.GetUser(UserId.Value);
  
                        _user = res;
                    }
                }

                return _user;
            }
        }

        
        /// <summary>
        /// 退出
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void SignOut()
        {
            UserId = null; 

            var userCookie = _response.Cookies.Get(UserCookie);

            if (userCookie != null)
            {
                userCookie.Value = null;

                _response.Cookies.Set(userCookie);
            }

            var userClientInfoCookie = _response.Cookies.Get(UserClientInfoCookie);

            if (userClientInfoCookie != null)
            {
                userClientInfoCookie.Value = null;

                _response.Cookies.Set(userClientInfoCookie);
            }
        }

         
        /// <summary>
        /// 用户是否有效
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool IsUserValid()
        {
            return IsLogin && User != null;
        }
    }
}
