using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Service
{
    /// <summary>
    /// 抓取初级题库服务
    /// </summary>
    public class PrimaryService
    {
        public static CookieContainer cc = new CookieContainer();//维持cookie或Session
        public string GetToken(string url,string url1) {
            //formData用于保存提交的信息
            string formData = "";
            if (formData.Length > 0)
                formData = formData.Substring(0, formData.Length - 1); //去除最后一个 '&'
            //把提交的信息转码（post提交必须转码）
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(formData);

            //开始创建请求
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";    //提交方式：post
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; SV1; .NET CLR 2.0.1124)";
            request.AllowAutoRedirect = true;
            request.KeepAlive = true;

            Stream newStream = request.GetRequestStream();
            newStream.Write(data, 0, data.Length);//将请求的信息写入request
            newStream.Close();
            request.CookieContainer = cc;

            //向服务器发送请求
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //获得Cookie 保存到Appliction中
            return request.CookieContainer.GetCookieHeader(new Uri(url1));
        }
    }
}
