using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Api.Models
{
    public class SelNotificationDto:PageDto
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserInfoId { get; set; }

        /// <summary>
        /// 消息状态 1是未读 2是只读
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>

        public int TypeId { get; set; }
    }
}