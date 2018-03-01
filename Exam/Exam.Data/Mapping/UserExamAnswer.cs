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
   public  class UserExamAnswerMap : EntityTypeConfiguration<UserExamAnswer>
    {
        public UserExamAnswerMap()
        {
            this.ToTable("UserExamAnswer");
            this.HasKey(m => m.UserExamAnswerId);
            this.Property(m => m.UserExamAnswerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Title);
            this.Property(m => m.ExamProblemId);
            this.Property(m => m.IsCorrect);
        }
    }
}
