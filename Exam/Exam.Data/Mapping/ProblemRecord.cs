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
    /// 问题记录表
    /// </summary>
    public class ProblemRecordMap : EntityTypeConfiguration<Domain.Model.ProblemRecord>
    {
        public ProblemRecordMap()
        {
            this.ToTable("ProblemRecord");
            this.HasKey(m => m.ProblemRecordId);
            this.Property(m => m.ProblemRecordId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.ProblemId);
            this.Property(m => m.Title);
            this.Property(m => m.ProblemCategoryId);
            this.Property(m => m.CorrectAnswer);
            this.Property(m => m.ErrorAnswer);
            this.Property(m => m.CTime);
            this.Property(m => m.UTime);
            this.Property(m => m.Analysis);
            this.Property(m=>m.YesOrNo);
            this.Property(m=>m.UserInfoId);
            HasRequired(m => m.ProblemCategory);
            HasMany(m => m.AnswerRecordList).WithRequired(n => n.ProblemRecord);
        }
    }
}
