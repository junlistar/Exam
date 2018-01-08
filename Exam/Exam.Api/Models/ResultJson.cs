using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Api.Models
{
    /// <summary>
    /// 分页
    /// </summary>
    public class ResultJson<T>
    {
        /// <summary>
        /// 数据
        /// </summary>
        public List<T> Data { get; set; }

        /// <summary>
        /// 总页数输出
        /// </summary>
        public int PCount { get; set; }
        /// <summary>
        /// 总记录数输出
        /// </summary>
        public int RCount { get; set; }
    }
}