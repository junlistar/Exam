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
            this.Property(m => m.BelongId);

            HasMany(m => m.ExamProblemList).WithRequired(n => n.ExamClass);
            
        }
    }
}
