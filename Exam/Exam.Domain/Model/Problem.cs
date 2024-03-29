﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 问题表
    /// </summary>
    public class Problem : IAggregateRoot
    {
        public virtual int ProblemId { get; set; }
        public virtual string Title { get; set; }
        public virtual int ProblemCategoryId { get; set; }
        public virtual int BelongId { get; set; }
        public virtual int ChapterId { get; set; }
       
        public virtual int IsHot { get; set; }
        public virtual int IsImportant { get; set; }
        public virtual int Sort { get; set; }
        public virtual DateTime CTime { get; set; }
        public virtual DateTime UTime { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        public virtual int SubjectInfoId { get; set; }

        /// <summary>
        /// 解析
        /// </summary>
        public virtual string Analysis { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        public virtual decimal Score { get; set; }

        public virtual ProblemCategory ProblemCategory { get; set; }

        public virtual List<Answer> AnswerList { get; set; }

        public virtual Chapter Chapter { get; set; }
        public virtual Belong Belong { get; set; } 
        public virtual SubjectInfo SubjectInfo { get; set; }
    }
}
