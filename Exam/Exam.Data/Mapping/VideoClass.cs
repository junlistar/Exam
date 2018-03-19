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

    public class VideoClassMap : EntityTypeConfiguration<VideoClass>
    {
        public VideoClassMap()
        {
            this.ToTable("VideoClass");
            this.HasKey(m => m.VideoClassId);
            this.Property(m => m.VideoClassId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Title);
            this.Property(m => m.Sort);
            this.Property(m => m.CTime);
            this.Property(m => m.UTime);

        }
    }
}
