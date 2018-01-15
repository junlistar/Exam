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
    /// 答案记录表
    /// </summary>
    public class AnswerRecordMap : EntityTypeConfiguration<AnswerRecord>
    {
        public AnswerRecordMap()
        {
            this.ToTable("AnswerRecord");
            this.HasKey(m => m.AnswerRecordId);
            this.Property(m => m.AnswerRecordId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.IsCorrect);
            this.Property(m => m.ProblemId);
            this.Property(m => m.Title);
            this.Property(m => m.AnswerId);
            this.Property(m => m.ProblemRecordId); 
        }
    }
}
