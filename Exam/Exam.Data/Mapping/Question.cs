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
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            this.ToTable("Question");
            this.HasKey(m => m.QuestionId);
            this.Property(m => m.QuestionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Title); 
            this.Property(m => m.Content); 
            this.Property(m => m.UserInfoId); 
            this.Property(m => m.Sort); 
            this.Property(m => m.Reads);
            this.Property(m => m.IsHot); 
            this.Property(m => m.IsTop); 
            this.Property(m => m.CTime);
            this.Property(m => m.IsEnable);

        }
    }
}
