using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Api.Models
{
    public class NewsVM : PageDto
    {
        /// <summary>
        ///消息分类
        /// </summary>
        public int NewsCategoryId { get; set; }

        /// <summary>
        /// 是否热门
        /// </summary>
        public int IsHot { get; set; }
    }
}