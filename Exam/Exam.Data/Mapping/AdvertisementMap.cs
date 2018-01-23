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

    public class AdvertisementMap : EntityTypeConfiguration<Advertisement>
    {
        public AdvertisementMap()
        {
            this.ToTable("Advertisement");
            this.HasKey(m => m.AdvertisementId);
            this.Property(m => m.AdvertisementId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Title);
            this.Property(m => m.UserInfoId);
            this.Property(m => m.TypeId);
            this.Property(m => m.ImageInfoId);
            this.Property(m => m.CTime);
            this.Property(m => m.UTime);

            HasRequired(m => m.ImageInfo);

        }
    }
}
