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
    public class LogMap : EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            this.ToTable("Log");
            this.HasKey(m => m.LogId);
            this.Property(m => m.LogId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.TargetId);
            this.Property(m => m.TargetTitle);
            this.Property(m => m.UserInfoId);
            this.Property(m => m.CTime);

            HasRequired(t => t.UserInfo);

        }
    }
}
