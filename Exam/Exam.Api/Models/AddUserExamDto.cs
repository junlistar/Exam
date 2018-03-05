using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Api.Models
{
    /// <summary>
    /// 添加考试记录
    /// </summary>
    public class AddUserExamDto
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserInfoId { get; set; }

        /// <summary>
        /// 考试分类id
        /// </summary>

        public int ExamClassId { get; set; }

        public List<AddExamProblemDto> AddExamProblemDtoList { get; set; }
    }

    public class AddExamProblemDto
    {
        public int ExamProblemId { get; set; }

        public string ExamAnswerIds { get; set; }
        public List<AddExamAnswerDto> AddExamAnswerList { get; set; }
    }

    public class AddExamAnswerDto
    {
        public int ExamAnswerId { get; set; }
    }
}