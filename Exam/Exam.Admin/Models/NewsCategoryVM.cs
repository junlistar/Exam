using Exam.Core.Utils;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Admin.Models
{
    public class NewsCategoryVM
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public NewsCategory NewsCategory { get; set; }
        /// <summary>
        /// 用户分页
        /// </summary>
        public Paging<NewsCategory> Paging { get; set; }
        public string QueryName { get; set; }
    }
}