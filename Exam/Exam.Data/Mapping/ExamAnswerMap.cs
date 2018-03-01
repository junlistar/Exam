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
    /// <summary>
    /// 考试问题表答案选项表
    /// </summary>
    public class ExamAnswerMap : EntityTypeConfiguration<ExamAnswer>
    {
        public ExamAnswerMap()
        {
            this.ToTable("ExamAnswer");
            this.HasKey(m => m.ExamAnswerId);
            this.Property(m => m.ExamAnswerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Title);
            this.Property(m => m.ExamProblemId);
            this.Property(m => m.IsCorrect);
        }
    }
}
