using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using static Exam.Core.SMS.ALiYunSMS;

namespace Exam.Core.SMS
{
    public class SendSMSCommon
    {
        #region 发送单个短信

        #region 默认签名发送短信
        /// <summary>
        /// 异步
        /// </summary>
        /// <param name="templateCode">模版</param>
        /// <param name="liRecNum">单个电话</param>
        /// <param name="paramString">变量</param>
        /// <returns></returns>
        public static async Task<bool> SendSMSsingleAsync(string templateCode, string recNum, Dictionary<string, string> paramString)
        {
            SendSmsRequest re = new SendSmsRequest
            {
                TemplateCode = templateCode,
                PhoneNumbers = recNum,
                TemplateParam = (new JavaScriptSerializer()).Serialize(paramString),
            };

            var reslut = await Task.Run(() =>
            {
                return ALiYunSMS.SendSMS(re);
            });

            return reslut;
        }

        /// <summary>
        /// 同步
        /// </summary>
        /// <param name="templateCode">模版</param>
        /// <param name="liRecNum">单个电话</param>
        /// <param name="paramString">变量</param>
        public static void SendSMSsingle(string templateCode, string recNum, Dictionary<string, string> paramString)
        {
            SendSmsRequest re = new SendSmsRequest
            {
                TemplateCode = templateCode,
                PhoneNumbers = recNum,
                TemplateParam = (new JavaScriptSerializer()).Serialize(paramString),
            };
            ALiYunSMS.SendSMS(re);
        }
        #endregion

        #region 传签名发送短信
        /// <summary>
        /// 异步
        /// </summary>
        /// <param name="templateCode">模版</param>
        /// <param name="liRecNum">单个电话</param>
        /// <param name="paramString">变量</param>
        /// <param name="signName">签名</param>
        /// <returns></returns>
        public static async Task<bool> SendSMSsingleAsync(string templateCode, string recNum, Dictionary<string, string> paramString, string signName)
        {
            SendSmsRequest re = new SendSmsRequest
            {
                TemplateCode = templateCode,
                PhoneNumbers = recNum,
                TemplateParam =(new JavaScriptSerializer()).Serialize(paramString),
                SignName = signName
            };

            var reslut = await Task.Run(() =>
            {
                return ALiYunSMS.SendSMS(re);
            });

            return reslut;
        }

        /// <summary>
        /// 同步
        /// </summary>
        /// <param name="templateCode">模版</param>
        /// <param name="liRecNum">单个电话</param>
        /// <param name="paramString">变量</param>
        /// <param name="signName">签名</param>
        public static void SendSMSsingle(string templateCode, string recNum, Dictionary<string, string> paramString, string signName)
        {
            SendSmsRequest re = new SendSmsRequest
            {
                TemplateCode = templateCode,
                PhoneNumbers = recNum,
                TemplateParam = (new JavaScriptSerializer()).Serialize(paramString),
                SignName = signName
            };
            ALiYunSMS.SendSMS(re);
        }
        #endregion
        #endregion

        #region 群发短信

        #region 默认签名发送短信
        /// <summary>
        /// 异步
        /// </summary>
        /// <param name="templateCode">模版</param>
        /// <param name="liRecNum">电话集合</param>
        /// <param name="paramString">变量</param>
        /// <returns></returns>
        public static async Task<bool> SendSMMassAsync(string templateCode, List<string> liRecNum, Dictionary<string, string> paramString)
        {
            SendSmsRequest re = new SendSmsRequest
            {
                TemplateCode = templateCode,
                PhoneNumbers = liRecNum.ToString(),
                TemplateParam = (new JavaScriptSerializer()).Serialize(paramString),
            };

            var reslut = await Task.Run(() =>
            {
                return ALiYunSMS.SendSMS(re);
            });

            return reslut;
        }

        /// <summary>
        /// 同步
        /// </summary>
        /// <param name="templateCode">模版</param>
        /// <param name="liRecNum">电话集合</param>
        /// <param name="paramString">变量</param>
        public static void SendSMMass(string templateCode, List<string> liRecNum, Dictionary<string, string> paramString)
        {
            SendSmsRequest re = new SendSmsRequest
            {
                TemplateCode = templateCode,
                PhoneNumbers = liRecNum.ToString(),
                TemplateParam = (new JavaScriptSerializer()).Serialize(paramString),
            };
            ALiYunSMS.SendSMS(re);
        }
        #endregion

        #region 传签名发送短信
        /// <summary>
        /// 异步
        /// </summary>
        /// <param name="templateCode">模版</param>
        /// <param name="liRecNum">电话集合</param>
        /// <param name="paramString">变量</param>
        /// <param name="signName">签名</param>
        /// <returns></returns>
        public static async Task<bool> SendSMMassAsync(string templateCode, List<string> liRecNum, Dictionary<string, string> paramString, string signName)
        {
            SendSmsRequest re = new SendSmsRequest
            {
                TemplateCode = templateCode,
                PhoneNumbers = liRecNum.ToString(),
                TemplateParam = (new JavaScriptSerializer()).Serialize(paramString),
            };

            var reslut = await Task.Run(() =>
            {
                return ALiYunSMS.SendSMS(re);
            });

            return reslut;
        }

        /// <summary>
        /// 同步
        /// </summary>
        /// <param name="templateCode">模版</param>
        /// <param name="liRecNum">电话集合</param>
        /// <param name="paramString">变量</param>
        /// <param name="signName">签名</param>
        public static void SendSMMass(string templateCode, List<string> liRecNum, Dictionary<string, string> paramString, string signName)
        {
            SendSmsRequest re = new SendSmsRequest
            {
                TemplateCode = templateCode,
                PhoneNumbers = liRecNum.ToString(),
                TemplateParam = (new JavaScriptSerializer()).Serialize(paramString),
            };
            ALiYunSMS.SendSMS(re);
        }
        #endregion
        #endregion
    }
}
