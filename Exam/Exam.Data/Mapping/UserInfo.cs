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
    public class UserInfoMap : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoMap()
        {
            this.ToTable("UserInfo");
            this.HasKey(m => m.UserInfoId);
            this.Property(m => m.UserInfoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.NikeName);
            this.Property(m => m.Phone); 
            this.Property(m => m.Password);
            this.Property(m => m.Gender);
            this.Property(m => m.CTime);
            this.Property(m => m.IsEnable);

            HasRequired(t => t.SysGroup);

            //HasMany(m => m.UserFavList).WithRequired(n => n.UserInfo);
        }
    }
}
