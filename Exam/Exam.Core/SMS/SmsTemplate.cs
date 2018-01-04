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
        /// 用户登录
        /// </summary>
        public static string SmsLogin = ConfigurationManager.AppSettings["SmsLogin"]==null ? "SMS_61060162" : ConfigurationManager.AppSettings["SmsLogin"];
        
        /// <summary>
        /// 发送QQ或者微信绑定时的验证码
        /// </summary>
        public static string SmsQQWeChatBinding = ConfigurationManager.AppSettings["SmsQQWeChatBinding"]==null ? "SMS_62360087" : ConfigurationManager.AppSettings["SmsQQWeChatBinding"];

        /// <summary>
        /// 跟用户发送密码
        /// </summary>
        public static string SmsSendPwd = ConfigurationManager.AppSettings["SmsSendPwd"]==null ? "SMS_62520138" : ConfigurationManager.AppSettings["SmsSendPwd"];

        /// <summary>
        /// 修改密码跟用户发送验证码
        /// </summary>
        public static string SmsUpdatePwd = ConfigurationManager.AppSettings["SmsUpdatePwd"]==null ? "SMS_61060158" : ConfigurationManager.AppSettings["SmsUpdatePwd"];

        /// <summary>
        /// 留下一百个理由发送验证码
        /// </summary>
        public static string SmsActivityLogin = ConfigurationManager.AppSettings["SmsActivityLogin"]==null ? "SMS_69850372" : ConfigurationManager.AppSettings["SmsActivityLogin"];

        /// <summary>
        /// 应急特训营活动页面发送短信
        /// </summary>
        public static string SmsSpecialTrainingCamp= ConfigurationManager.AppSettings["SmsSpecialTrainingCamp"] == null ? "SMS_70940201" : ConfigurationManager.AppSettings["SmsSpecialTrainingCamp"];

        /// <summary>
        /// 短信群发
        /// </summary>
        public static string SmsGroup = ConfigurationManager.AppSettings["SmsGroup"] == null ? "SMS_95135047" : ConfigurationManager.AppSettings["SmsGroup"];

        /// <summary>
        /// 食神评审团验证码
        /// </summary>
        public static string SmsContract = ConfigurationManager.AppSettings["SmsContract"] == null ? "SMS_105015055" : ConfigurationManager.AppSettings["SmsContract"];

        /// <summary>
        /// 羞羞的礼物短信验证码
        /// </summary>
        public static string SmsNewYearLogin = ConfigurationManager.AppSettings["SmsNewYearLogin"] == null ? "SMS_106480023" : ConfigurationManager.AppSettings["SmsNewYearLogin"];

        /// <summary>
        /// 预定餐厅成功发送短信
        /// </summary>
        public static string SmsBusinessSuc= ConfigurationManager.AppSettings["SmsBusinessSuc"] == null ? "SMS_118760014" : ConfigurationManager.AppSettings["SmsBusinessSuc"];

        /// <summary>
        /// 预定餐失败发送短信
        /// </summary>
        public static string SmsBusinessFail = ConfigurationManager.AppSettings["SmsBusinessFail"] == null ? "SMS_118785012" : ConfigurationManager.AppSettings["SmsBusinessFail"];
    }
}
 