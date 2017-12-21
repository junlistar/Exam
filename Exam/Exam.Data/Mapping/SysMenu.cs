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
    public class SysMenuMap : EntityTypeConfiguration<SysMenu>
    {
        public SysMenuMap()
        {
            this.ToTable("SysMenu");
            this.HasKey(m => m.SysMenuId);
            this.Property(m => m.SysMenuId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Fid);
            this.Property(m => m.Icon);
            this.Property(m => m.Type);
            this.Property(m => m.IsEnable);
            this.Property(m => m.Name);
            this.Property(m => m.CTime);
            this.Property(m => m.UTime);

            //HasMany(m => m.UserFavList).WithRequired(n => n.UserInfo);
        }
    }
}
