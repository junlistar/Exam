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
        public static string YssgDefaultSignName = ConfigurationManager.AppSettings["YssgDefaultSignName"]==null ? "一生时光" : ConfigurationManager.AppSettings["YssgDefaultSignName"];

        /// <summary>
        /// 深圳利德行
        /// </summary>
        public static string LeadSignName = ConfigurationManager.AppSettings["LeadSignName"] ==null? "深圳得德行":ConfigurationManager.AppSettings["LeadSignName"];

        /// <summary>
        /// 应急特训营
        /// </summary>
        public static string SpecialTrainingCampSignName = ConfigurationManager.AppSettings["SpecialTrainingCampSignName"] ==null? "应急特训营" : ConfigurationManager.AppSettings["SpecialTrainingCampSignName"];
  	
  	    /// <summary>
        /// 最美深圳V最美一刻
        /// </summary>
        public static string BeautifulShenZhenSignName = ConfigurationManager.AppSettings["BeautifulShenZhenSignName"] == null ? "最美深圳V最美一刻" : ConfigurationManager.AppSettings["BeautifulShenZhenSignName"];

        /// <summary>
        /// 羞羞的礼物(迎新活动)
        /// </summary>
        public static string NewYear2018 = ConfigurationManager.AppSettings["NewYear2018"] == null ? "圣诞元旦好礼不断" : ConfigurationManager.AppSettings["NewYear2018"];

    }
}
