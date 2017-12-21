using Exam.Core.Utils;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Admin.Models
{
    public class SysMenuVM
    {
        public int V { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 菜单信息
        /// </summary>
        public SysMenu SysMenu { get; set; }
        /// <summary>
        /// 菜单集合
        /// </summary>
        public List<SysMenu> SysMenus { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public Paging<SysMenu> Paging { get; set; }

        //查询条件
        public string QueryName { get; set; }
        public int QueryType { get; set; }
    }
}