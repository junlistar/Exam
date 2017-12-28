﻿using Exam.Core.Utils;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Admin.Models
{
    public class AnswerVM
    {
        public int V { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 实体信息
        /// </summary>
        public Answer Answer { get; set; }
        /// <summary>
        /// 实体集合
        /// </summary>
        public List<Answer> Answers { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public Paging<Answer> Paging { get; set; }

        //查询条件
        public string QueryName { get; set; } 
    }
}