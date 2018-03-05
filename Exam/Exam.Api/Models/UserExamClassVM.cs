using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Api.Models
{
    public class UserExamClassVM
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int UserExamClassId { get; set; }
        /// <summary>
        /// --用户id
        /// </summary>
        public int UserInfoId { get; set; }
        ///--考试分类表Id
        public virtual int ExamClassId { get; set; }

        ////--标题							
        public string Title { get; set; }

        ///--考试开始时间					
        public DateTime StartTime { get; set; }

        ///--考试结束时间		
        public DateTime EndTime { get; set; }

        ///--是否显示考试 1显示2不显示		
        public int IsShow { get; set; }

        ///--考试分数					
        public decimal Score { get; set; }

        ///--排序			
        public int Sort { get; set; }

        ///--创建时间							
        public virtual DateTime CreateTime { get; set; }

        ///--是否改卷 1默认2是已经批卷
        public virtual int IsExam { get; set; }


        public List<UserExamProblemVM> UserExamProblemList { get; set; }

    }

    public class UserExamProblemVM
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

        public List<UserExamAnswerVM> UserExamAnswerList { get; set; }
    }

    public class UserExamAnswerVM
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
        public virtual int UserExamProblemId { get; set; }

        /// <summary>
        /// --是否正确答案 0错误1正确
        /// </summary>
        public virtual int IsCorrect { get; set; }
    }
}