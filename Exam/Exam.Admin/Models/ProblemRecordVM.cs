using Exam.Core.Utils;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Admin.Models
{
    public class ProblemRecordVM
    {
        public int V { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 实体信息
        /// </summary>
        public UserInfoAnswerRecord ProblemRecord { get; set; }
        /// <summary>
        /// 实体集合
        /// </summary>
        public List<ProblemRecord> ProblemRecords { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public Paging<UserInfoAnswerRecord> Paging { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public Paging<ProblemRecord> DetailPaging { get; set; }

        //查询条件
        public string QueryProblemTitle{ get; set; } 
        public int QueryUserInfoId{ get; set; }
    }
}