using Exam.Admin.Models;
using Exam.Core.Utils;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Admin.Models
{
    public class UserExamClassVM
    {
        public int V { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; } 
        /// <summary>
        /// 分页
        /// </summary>
        public Paging<UserExamClass> Paging { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public Paging<UserExamProblem> DetailPaging { get; set; }

        //查询条件
        public string QueryProblemTitle{ get; set; } 
        public int QueryUserInfoId{ get; set; }
    }
}