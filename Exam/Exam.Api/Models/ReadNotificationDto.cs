using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Api.Models
{
    /// <summary>
    /// 读消息
    /// </summary>
    public class ReadNotificationDto
    {
        /// <summary>
        /// 消息中心
        /// </summary>
        public int NotificationId { get; set; }

        /// <summary>
        /// userinfoId
        /// </summary>
        public int UserInfoId { get; set; }
    }
}