using Exam.Core.Utils;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Admin.Models
{
    public class UserInfoVM : BaseImgInfoVM
    {
        /// <summary>
        /// 刷新标识
        /// </summary>
        public int RefreshFlag { get; set; } 

        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public UserInfo UserInfo { get; set; }

        /// <summary>
        /// 等级列表
        /// </summary>
        public List<Grade> GradeList { get; set; }
        /// <summary>
        /// 用户组列表
        /// </summary>
        public List<SysGroup> SysGroupList { get; set; }

        /// <summary>
        /// 用户分页
        /// </summary>
        public Paging<UserInfo> Paging { get; set; }
        public string QueryLoginName { get; set; }
    }
}