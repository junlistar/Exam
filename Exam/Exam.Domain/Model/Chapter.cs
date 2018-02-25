using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{

    /// <summary>
    /// 章节分类
    /// </summary>
    public class Chapter : IAggregateRoot
    {
        public virtual int ChapterId { get; set; }
        public virtual string Title { get; set; }
        public virtual int Sort { get; set; }
        public virtual DateTime CTime { get; set; }
        public virtual DateTime UTime { get; set; }

        /// <summary>
        ///科目
        /// </summary>
        public virtual int SubjectInfoId { get; set; }

        public virtual SubjectInfo SubjectInfo { get; set; }
    }
}
