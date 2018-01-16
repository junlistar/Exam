﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 用户答题记录表
    /// </summary>
    public class UserInfoAnswerRecord: IAggregateRoot
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int UserInfoAnswerRecordId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserInfoId { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 考试标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 题目所属编号
        /// </summary>
        public int BelongId { get; set; }

        /// <summary>
        /// 章节分类
        /// </summary>
        public int ChapterId { get; set; }

        /// <summary>
        /// -创建时间
        /// </summary>
        public DateTime CTime{get;set;}

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UTime { get; set; }
    }
}