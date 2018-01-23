using Exam.IService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Exam.Service
{
    /// <summary>
    /// 抓取服务
    /// </summary>
    public class GrabTopicService : IGrabTopicService
    {
        public static CookieContainer cc = new CookieContainer();//维持cookie或Session

        public static string cookie = "";

        /// <summary>
        /// 抓取题库服务
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool StartGrab(string title)
        {
            switch (title)
            {
                case "注会":
                    //Task.Run(() =>
                    //{
                        CPA();
                    //});
                    break;
                default:
                    break;
            }
            return true;
        }
        /// <summary>
        /// 注会
        /// </summary>
        public void CPA()
        {
            
            //获取token
            var url1 = "http://zk.0373kj.com/Account/UserLogin?Account=18707928905&WeiXinOpenId=";
            //获取科目列表
            var url2 = "http://zk.0373kj.com/Subjects/Chapter.php?tid=0&t="+DateTime.Now.ToString("yyyyMMddhhmmss");
            //获取分类详细题目
            var url3 = "http://zk.0373kj.com/Topic/GetQuestionList?sctid={0}&pagesize=10&page=1";
            //获取登录cookie
            var url4 = "http://zk.0373kj.com/Account/UserLogin";
            if (GetToken(url1,url4))
            {
                //获取科目列表
                GetSubjectsList(url2);
            }

        }
        /// <summary>
        /// 获取token
        /// </summary>
        public static bool GetToken(string url,string url4)
        {

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
            string cookieHeader = request.CookieContainer.GetCookieHeader(new Uri(url4));
            cookie = cookieHeader;
            //HttpContext.Current.Application.Lock();
            //HttpContext.Current.Application["cookieHeader"] = cookieHeader;
            //HttpContext.Current.Application.UnLock();

            return true;
        }
        /// <summary>
        /// 获取科目列表
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool GetSubjectsList(string url) {
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(url);
            //string cookhead = HttpContext.Current.Application["cookieHeader"].ToString();
            string cookhead = cookie;
            request1.Method = "GET";
            request1.Headers.Add("cookie:" + cookhead);
            request1.KeepAlive = true;
            request1.AllowAutoRedirect = true;

            HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();
            Stream stream2 = response1.GetResponseStream();//获得回应的数据流
                                                           //将数据流转成 String
            string result1 = new StreamReader(stream2, System.Text.Encoding.UTF8).ReadToEnd();
            var match = Regex.Matches(result1, "<a.*?</a>");
            var subList = new List<string>();
            foreach (Match m in match)
            {
                subList.Add(m.Value);
            }
            return true;
        }
    }
}
