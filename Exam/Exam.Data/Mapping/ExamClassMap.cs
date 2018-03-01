using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain.Model;

namespace Exam.Data.Mapping
{
    public class ExamClassMap : EntityTypeConfiguration<ExamClass>
    {
        public ExamClassMap()
        {
            this.ToTable("ExamClass");
            this.HasKey(m => m.ExamClassId);
            this.Property(m => m.ExamClassId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Title);
            this.Property(m => m.StartTime);
            this.Property(m => m.EndTime);
            this.Property(m => m.IsShow);
            this.Property(m => m.Score);
            this.Property(m => m.Sort);
            this.Property(m => m.CreateTime);
        }

        /// <summary>
        /// --编号
        /// </summary>
        public virtual int ExamClassId { get; set; }

        /// <summary>
        /// --标题
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// --考试开始时间
        /// </summary>
        public virtual DateTime StartTime { get; set; }

        /// <summary>
        /// --考试结束时间
        /// </summary>
        public virtual DateTime EndTime { get; set; }

        /// <summary>
        /// --是否显示考试
        /// </summary>
        public virtual int IsShow { get; set; }

        /// <summary>
        /// --考试分数
        /// </summary>
        public virtual int Score { get; set; }

        /// <summary>
        /// --排序
        /// </summary>
        public virtual int Sort { get; set; }
        /// <summary>
        /// --创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
}
