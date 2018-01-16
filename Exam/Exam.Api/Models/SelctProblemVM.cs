﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Api.Models
{
    /// <summary>
    /// 题目接口查询
    /// </summary>
    public class SelctProblemVM
    {
        /// <summary>
        /// 题目分类id
        /// </summary>
        public int belongId { get; set; }

        /// <summary>
        /// 题目章节id
        /// </summary>
        public int ChapterId { get; set; }
    }
}