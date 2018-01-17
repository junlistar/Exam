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
    public class NewsInfoMap : EntityTypeConfiguration<NewsInfo>
    {
        public NewsInfoMap()
        {
            this.ToTable("NewsInfo");
            this.HasKey(m => m.NewsInfoId);
            this.Property(m => m.NewsInfoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Title);
            this.Property(m => m.Content);
            this.Property(m => m.Author);
            this.Property(m => m.ImageInfoId);
            this.Property(m => m.isHot);
            this.Property(m => m.isTop);
            this.Property(m => m.NewsCategoryId);
            this.Property(m => m.Reads);
            this.Property(m => m.Sort);  
            this.Property(m => m.CTime);
            this.Property(m => m.UTime);

            HasRequired(t => t.ImageInfo);

        }
    }
}
