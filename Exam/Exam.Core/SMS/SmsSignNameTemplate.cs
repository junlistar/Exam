using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Core.SMS
{
    /// <summary>
    /// 短信签名模版
    /// </summary>
   public class SmsSignNameTemplate
    {
        /// <summary>
        /// 一生时光
        /// </summary>
        public static string DefaultSignName = ConfigurationManager.AppSettings["DefaultSignName"]==null ? "九润会计" : ConfigurationManager.AppSettings["DefaultSignName"];
    }
}
