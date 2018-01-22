using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 广告表
    /// </summary>
    public class Advertisement: IAggregateRoot
    {
        /// <summary>
        /// 编号
        /// </summary>
        public virtual int AdvertisementId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public virtual int UserInfoId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>

        public virtual string Title { get; set; }

        /// <summary>
        /// 广告类型	
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// 广告图片	
        /// </summary>

        public virtual int ImageInfoId { get; set; }

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
