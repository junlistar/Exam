using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Api.Models
{
    /// <summary>
    /// 科目
    /// </summary>
    public class SubjectInfoVM
    {
        /// <summary>
        /// 编号
        /// </summary>
        public virtual int SubjectInfoId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 排序
        /// </summary>

        public virtual int Sort { get; set; }

        /// <summary>
        /// 分类id
        /// </summary>
        public virtual int BelongId { get; set; }

        /// <summary>
        /// 章节分类
        /// </summary>
        public virtual List<ChapterVM> ChapterList { get; set; }
    }

    /// <summary>
    /// 章节
    /// </summary>
    public class ChapterVM {
        public  int ChapterId { get; set; }
        public string Title { get; set; }
        public int Sort { get; set; }
    }
}