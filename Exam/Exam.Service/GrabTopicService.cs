using Exam.Core.Utils;
using Exam.IService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Exam.Core.Infrastructure;
using Exam.Business;
using System.Threading.Tasks;

namespace Exam.Service
{
    /// <summary>
    /// 抓取服务
    /// </summary>
    public class GrabTopicService : IGrabTopicService
    {
        public static CookieContainer cc = new CookieContainer();//维持cookie或Session

        /// <summary>
        /// The user biz
        /// </summary>
        private IProblemLibraryBusiness _ProblemLibraryBiz;

        public GrabTopicService(IProblemLibraryBusiness ProblemLibraryBiz)
        {
            _ProblemLibraryBiz = ProblemLibraryBiz;
        }
        //private readonly ProblemLibraryService _ProblemLibraryService = EngineContext.Current.Resolve<ProblemLibraryService>();
        /// <summary>
        /// 注会Cookie
        /// </summary>
        public static string zkCookie = "";
        /// <summary>
        /// 中级cookie
        /// </summary>
        public static string zjCookie = "";
        /// <summary>
        /// 初级cookie
        /// </summary>
        public static string cjCookie = "";
        /// <summary>
        /// 从业
        /// </summary>
        public static string cyCookie = "";
        /// <summary>
        /// 税务师cookie
        /// </summary>
        public static string zsCookie = "";

        //public static string httpHead = "";
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
                    Task.Run(() =>
                    {
                    CPA("http://zk.0373kj.com");
                    });
                    break;
                case "初级":
                    Task.Run(() =>
                    {
                        CJ("http://cj.0373kj.com");
                    });
                    break;
                case "中级":
                    Task.Run(() =>
                    {
                        ZJ("http://zj.0373kj.com");
                    });
                    break;
                case "税务师":
                    Task.Run(() =>
                    {
                        SWS("http://zs.0373kj.com");
                    });
                    break;
                case "从业":
                    Task.Run(() =>
                    {
                        CY("http://cy.0373kj.com");
                    });
                    break;

                default:
                    break;
            }
            return true;
        }
        /// <summary>
        /// 初级
        /// </summary>
        /// <param name="httpHead"></param>
        public void CJ(string httpHead)
        {
            //获取token
            var url1 = httpHead + "/Oper/UserLogin?phone=18707928905&password=123456&accountType=0";
            var url2 = httpHead + "/Home/index.php";
            //获取分类详细题目
            var url3 = httpHead + "/Topic/GetQuestionList?sctid={0}&pagesize=1000&page=1";
            //获取登录cookie
            var url4 = httpHead + "/Oper/UserLogin";
            var url5 = httpHead + "/Subjects/GetSectionList";
            var primary = new PrimaryService();
            cjCookie = primary.GetToken(url1, url4);
            if (!string.IsNullOrWhiteSpace(cjCookie))
            {
                //
                var indexHtml = GetHtml(url2, "logoutnum=8;urltimestamp=201818;LogonAccount=62G26;");
                //先获取中级的科目
                var subList = IntermediateService.GetZJKeMu(indexHtml);
                //遍历科目列表，取得列表对应的章节
                for (int i = 0; i < subList.Count; i++)
                {
                    System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
                    long t = (DateTime.Now.Ticks - startTime.Ticks) / 10000;
                    string newurl = url5 + "?_=" + t;
                    var str = GetHtml(newurl + "&pageindex=1&type=0&courseId=" + (i + 1 + 2) + "&pagesize=1000", "LogonAccount=8368000;");
                    var model = JsonHelper.ParseFormJson<SectionVM>(str);
                    foreach (SectionModel item in model.ds)
                    {
                        //这里得到章节里所有的题目
                        string topicListStr = GetHtml(string.Format(url3, item.c_sctid), "").Replace("null", "0");
                        //这里执行插入数据库的操作
                        var model1 = JsonHelper.ParseFormJson<TopicListVM>(topicListStr);

                        foreach (var im in model1.ds)
                        {
                            _ProblemLibraryBiz.Insert(new Domain.Model.ProblemLibrary
                            {
                                CTime = DateTime.Now,
                                c_answer = im.c_answer,
                                c_assistantsortid = im.c_assistantsortid,
                                c_MistakeNum = im.c_MistakeNum,
                                c_options = im.c_options,
                                c_qid = im.c_qid,
                                c_qustiontype = im.c_questiontype,
                                c_score = im.c_score,
                                c_sctid = im.c_sctid,
                                c_sortid = decimal.Parse(im.c_sortid),
                                c_tips = im.c_tips,
                                isVideo = im.isVideo,
                                Title = im.c_text,
                                IsUse = 0,
                                BelongId = 1001,
                                c_sctname = item.c_sctname,
                                SubjectInfoTitle = subList[i].Title.ToString().Trim()
                            });
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 中级
        /// </summary>
        /// <param name="httpHead"></param>
        public void ZJ(string httpHead)
        {
            //获取token
            var url1 = httpHead + "/Account/UserLogin?Account=8368000";
            var url2 = httpHead + "/Home/index.php";
            //获取分类详细题目
            var url3 = httpHead + "/Topic/GetQuestionList?sctid={0}&pagesize=1000&page=1";
            //获取登录cookie
            var url4 = httpHead + "/Account/UserLogin";
            var url5 = httpHead + "/Subjects/GetSectionList";
            if (GetToken(url1, url4))
            {
                //
                var indexHtml = GetHtml(url2, "logoutnum=8;urltimestamp=201818;LogonAccount=8368000;");
                //先获取中级的科目
                var subList = IntermediateService.GetZJKeMu(indexHtml);
                //遍历科目列表，取得列表对应的章节
                for (int i = 0; i < subList.Count; i++)
                {
                    System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
                    long t = (DateTime.Now.Ticks - startTime.Ticks) / 10000;
                    string newurl = url5 + "?_=" + t;
                    var str = GetHtml(newurl + "&pageindex=1&type=0&courseId=" + (i + 1) + "&pagesize=1000", "LogonAccount=8368000;");
                    var model = JsonHelper.ParseFormJson<SectionVM>(str);
                    foreach (SectionModel item in model.ds)
                    {
                        //这里得到章节里所有的题目
                        string topicListStr = GetHtml(string.Format(url3, item.c_sctid), "").Replace("null", "0"); 
                        //这里执行插入数据库的操作
                        var model1 = JsonHelper.ParseFormJson<TopicListVM>(topicListStr);

                        foreach (var im in model1.ds)
                        {
                            _ProblemLibraryBiz.Insert(new Domain.Model.ProblemLibrary
                            {
                                CTime = DateTime.Now,
                                c_answer = im.c_answer,
                                c_assistantsortid = im.c_assistantsortid,
                                c_MistakeNum = im.c_MistakeNum,
                                c_options = im.c_options,
                                c_qid = im.c_qid,
                                c_qustiontype = im.c_questiontype,
                                c_score = im.c_score,
                                c_sctid = im.c_sctid,
                                c_sortid = decimal.Parse(im.c_sortid),
                                c_tips = im.c_tips,
                                isVideo = im.isVideo,
                                Title = im.c_text,
                                IsUse = 0,
                                BelongId = 1002,
                                c_sctname = item.c_sctname,
                                SubjectInfoTitle = subList[i].Title.ToString().Trim()
                            });
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 注会
        /// </summary>
        public void CPA(string httpHead)
        {

            //获取token
            var url1 = httpHead + "/Account/UserLogin?Account=18707928905&WeiXinOpenId=";
            //获取科目列表
            var url2 = httpHead + "/Subjects/Chapter.php?tid=0&t=" + DateTime.Now.ToString("yyyyMMddhhmmss");
            //获取分类详细题目
            var url3 = httpHead + "/Topic/GetQuestionList?sctid={0}&pagesize=1000&page=1";
            //获取登录cookie
            var url4 = httpHead + "/Account/UserLogin";

            var url5 = httpHead + "/Subjects/GetSectionList";
            if (GetToken(url1, url4))
            {
                //获取科目列表
                var subList = GetSubjectsList(url2).ToList();

                //subList[i].Title.ToString().Trim(); 科目
                //遍历科目列表，取得列表对应的章节
                for (int i = 0; i < subList.Count; i++)
                {
                    System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
                    long t = (DateTime.Now.Ticks - startTime.Ticks) / 10000;
                    string newurl = url5 + "?_=" + t;
                    var str = GetHtml(newurl + "&pageindex=1&type=0&courseId=" + (i + 1) + "&pagesize=1000", "LogonAccount=18707928905;");
                    //这里得到科目章节
                    var model = JsonHelper.ParseFormJson<SectionVM>(str);
                    foreach (SectionModel item in model.ds)
                    {
                        //这里得到章节里所有的题目
                        string topicListStr = GetHtml(string.Format(url3, item.c_sctid), "").Replace("null", "0"); ;
                        //这里执行插入数据库的操作
                        var model1 = JsonHelper.ParseFormJson<TopicListVM>(topicListStr);

                        foreach (var im in model1.ds)
                        {
                            _ProblemLibraryBiz.Insert(new Domain.Model.ProblemLibrary
                            {
                                CTime = DateTime.Now,
                                c_answer = im.c_answer,
                                c_assistantsortid = im.c_assistantsortid,
                                c_MistakeNum = im.c_MistakeNum,
                                c_options = im.c_options,
                                c_qid = im.c_qid,
                                c_qustiontype = im.c_questiontype,
                                c_score = im.c_score,
                                c_sctid = im.c_sctid,
                                c_sortid = decimal.Parse(im.c_sortid),
                                c_tips = im.c_tips,
                                isVideo = im.isVideo,
                                Title = im.c_text,
                                IsUse = 0,
                                BelongId = 1000,
                                c_sctname = item.c_sctname,
                                SubjectInfoTitle = subList[i].Title.ToString().Trim()
                            });
                        }
                    }

                }
            }

        }


        /// <summary>
        /// 从业
        /// </summary>
        public void CY(string httpHead)
        {
            //获取token
            var url1 = httpHead + "/Account/UserLogin?Account=18707928905&WeiXinOpenId=";
            //获取科目列表
            var url2 = httpHead + "/Home/index.php";
            //获取分类详细题目
            var url3 = httpHead + "/Topic/GetQuestionList?sctid={0}&pagesize=1000&page=1";
            //获取登录cookie
            var url4 = httpHead + "/Account/UserLogin";

            var url5 = httpHead + "/Subjects/GetSectionList";
            var primary = new PrimaryService();
            cyCookie = primary.GetToken(url1, url4);
            if (!string.IsNullOrWhiteSpace(cyCookie))
            {
                //获取科目列表
                var indexHtml = GetHtml(url2, "logoutnum=8;urltimestamp=201818;LogonAccount=62G26;");
                //先获取中级的科目
                var subList = IntermediateService.GetZJKeMu(indexHtml);
                //subList[i].Title.ToString().Trim(); 科目
                //遍历科目列表，取得列表对应的章节
                for (int i = 0; i < 1; i++)
                {
                    System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
                    long t = (DateTime.Now.Ticks - startTime.Ticks) / 10000;
                    string newurl = url5 + "?_=" + t;
                    var str = GetHtml(newurl + "&pageindex=1&type=0&courseId=" + (i + 1) + "&pagesize=1000", "LogonAccount=18707928905;");
                    //这里得到科目章节
                    var model = JsonHelper.ParseFormJson<SectionVM>(str);
                    foreach (SectionModel item in model.ds)
                    {
                        //这里得到章节里所有的题目
                        string topicListStr = GetHtml(string.Format(url3, item.c_sctid), "").Replace("null", "0");
                        //这里执行插入数据库的操作
                        var model1 = JsonHelper.ParseFormJson<TopicListVM>(topicListStr);

                        foreach (var im in model1.ds)
                        {
                            _ProblemLibraryBiz.Insert(new Domain.Model.ProblemLibrary
                            {
                                CTime = DateTime.Now,
                                c_answer = im.c_answer,
                                c_assistantsortid = im.c_assistantsortid,
                                c_MistakeNum = im.c_MistakeNum,
                                c_options = im.c_options,
                                c_qid = im.c_qid,
                                c_qustiontype = im.c_questiontype,
                                c_score = im.c_score,
                                c_sctid = im.c_sctid,
                                c_sortid = decimal.Parse(im.c_sortid),
                                c_tips = im.c_tips,
                                isVideo = im.isVideo,
                                Title = im.c_text,
                                IsUse = 0,
                                BelongId = 1001,
                                c_sctname = item.c_sctname,
                                SubjectInfoTitle = subList[i].Title.ToString().Trim()
                            });
                        }
                    }

                }
            }

        }




        /// <summary>
        /// 税务师
        /// </summary>
        /// <param name="httpHead"></param>
        public void SWS(string httpHead)
        {
            //获取token
            var url1 = httpHead + "/Account/UserLogin?phone=18707928905&password=123456&accountType=0";
            //获取科目列表
            var url2 = httpHead + "/Subjects/Chapter.php?tid=0&t=" + DateTime.Now.ToString("yyyyMMddhhmmss");
            //获取分类详细题目
            var url3 = httpHead + "/Topic/GetQuestionList?sctid={0}&pagesize=1000&page=1";
            //获取登录cookie
            var url4 = httpHead + "/Account/UserLogin";

            var url5 = httpHead + "/Subjects/GetSectionList";
            var primary = new PrimaryService();
            zsCookie = primary.GetToken(url1, url4);
            if (!string.IsNullOrWhiteSpace(zsCookie))
            {
                //获取科目列表
                var subList = GetSubjectsList(url2).ToList();

                //subList[i].Title.ToString().Trim(); 科目
                //遍历科目列表，取得列表对应的章节
                for (int i = 0; i < subList.Count; i++)
                {
                    System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
                    long t = (DateTime.Now.Ticks - startTime.Ticks) / 10000;
                    string newurl = url5 + "?_=" + t;
                    var str = GetHtml(newurl + "&pageindex=1&type=0&courseId=" + (i + 1) + "&pagesize=1000", "LogonAccount=18707928905;");
                    //这里得到科目章节
                    var model = JsonHelper.ParseFormJson<SectionVM>(str);
                    foreach (SectionModel item in model.ds)
                    {
                        //这里得到章节里所有的题目
                        string topicListStr = GetHtml(string.Format(url3, item.c_sctid), "").Replace("null", "0"); ;
                        //这里执行插入数据库的操作
                        var model1 = JsonHelper.ParseFormJson<TopicListVM>(topicListStr);

                        foreach (var im in model1.ds)
                        {
                            _ProblemLibraryBiz.Insert(new Domain.Model.ProblemLibrary
                            {
                                CTime = DateTime.Now,
                                c_answer = im.c_answer,
                                c_assistantsortid = im.c_assistantsortid,
                                c_MistakeNum = im.c_MistakeNum,
                                c_options = im.c_options,
                                c_qid = im.c_qid,
                                c_qustiontype = im.c_questiontype,
                                c_score = im.c_score,
                                c_sctid = im.c_sctid,
                                c_sortid = decimal.Parse(im.c_sortid),
                                c_tips = im.c_tips,
                                isVideo = im.isVideo,
                                Title = im.c_text,
                                IsUse = 0,
                                BelongId = 1004,
                                c_sctname = item.c_sctname,
                                SubjectInfoTitle = subList[i].Title.ToString().Trim()
                            });
                        }
                    }

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
            if (url.Contains("zk.0373kj"))
            {
                zkCookie = cookieHeader;
            }
            else if (url.Contains("zj.0373kj"))
            {
                zjCookie = cookieHeader;
            }

            //HttpContext.Current.Application.Lock();
            //HttpContext.Current.Application["cookieHeader"] = cookieHeader;
            //HttpContext.Current.Application.UnLock();

            return true;
        }
        /// <summary>
        /// 获取连接的返回值
        /// </summary>
        /// <param name="url"></param>
        /// <param name="addCookie"></param>
        /// <returns></returns>
        public static string GetHtml(string url, string addCookie)
        {
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(url);
            string cookhead = "";

            if (url.Contains("zk.0373kj"))
            {
                cookhead = zkCookie;
            }
            else if (url.Contains("zj.0373kj"))
            {
                cookhead = zjCookie;
            }
            else if (url.Contains("cj.0373kj"))
            {
                cookhead = cjCookie;
            }
            else if (url.Contains("zs.0373kj"))
            {
                cookhead = zsCookie;
            }
            else if (url.Contains("cy.0373kj"))
            {
                cookhead = cyCookie;
            }
            request1.Method = "GET";
            request1.Headers.Add("cookie:" + addCookie + cookhead);
            request1.KeepAlive = true;
            request1.AllowAutoRedirect = true;
            HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();
            Stream stream2 = response1.GetResponseStream();//获得回应的数据流
                                                           //将数据流转成 String
            return new StreamReader(stream2, System.Text.Encoding.UTF8).ReadToEnd();
        }
        /// <summary>
        /// 获取注会科目列表
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static IEnumerable<LinkAndTile> GetSubjectsList(string url)
        {
            string result1 = GetHtml(url, "");
            var match = Regex.Matches(result1, @"<a href=.*?>([\s\S]*?)</a>");
            var subList = new List<LinkAndTile>();
            foreach (Match m in match)
            {
                var link = Regex.Match(m.Value, "href=.*?>").Value.Replace("href=\"", "")
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
    /// 题目列表
    /// </summary>
    public class TopicListVM
    {
        public List<TopicVM> ds { get; set; }
        public List<Num> ds1 { get; set; }
    }
    /// <summary>
    /// 科目列表页面
    /// </summary>
    public class LinkAndTile
    {
        public string Link { get; set; }
        public string Title { get; set; }
    }
    /// <summary>
    /// 章节页面
    /// </summary>
    public class SectionVM
    {
        public List<SectionModel> ds { get; set; }
        public List<Num> ds1 { get; set; }
    }
    /// <summary>
    /// 题目
    /// </summary>
    public class TopicVM
    {
        /// <summary>
        /// 题目编号
        /// </summary>
        public int c_qid { get; set; }
        /// <summary>
        /// 章节编号
        /// </summary>
        public int c_sctid { get; set; }
        /// <summary>
        /// 问题类型，目前还不知道是啥规则
        /// </summary>
        public int c_questiontype { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string c_sortid { get; set; }
        /// <summary>
        /// 助理排序
        /// </summary>
        public string c_assistantsortid { get; set; }
        /// <summary>
        /// 问题
        /// </summary>
        public string c_text { get; set; }
        /// <summary>
        /// 选项|分割
        /// </summary>
        public string c_options { get; set; }
        /// <summary>
        /// 正确答案，不是，分割 就是|分割
        /// </summary>
        public string c_answer { get; set; }
        /// <summary>
        /// 解释
        /// </summary>
        public string c_tips { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public string c_score { get; set; }
        /// <summary>
        /// 是否视频，为0则不是
        /// </summary>
        public int isVideo { get; set; }
        /// <summary>
        /// 错误次数，不知道有啥用
        /// </summary>
        public int c_MistakeNum { get; set; }
        //      "c_qid": 20609,
        //"c_sctid": 366,
        //"c_questiontype": 4,
        //"c_sortid": 1.0,
        //"c_assistantsortid": "0",
        //"c_text": "下列关于税收法律的说法中，不正确的是（　）。",
        //"c_options": "税法是依据《宪法》的原则制定的|当涉及税收征纳关系的问题时，一般应以民法的规范为准则。|当税法的某些规范同民法的规范基本相同时，税法一般援引民法条款|税收法律关系中居于领导地位的一方总是国家",
        //"c_answer": "2",
        //"c_tips": "当涉及税收征纳关系的问题时，一般应以税法的规范为准则。",
        //"c_score": 1.0,
        //"isVideo": 0,
        //"c_MistakeNum": 30
    }
    /// <summary>
    /// 章节
    /// </summary>
    public class SectionModel
    {
        public string c_sctid { get; set; }
        public string c_sctname { get; set; }
    }
    /// <summary>
    /// 数量
    /// </summary>
    public class Num
    {
        public string num { get; set; }
    }
}
