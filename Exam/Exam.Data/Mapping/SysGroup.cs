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
    public class SysGroupMap : EntityTypeConfiguration<SysGroup>
    {
        public SysGroupMap()
        {
            this.ToTable("SysGroup");
            this.HasKey(m => m.SysGroupId);
            this.Property(m => m.SysGroupId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Name);
            this.Property(m => m.SortNo);
            this.Property(m => m.Type);
            this.Property(m => m.CTime);
            this.Property(m => m.IsEnable); 

            //HasMany(m => m.UserFavList).WithRequired(n => n.UserInfo);
        }
    }
}
