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

    public class VideoMap : EntityTypeConfiguration<Video>
    {
        public VideoMap()
        {
            this.ToTable("Video");
            this.HasKey(m => m.VideoId);
            this.Property(m => m.VideoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Title);
            this.Property(m => m.VideoClassId);
            this.Property(m => m.BelongId);
            this.Property(m => m.ImageInfoId);
            this.Property(m => m.CTime);
            this.Property(m => m.UTime);
            this.Property(m => m.Url);
            this.Property(m => m.Sort);

            HasRequired(m => m.ImageInfo);

        }
    }
}
