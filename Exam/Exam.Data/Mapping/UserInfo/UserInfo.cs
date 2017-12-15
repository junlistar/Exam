using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain;
using System.Data.Entity.ModelConfiguration;
using Exam.Domain.UserInfo;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Data.Mapping.Test
{
    public class UserInfoMap : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoMap()
        {
            this.ToTable("UserInfo");
            this.HasKey(m => m.Id);
            this.Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Name);
            this.Property(m => m.Age);
            this.Property(m => m.CreateTime);
            this.Property(m => m.Comment);  
        }
    }
}
