﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 问题记录表
    /// </summary>
    public class ProblemRecord: IAggregateRoot
    {
        /// <summary>
        /// 编号
        /// </summary>
       public virtual int ProblemRecordId { get; set; }

       /// <summary>
       /// 问题id
       /// </summary>
	   public virtual int ProblemId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 类别分类
        /// </summary>
        public virtual int ProblemCategoryId { get; set; }

        /// <summary>
        /// 正确答案
        /// </summary>
        public virtual string CorrectAnswer{get;set;}

        /// <summary>
        /// 错误答案
        /// </summary>
        public virtual string ErrorAnswer { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime UTime { get; set; }

        /// <summary>
        /// 1对 2错
        /// </summary>
        public virtual int YesOrNo { get; set; }

        public virtual string Analysis { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>

        public virtual int UserInfoId { get; set; }


        public virtual UserInfo UserInfo { get; set; }

        /// <summary>
        /// 问题记录表id
        /// </summary>

        public virtual int UserInfoAnswerRecordId { get; set; }

        public virtual ProblemCategory ProblemCategory { get; set; }

        public virtual List<AnswerRecord> AnswerRecordList { get; set; }


        
    }

    /// <summary>
    /// 用户答题统计实体
    /// </summary>
    public class UserPractiseReportModel : IAggregateRoot
    {
        public int UserInfoId { get; set; }
        public string Phone { get; set; }
        public string NickName { get; set; }
        public int totalCount { get; set; }
        public int rightCount { get; set; }
        public int wrongCount { get; set; } 
        public DateTime CTime { get; set; }
    }
    /// <summary>
    /// 题目统计实体
    /// </summary>
    public class ProblemPractiseReportModel : IAggregateRoot
    {
        public int ProblemId { get; set; }
        public int totalCount { get; set; }
        public int rightCount { get; set; }
        public int wrongCount { get; set; }
        public DateTime CTime { get; set; }
    }
}
