using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 视频表
    /// </summary>
    public class Video : IAggregateRoot
    {
        /// <summary>
        /// 编号
        /// </summary>
        public virtual int VideoId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>

        public virtual string Title { get; set; }

        /// <summary>
        /// 分类编号	
        /// </summary>
        public virtual int VideoClassId { get; set; }

        /// <summary>
        /// 所属	
        /// </summary>
        public virtual int BelongId { get; set; }

        /// <summary>
        /// 广告图片	
        /// </summary>

        public virtual int ImageInfoId { get; set; }

        /// <summary>
        /// url
        /// </summary>

        public virtual string Url { get; set; }


        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sort { get; set; }
        /// <summary>
        /// 置顶
        /// </summary>
        public virtual int IsTop { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>

        public virtual DateTime CTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime UTime { get; set; }


        public virtual ImageInfo ImageInfo { get; set; }
    }
}
