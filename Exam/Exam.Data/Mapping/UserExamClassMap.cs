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
    public class UserExamClassMap : EntityTypeConfiguration<UserExamClass>
    {
        public UserExamClassMap()
        {
            this.ToTable("UserExamClass");
            this.HasKey(m => m.UserExamClassId);
            this.Property(m => m.UserExamClassId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.UserInfoId);
            this.Property(m => m.ExamClassId);
            this.Property(m => m.Title);
            this.Property(m => m.StartTime);
            this.Property(m => m.EndTime);
            this.Property(m => m.IsShow);
            this.Property(m => m.Score);
            this.Property(m => m.Sort);
            this.Property(m => m.CreateTime);
            this.Property(m => m.IsExam);

            HasRequired(m => m.UserInfo);
            HasRequired(m => m.ExamClass);
            HasMany(m => m.UserExamProblemList).WithRequired(n => n.UserExamClass);
        }
    }
}
