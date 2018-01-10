using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Core.SMS
{
    /// <summary>
    /// 短信模版
    /// </summary>
    public static class SmsTemplate
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        public static string SmsRegister = ConfigurationManager.AppSettings["SmsRegister"]==null ? "SMS_61060160" : ConfigurationManager.AppSettings["SmsRegister"];

        /// <summary>
        /// 用户注册
        /// </summary>
        public static string SmsLogin = ConfigurationManager.AppSettings["SmsLogin"] == null ? "SMS_61060160" : ConfigurationManager.AppSettings["SmsLogin"];

    }
}
 