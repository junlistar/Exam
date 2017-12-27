using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    /// <summary>
    /// 讲师表
    /// </summary>
    public class Lecturer : IAggregateRoot
    {
        public virtual int LecturerId { get; set; }
        public virtual string Name { get; set; } 
        public virtual string Position { get; set; } 
        public virtual int ImageInfoId { get; set; }
        /// <summary>
        /// 摘要简介
        /// </summary>
        public virtual string Abstracts { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        public virtual string Introduce { get; set; }
        public virtual int Sort { get; set; }  
        public virtual DateTime CTime { get; set; } 
        public virtual DateTime UTime { get; set; }

    }
}
