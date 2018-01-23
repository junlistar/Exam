using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.IService
{
    /// <summary>
    /// 题库抓取服务接口
    /// </summary>
    public interface IGrabTopicService
    {
        /// <summary>
        /// 抓取题库服务
        /// </summary>
        /// <param name="title">需要抓取的类别，初级，中级，注会，注税</param>
        /// <returns></returns>
        bool StartGrab(string title);
    }
}
