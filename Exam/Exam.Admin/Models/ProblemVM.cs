using Exam.Core.Utils;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Admin.Models
{
    public class ProblemVM
    {
        /// <summary>
        /// 刷新标识
        /// </summary>
        public int RefreshFlag { get; set; }

        public int V { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 题目标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 实体信息
        /// </summary>
        public Problem Problem { get; set; }
        /// <summary>
        ///实体集合
        /// </summary>
        public List<ProblemCategory> ProblemCategorys { get; set; }
        public List<Belong> Belongs { get; set; }
        public List<Chapter> Chapters { get; set; }
        public List<SubjectInfo> SubjectInfos { get; set; }

        /// <summary>
        /// 答案列表
        /// </summary>
        public List<Answer> AnswerList { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public Paging<Problem> Paging { get; set; }

        //查询条件
        public string QueryName { get; set; } 
        public int QueryBelongId { get; set; } 
        public int QueryChapterId { get; set; } 
        public int QuerySubjectInfoId { get; set; } 
        public int QueryProblemCategoryId { get; set; }
    }
}