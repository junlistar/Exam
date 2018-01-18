using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Api.Models
{
    public class AddNotificationDto
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserInfoId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>

        public string Title { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// 实体id
        /// </summary>

        public int ObjectId { get; set; }

    }
}