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
        public int AnswerRecordId { get; set; }

        /// <summary>
        /// 问题记录表Id
        /// </summary>
        public int ProblemRecordId { get; set; }

        /// <summary>
        /// 答案id
        /// </summary>
        public int AnswerId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 问题表编号
        /// </summary>
        public int ProblemId { get; set; }

        /// <summary>
        /// 是否正确答案 0错误1正确
        /// </summary>
        public int IsCorrect { get; set; }
    }
}
