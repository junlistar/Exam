using Exam.Core.Utils;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Admin.Models
{
    public class AdvertisementVM : BaseImgInfoVM
    {
        public int V { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 广告类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 实体信息
        /// </summary>
        public Advertisement Advertisement { get; set; }
        /// <summary>
        /// 实体集合
        /// </summary>
        public List<Advertisement> Advertisements { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public Paging<Advertisement> Paging { get; set; }

        //查询条件
        public string QueryName { get; set; } 
    }
}