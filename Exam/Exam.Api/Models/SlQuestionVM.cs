using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Api.Models
{
    /// <summary>
    /// 查询问题
    /// </summary>
    public class SlQuestionVM:PageDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 是否热门
        /// </summary>
        public int IsHot { get; set; }

        /// <summary>
        /// 是是否置顶
        /// </summary>

        public int IsTop { get; set; }
    }
}