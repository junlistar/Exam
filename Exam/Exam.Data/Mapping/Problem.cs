using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain;
using System.Data.Entity.ModelConfiguration;
using Exam.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Data.Mapping
{
    public class ProblemMap : EntityTypeConfiguration<Problem>
    {
        public ProblemMap()
        {
            this.ToTable("Problem");
            this.HasKey(m => m.ProblemId);
            this.Property(m => m.ProblemId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.BelongId);
            this.Property(m => m.ChapterId); 
            this.Property(m => m.CTime);
            this.Property(m => m.IsHot);
            this.Property(m => m.IsImportant);
            this.Property(m => m.ProblemCategoryId);
            this.Property(m => m.Title);
            this.Property(m => m.UTime);
            this.Property(m => m.Sort);
            this.Property(m => m.Score);
            this.Property(m => m.Analysis);
            this.Property(m => m.SubjectInfoId);
            HasRequired(m => m.ProblemCategory);
            HasRequired(m => m.Chapter);
            HasMany(m => m.AnswerList).WithRequired(n => n.Problem);

        }
    }
}
