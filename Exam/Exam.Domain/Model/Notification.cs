using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 消息
    /// </summary>
   public class Notification : IAggregateRoot
    {
        /// <summary>
        /// 编号
        /// </summary>
        public virtual int NotificationId { get; set; }

        /// <summary>
        /// 实体对象Id
        /// </summary>
        public virtual int ObjectId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public virtual int UserInfoId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 消息类型id
        /// </summary>

        public virtual int TypeId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>

        public virtual DateTime CTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime UTime { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}
