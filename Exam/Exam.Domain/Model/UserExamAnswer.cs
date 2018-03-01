using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 考试问题表答案选项表
    /// </summary>
    public class UserExamAnswer:IAggregateRoot
    {
        /// <summary>
        /// --编号
        /// </summary>
        public virtual int UserExamAnswerId { get; set; }
        /// <summary>
        /// --标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// --问题表编号
        /// </summary>
        public virtual int ExamProblemId { get; set; }

        /// <summary>
        /// --是否正确答案 0错误1正确
        /// </summary>
        public virtual int IsCorrect { get; set; }				
    }
}
