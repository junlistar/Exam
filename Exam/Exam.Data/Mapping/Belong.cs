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
    public class BelongMap : EntityTypeConfiguration<Belong>
    {
        public BelongMap()
        {
            this.ToTable("Belong");
            this.HasKey(m => m.BelongId);
            this.Property(m => m.BelongId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); 
            this.Property(m => m.Title); 
            this.Property(m => m.Sort); 
            this.Property(m => m.CTime); 
            this.Property(m => m.UTime);
            
        }
    }
}
