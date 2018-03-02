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
   public class ExamProblemMap : EntityTypeConfiguration<ExamProblem>
    {
        public ExamProblemMap()
        {
            this.ToTable("ExamProblem");
            this.HasKey(m => m.ExamProblemId);
            this.Property(m => m.ExamProblemId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Title);
            this.Property(m => m.ProblemCategoryId);
            this.Property(m => m.ExamClassId);
            this.Property(m => m.CTime);
            this.Property(m => m.Sort);
            this.Property(m => m.UTime);
            this.Property(m => m.Score);
            this.Property(m => m.Analysis);
            HasRequired(m => m.ExamClass);
        }
    }
}
