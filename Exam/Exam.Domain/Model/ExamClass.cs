using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 考试分类表
    /// </summary>
    public class ExamClass:IAggregateRoot
    {
        /// <summary>
        /// --编号
        /// </summary>
        public virtual int ExamClassId { get; set; }

        /// <summary>
        /// --标题
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// --考试开始时间
        /// </summary>
        public virtual DateTime StartTime { get; set; }

        /// <summary>
        /// --考试结束时间
        /// </summary>
        public virtual DateTime EndTime { get; set; }

        /// <summary>
        /// --是否显示考试
        /// </summary>
        public virtual int IsShow { get; set; }

        /// <summary>
        /// --考试分数
        /// </summary>
        public virtual int Score { get; set; }

        /// <summary>
        /// --排序
        /// </summary>
        public virtual int Sort { get; set; }
        /// <summary>
        /// --创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
}
