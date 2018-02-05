using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 版本表
    /// </summary>
    public class VersionTable : IAggregateRoot
    {
        /// <summary>
        /// 编号
        /// </summary>
        public virtual int VersionTableId { get; set; }

        /// <summary>
        /// 版本名称
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 标题
        /// </summary>

        public virtual string VersionText { get; set; }

        /// <summary>
        /// 版本类型	
        /// </summary>
        public int TypeId { get; set; }
        

        /// <summary>
        /// 创建时间
        /// </summary>

        public virtual DateTime CTime { get; set; }
    }
}
