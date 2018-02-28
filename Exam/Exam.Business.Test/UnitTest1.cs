using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exam.Core.Infrastructure;
using Exam.Domain.Model;
using System.Net;
using System.Text;
using System.Collections;
using System.IO;
using System.Web;
using Exam.IService;

namespace Exam.Business.Test
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IUserInfoBusiness _userInfo = EngineContext.Current.Resolve<IUserInfoBusiness>();
        private readonly IQuestionBusiness _questionInfo = EngineContext.Current.Resolve<IQuestionBusiness>();

        private readonly IGrabTopicService _grabTopic = EngineContext.Current.Resolve<IGrabTopicService>();
        [TestMethod]
        public void TestGrab() {
            //var bl = _grabTopic.StartGrab("注会");
            var bl = _grabTopic.StartGrab("初级");

            if (bl)
            {
                string msg = "抓取程序已启动，请稍后查看内容库！";
            }
        }

        [TestMethod]
        public void AddUserTest()
        {
            Random rd = new Random();


            UserInfo userInfo = new UserInfo();
            userInfo.NikeName = "张大胆" +rd.Next(99999);
            userInfo.Gender = rd.Next(100) > 50 ? 1 : 0;
            userInfo.IsEnable= 1;
            userInfo.CTime = DateTime.Now;

           var addResult = _userInfo.Insert(userInfo);

             
        }
        [TestMethod]
        public void GetQuestion()
        {
            int id = 1000;

            var getResult = _questionInfo.GetById(id);

            try
            {
                var list = getResult;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [TestMethod]
        public void GetProblem()
        {
            int id = 1000;
             
 
            try
            { 
                //var loginResult = Exam.Core.Utils.HttpHelp.HttpGet("http://zk.0373kj.com/Account/UserLogin?Account=18707928905&WeiXinOpenId=");
                //var questionResult = Exam.Core.Utils.HttpHelp.HttpGet("http://zk.0373kj.com/Topic/GetQuestionList?sctid=282&pagesize=10&page=1");

                var url1 = "http://zk.0373kj.com/Account/UserLogin?Account=18707928905&WeiXinOpenId=";
                var url2 = "http://zk.0373kj.com/Topic/GetQuestionList?sctid=282&pagesize=10&page=1";

                var webClient = new WebClient { Encoding = Encoding.UTF8 };
                  
                var  result1 = UnitTest1.PostAndGetHTML(url1,new Hashtable());
                var  result2 = UnitTest1.ReGetHtml(url2);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// 实现登录
        /// </summary>
        /// <param name="targetURL">请求的路径，必须是实现登录的路径(*)</param>
        /// <param name="cc">用于维持cookies Or Session</param>
        /// <param name="param">Post提交的信息（用户名，密码）</param>
        /// <returns>html page</returns>
        public static CookieContainer cc = new CookieContainer();//维持cookie或Session

        public static string cookie = "";
        public static string PostAndGetHTML(string targetURL, Hashtable param)
        {

            //formData用于保存提交的信息
            string formData = "";
            foreach (DictionaryEntry de in param)
            {
                formData += de.Key.ToString() + "=" + de.Value.ToString() + "&";
            }

            if (formData.Length > 0)
                formData = formData.Substring(0, formData.Length - 1); //去除最后一个 '&'

            //把提交的信息转码（post提交必须转码）
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(formData);

            //开始创建请求
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targetURL);
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
            string cookieHeader = request.CookieContainer.GetCookieHeader(new Uri("http://zk.0373kj.com/Account/UserLogin"));
            cookie = cookieHeader;
            //HttpContext.Current.Application.Lock();
            //HttpContext.Current.Application["cookieHeader"] = cookieHeader;
            //HttpContext.Current.Application.UnLock();

            return "OK";
        }

        /// <summary>
        /// 访问其他页面
        /// </summary>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        public static string ReGetHtml(string strUrl)
        {
            //第二次请求
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(strUrl);
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
            return result1;
        }
    }
}
