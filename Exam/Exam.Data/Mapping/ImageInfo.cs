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
    public class ImageInfoMap : EntityTypeConfiguration<ImageInfo>
    {
        public ImageInfoMap()
        {
            this.ToTable("ImageInfo");
            this.HasKey(m => m.ImageInfoId);
            this.Property(m => m.ImageInfoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Title);
            this.Property(m => m.Url); 
            this.Property(m => m.Source);
            this.Property(m => m.CTime); 
             
        }
    }
}
