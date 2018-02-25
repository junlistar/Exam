using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    public class SubjectInfo: IAggregateRoot
    {
        /// <summary>
        /// 编号
        /// </summary>
        public virtual int SubjectInfoId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 排序
        /// </summary>

        public virtual int Sort { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>

        public virtual DateTime CTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>

        public virtual DateTime UTime { get; set; }
    }
}
