using Exam.Core.Utils;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Admin.Models
{
    public class ProblemCategoryVM
    {
        public int V { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 菜单信息
        /// </summary>
        public ProblemCategory ProblemCategory { get; set; }
        /// <summary>
        /// 菜单集合
        /// </summary>
        public List<ProblemCategory> ProblemCategorys { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public Paging<ProblemCategory> Paging { get; set; }

        //查询条件
        public string QueryName { get; set; } 
    }
}