using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Core.SMS;
using Exam.IService;

namespace Exam.Service
{
    /// <summary>
    /// 短信发送
    /// </summary>
    public class SmsService : ISmsService
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="phone">电话</param>
        /// <param name="code">验证码</param>
        public void SmsUserInfoRegister(string phone, string code)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("code", code);
            var a = SendSMSCommon.SendSMSsingleAsync(SmsTemplate.SmsNewYearLogin, phone, dic, SmsSignNameTemplate.NewYear2018);

        }
    }
}
