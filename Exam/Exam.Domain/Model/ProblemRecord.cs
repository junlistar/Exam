using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 问题记录表
    /// </summary>
    public class ProblemRecord: IAggregateRoot
    {
        /// <summary>
        /// 编号
        /// </summary>
       public int ProblemRecordId { get; set; }

       /// <summary>
       /// 问题id
       /// </summary>
	   public int ProblemId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 类别分类
        /// </summary>
        public int ProblemCategoryId { get; set; }

        /// <summary>
        /// 正确答案
        /// </summary>
        public string CorrectAnswer{get;set;}

        /// <summary>
        /// 错误答案
        /// </summary>
        public string ErrorAnswer { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UTime { get; set; }
    }
}
