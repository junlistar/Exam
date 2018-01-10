using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.IService
{
    /// <summary>
    /// 短信发送
    /// </summary>
    public  interface ISmsService
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="phone">电话</param>
        /// <param name="code">验证码</param>
        void SmsUserInfoRegister(string phone,string code);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="phone">电话</param>
        /// <param name="code">验证码</param>
        void SmsLogin(string phone, string code);
    }
}
