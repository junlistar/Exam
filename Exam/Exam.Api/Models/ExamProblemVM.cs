using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exam.Domain.Model;

namespace Exam.Api.Models
{
    /// <summary>
    /// 考试题目
    /// </summary>
    public class ExamProblemVM
    {
        /// <summary>
        /// --编号
        /// </summary>
        public virtual int ExamProblemId { get; set; }

        /// <summary>
        /// --标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// -类别分类
        /// </summary>
        public int ProblemCategoryId { get; set; }


        /// <summary>
        /// --考试分类表Id
        /// </summary>
        public int ExamClassId { get; set; }



        /// <summary>
        /// --排序
        /// </summary>
        public  int Sort { get; set; }

        /// <summary>
        /// --分数
        /// </summary>
        public  decimal Score { get; set; }

        /// <summary>
        /// --解析	
        /// </summary>
        public  string Analysis { get; set; }
        

        public virtual List<ExamAnswerVM> ExamAnswerList { get; set; }
    }

    public class ExamAnswerVM {
        /// <summary>
        /// --编号
        /// </summary>
        public int ExamAnswerId { get; set; }


        /// <summary>
        /// --标题
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// -是否正确答案 0错误1正确
        /// </summary>
        public int IsCorrect { get; set; }
    }
}