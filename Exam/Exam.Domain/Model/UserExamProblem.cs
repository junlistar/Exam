using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 考试问题记录表
    /// </summary>
    public class UserExamProblem:IAggregateRoot
    {
        /// <summary>
        /// --编号
        /// </summary>
        public virtual int UserExamProblemId { get; set; }

        /// <summary>
        /// --标题
        /// </summary>
        public virtual String Title { get; set; }

        /// <summary>
        /// --类别分类
        /// </summary>

        public virtual int ProblemCategoryId { get; set; }

        /// <summary>
        /// --考试分类表Id
        /// </summary>
        public virtual int UserExamClassId { get; set; }

        /// <summary>
        /// --创建时间
        /// </summary>		
        public virtual DateTime CTime { get; set; }

        /// <summary>
        /// --排序
        /// </summary>	
        public virtual int Sort { get; set; }
        /// <summary>
        /// --修改时间
        /// </summary>	
        public virtual DateTime UTime { get; set; }
        /// <summary>
        /// --分数
        /// </summary>
        public virtual decimal Score { get; set; }
        /// <summary>
        /// 正确答案
        /// </summary>
        public virtual string CorrectAnswer { get; set; }
        /// <summary>
        /// 错误答案
        /// </summary>
        public virtual string ErrorAnswer { get; set; }
        /// <summary>
        /// 解析
        /// </summary>
        public virtual string Analysis { get; set; }

        public virtual UserExamClass UserExamClass { get; set; }

        public virtual List<UserExamAnswer> UserExamAnswerList { get; set; }
    }
}
