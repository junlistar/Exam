using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 考试分类记录表
    /// </summary>
    public class UserExamClass:IAggregateRoot
    {
        /// <summary>
        /// 编号
        /// </summary>
        public virtual int UserExamClassId { get; set; }
        /// <summary>
        /// --用户id
        /// </summary>
        public virtual int UserInfoId { get; set; }
        ///--考试分类表Id
        public virtual int ExamClassId { get; set; }

        ////--标题							
        public virtual string  Title { get; set; }

        ///--考试开始时间					
        public virtual DateTime StartTime { get; set; }

        ///--考试结束时间		
        public virtual DateTime EndTime { get; set; }

        ///--是否显示考试		
        public virtual int IsShow { get; set; }

        ///--考试分数					
        public virtual decimal Score{ get; set; }

        ///--排序			
        public virtual int Sort { get; set; }

        ///--创建时间							
        public virtual DateTime CreateTime { get; set; }
        
        ///--是否改卷 1默认2是已经批卷
        public virtual int IsExam { get; set; }


        public virtual UserInfo UserInfo { get; set; }
        public virtual ExamClass ExamClass { get; set; }

        public virtual List<UserExamProblem> UserExamProblemList { get; set; }
    }
}
