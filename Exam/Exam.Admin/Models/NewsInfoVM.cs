using Exam.Core.Utils;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Admin.Models
{
    public class NewsInfoVM: BaseImgInfoVM
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public NewsInfo NewsInfo { get; set; }

        /// <summary>
        /// 资讯分类列表
        /// </summary>
        public List<NewsCategory> NewsCategories { get; set; }

        /// <summary>
        /// 用户分页
        /// </summary>
        public Paging<NewsInfo> Paging { get; set; }
        public string QueryName { get; set; }
    }
}