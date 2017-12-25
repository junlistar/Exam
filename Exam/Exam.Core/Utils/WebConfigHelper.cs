using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Core.Utils
{
    /// <summary>
    /// 读取WebConfig中的连接的字符串和其它的链接信息
    /// </summary>
    public static class WebConfigHelper
    {
        /// <summary>
        ///  获取应用程序配置项(路劲存放)
        /// </summary>
        /// <param name="key">传递的key</param>
        /// <returns></returns>
        public static string GetAppSettingsInfo(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// 获取连接数据库的连接字符串
        /// </summary>
        /// <param name="key">传递的key</param>
        /// <returns></returns>
        public static string GetConnectionStringsInfo(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
    }
}
