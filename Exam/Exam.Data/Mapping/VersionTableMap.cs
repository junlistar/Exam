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

    public class VersionTableMap : EntityTypeConfiguration<VersionTable>
    {
        public VersionTableMap()
        {
            this.ToTable("VersionTable");
            this.HasKey(m => m.VersionTableId);
            this.Property(m => m.VersionTableId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Title);
            this.Property(m => m.TypeId);
            this.Property(m => m.VersionText);
            this.Property(m => m.CTime);
            this.Property(m=>m.Link);

        }
    }
}
