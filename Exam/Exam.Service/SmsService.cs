using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Core.SMS;
using Exam.IService;
using Exam.Business;
using Exam.Domain.Model;

namespace Exam.Service
{
    /// <summary>
    /// 短信发送
    /// </summary>
    public class SmsService : ISmsService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private ISmsLogBusiness _smsLogBiz;

        public SmsService(ISmsLogBusiness smsLogBiz)
        {
            _smsLogBiz = smsLogBiz;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="phone">电话</param>
        /// <param name="code">验证码</param>
        public void SmsUserInfoRegister(string phone, string code)
        {
            WriteLog(phone, code);

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("code", code);
            var a = SendSMSCommon.SendSMSsingleAsync(SmsTemplate.SmsRegister, phone, dic, SmsSignNameTemplate.DefaultSignName);

        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="phone">电话</param>
        /// <param name="code">验证码</param>
        public void SmsLogin(string phone, string code)
        {
            WriteLog(phone, code);

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("code", code);
            var a = SendSMSCommon.SendSMSsingleAsync(SmsTemplate.SmsRegister, phone, dic, SmsSignNameTemplate.DefaultSignName);
        }

        /// <summary>
        /// 写短线记录
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="code"></param>
        private void WriteLog(string phone, string code)
        {
            Task.Run(() =>
            {
                SmsLog sms = new SmsLog();
                sms.Code = code;
                sms.CreateTime = DateTime.Now;
                sms.IsSend = 1;
                sms.Phone = phone;

                _smsLogBiz.Insert(sms);
            });
        }
    }
}
