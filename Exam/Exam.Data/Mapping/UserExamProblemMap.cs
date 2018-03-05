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
   public  class UserExamProblemMap : EntityTypeConfiguration<UserExamProblem>
    {
        public UserExamProblemMap()
        {
            this.ToTable("UserExamProblem");
            this.HasKey(m => m.UserExamProblemId);
            this.Property(m => m.UserExamProblemId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Title);
            this.Property(m => m.ProblemCategoryId);
            this.Property(m => m.UserExamClassId);
            this.Property(m => m.CTime);
            this.Property(m => m.Sort);
            this.Property(m => m.UTime);
            this.Property(m => m.Score);
            this.Property(m => m.CorrectAnswer);
            this.Property(m => m.ErrorAnswer);
            this.Property(m => m.Analysis);
            HasRequired(m => m.UserExamClass);
            HasMany(m => m.UserExamAnswerList).WithRequired(n => n.UserExamProblem);
        }
    }
}
