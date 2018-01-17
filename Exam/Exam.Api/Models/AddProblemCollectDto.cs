using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Api.Models
{
    public class AddProblemCollectDto
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserInfoId { get; set; }

        /// <summary>
        /// 问题id
        /// </summary>
        public int ProblemId { get; set; }
    }
    public class DelProblemCollectDto
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserInfoId { get; set; }

        /// <summary>
        /// 问题id
        /// </summary>
        public int ProblemCollectId { get; set; }
    }

}