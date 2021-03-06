﻿using Exam.Core.Utils;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Admin.Models
{
    public class VideoVM:BaseImgInfoVM
    {
        public int V { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 实体信息
        /// </summary>
        public Video Video { get; set; }
        /// <summary>
        /// 实体集合
        /// </summary>
        public List<Video> Videos { get; set; }
        public List<Belong> Belongs { get; set; }
        public List<VideoClass> VideoClasses { get; set; }

        /// <summary>
        /// 回答列表
        /// </summary>
        public List<Reply> ReplyList { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public Paging<Video> Paging { get; set; }

        //查询条件
        public string QueryName { get; set; }
        public int QueryClassId { get; set; }
    }
}