using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 答案记录表
    /// </summary>
    public class AnswerRecord : IAggregateRoot
    {
        /// <summary>
        /// 编号
        /// </summary>
        public virtual int AnswerRecordId { get; set; }

        /// <summary>
        /// 问题记录表Id
        /// </summary>
        public virtual int ProblemRecordId { get; set; }

        /// <summary>
        /// 答案id
        /// </summary>
        public virtual int AnswerId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 问题表编号
        /// </summary>
        public virtual int ProblemId { get; set; }

        /// <summary>
        /// 是否正确答案 0错误1正确
        /// </summary>
        public virtual int IsCorrect { get; set; }

        public virtual ProblemRecord ProblemRecord { get; set; }
    }
}
