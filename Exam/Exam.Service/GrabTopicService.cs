using Exam.Core.Utils;
using Exam.IService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public static string httpHead = "http://zk.0373kj.com";
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
            var url1 = httpHead+"/Account/UserLogin?Account=18707928905&WeiXinOpenId=";
            //获取科目列表
            var url2 = httpHead + "/Subjects/Chapter.php?tid=0&t=" + DateTime.Now.ToString("yyyyMMddhhmmss");
            //获取分类详细题目
            var url3 = httpHead + "/Topic/GetQuestionList?sctid={0}&pagesize=10&page=1";
            //获取登录cookie
            var url4 = httpHead + "/Account/UserLogin";

            var url5 = httpHead + "/Subjects/GetSectionList";
            if (GetToken(url1, url4))
            {
                //获取科目列表
                var subList = GetSubjectsList(url2).ToList();
                //遍历科目列表，取得列表对应的
                foreach (LinkAndTile item in subList)
                {
                    //DateTime.Now.Subtract(DateTime.Parse("1970-1-1")).TotalMilliseconds
                    var str = GetHtml1(url5, "logoutnum=20; urltimestamp=2018120; LogonAccount=18707928905;");
                    //pageindex=1&type=0&courseId =1&pagesize=10


                }
            }

        }
        /// <summary>
        /// 获取token
        /// </summary>
        public static bool GetToken(string url, string url4)
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


        public static string GetHtml(string url,string addCookie) {

            //DateTime.Now.Subtract(DateTime.Parse("1970-1-1")).TotalMilliseconds
            //var str = GetHtml(item.Link, "logoutnum=20; urltimestamp=2018120; LogonAccount=18707928905;");
            //pageindex=1&type=0&courseId =1&pagesize=10
            //http://zk.0373kj.com/Subjects/GetSectionList?_=1516768958691




            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(url);
            //string cookhead = HttpContext.Current.Application["cookieHeader"].ToString();
            string cookhead = cookie;
            request1.Method = "GET";
            request1.Headers.Add("cookie:" + addCookie + cookhead);
            request1.KeepAlive = true;
            request1.AllowAutoRedirect = true;

            HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();
            Stream stream2 = response1.GetResponseStream();//获得回应的数据流
                                                           //将数据流转成 String
            return new StreamReader(stream2, System.Text.Encoding.UTF8).ReadToEnd();
        }

        public static string GetHtml1(string url, string addCookie)
        {

            //DateTime.Now.Subtract(DateTime.Parse("1970-1-1")).TotalMilliseconds
            //var str = GetHtml(item.Link, "logoutnum=20; urltimestamp=2018120; LogonAccount=18707928905;");
            //pageindex=1&type=0&courseId =1&pagesize=10
            //http://zk.0373kj.com/Subjects/GetSectionList?_=1516768958691
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (DateTime.Now.Ticks - startTime.Ticks) / 10000;
            url += "?_=" + t;
            //formData用于保存提交的信息
            string formData = "pageindex=1&type=0&courseId =1&pagesize=10";


//        Accept: */*
//Accept-Encoding:gzip, deflate
//Accept-Language:zh-CN,zh;q=0.9
//Content-Length:63
//Content-Type:application/x-www-form-urlencoded
//Cookie:ASP.NET_SessionId=32fttu3g21cgthsuh5bsholi; urltimestamp=20181; usertoken=da57c562c956a502409f3403f3feec872422415039
//Host:zk.0373kj.com
//Origin:http://zk.0373kj.com
//Proxy-Connection:keep-alive
//Referer:http://zk.0373kj.com/Subjects/List.php?scid=1&tid=0&t=201801241311
//User-Agent:Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36
//X-Requested-With:XMLHttpRequest


            //if (formData.Length > 0)
            //    formData = formData.Substring(0, formData.Length - 1); //去除最后一个 '&'

            //把提交的信息转码（post提交必须转码）
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(formData);

            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(url);
            //string cookhead = HttpContext.Current.Application["cookieHeader"].ToString();
            string cookhead = cookie;
            request1.Method = "POST";
            request1.Accept = "*/*";
            request1.ContentLength = data.Length;
            request1.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36";
            request1.Headers.Add("cookie:" + cookhead+ ";urltimestamp=20181");
            request1.KeepAlive = true;
            request1.AllowAutoRedirect = true;
            Stream newStream = request1.GetRequestStream();
            newStream.Write(data, 0, data.Length);//将请求的信息写入request
            newStream.Close();
            HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();
            Stream stream2 = response1.GetResponseStream();//获得回应的数据流
                                                           //将数据流转成 String
            return new StreamReader(stream2, System.Text.Encoding.UTF8).ReadToEnd();
        }

        /// <summary>
        /// 获取科目列表
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static IEnumerable<LinkAndTile> GetSubjectsList(string url)
        {
            string result1 = GetHtml(url,"");
            var match = Regex.Matches(result1, @"<a href=.*?>([\s\S]*?)</a>");
            var subList = new List<LinkAndTile>();
            foreach (Match m in match)
            {
                var link = httpHead + Regex.Match(m.Value, "href=.*?>").Value.Replace("href=\"", "")
                    .Replace("\">", "").Replace("/r", "").Replace("/n", "").Trim();
                var title = HttpHelp.ClearHtml(m.Value);
                subList.Add(new LinkAndTile()
                {
                    Link = link,
                    Title = title
                });
            }
            return subList;
        }

    }
    /// <summary>
    /// 科目列表页面
    /// </summary>
    public class LinkAndTile
    {
        public string Link { get; set; }
        public string Title { get; set; }
    }
}
