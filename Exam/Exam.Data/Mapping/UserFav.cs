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
    public class UserFavMap : EntityTypeConfiguration<UserFav>
    {
        public UserFavMap()
        {
            this.ToTable("UserFav");
            this.HasKey(m => m.UserFavId);
            this.Property(m => m.UserFavId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.FavName); 
            this.Property(m => m.UserInfoId);
            this.Property(m => m.CreateTime);
             
             
        }
    }
}
