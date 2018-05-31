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
    public class SmsLogMap : EntityTypeConfiguration<SmsLog>
    {
        public SmsLogMap()
        {
            this.ToTable("SmsLog");
            this.HasKey(m => m.SmsLogId);
            this.Property(m => m.SmsLogId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Code);
            this.Property(m => m.CreateTime);
            this.Property(m => m.IsSend);
            this.Property(m => m.Phone); 

        }
    }
}
