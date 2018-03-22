using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Api.Models
{ 

    /// <summary>
    /// 添加答题记录
    /// </summary>
    public class AddUserInfoAnswerRecordDto
    {
        /// <summary>
        /// 问题
        /// </summary>
        public List<AddProblemRecordDto> AddProblemRecordDto { get; set; }

        /// <summary>
        /// 题目所属分类
        /// </summary>
        public int BelongId { get; set; }

        /// <summary>
        /// 章节分类
        /// </summary>
        public int ChapterId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>

        public int UserInfoId { get; set; }

        /// <summary>
        /// 科目id
        /// </summary>
        public int SubjectInfoId { get; set; }
    }

    public class AddProblemRecordDto
    {
        public int ProblemId { get; set; }

        /// <summary>
        /// 1正确2错误
        /// </summary>

        public int YesOrNo { get; set; }

        public string AnswerIds { get; set; }
        //public List<AddAnswerRecordDto> AnswerRecordList { get; set; }
    }

    public class AddAnswerRecordDto
    { 
        public int AnswerId { get; set; }
    }
}