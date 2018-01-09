using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Api.Models
{
    /// <summary>
    /// 用户登录
    /// </summary>
    public class LoginVM
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }
    }
}