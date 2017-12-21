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
    public class SysGroupMenuMap : EntityTypeConfiguration<SysGroupMenu>
    {
        public SysGroupMenuMap()
        {
            this.ToTable("SysGroupMenu");
            this.HasKey(m => m.SysGroupMenuId);
            this.Property(m => m.SysGroupMenuId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.SysGroupId);
            this.Property(m => m.SysGroupMenuId);
            this.Property(m => m.CTime);
            this.Property(m => m.UTime);
             
        }
    }
}
