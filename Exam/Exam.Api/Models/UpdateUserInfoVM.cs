using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Api.Models
{
    /// <summary>
    /// 修改用户信息
    /// </summary>
    public class UpdateUserInfoVM
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserInfoId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string NikeName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Gender { get; set; }
        
        /// <summary>
        /// 级别
        /// </summary>
        public int GradeId { get; set; }
    }
}