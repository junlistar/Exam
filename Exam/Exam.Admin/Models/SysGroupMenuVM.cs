using Exam.Core.Utils;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Admin.Models
{
    public class SysGroupMenuVM
    {
        /// <summary>
        /// 分组Id
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        /// 分组类型
        /// </summary>
        public int GroupType { get; set; }
        /// <summary>
        /// 获取菜单
        /// </summary>
        public List<SysMenu> SysMenus { get; set; }
    }
}