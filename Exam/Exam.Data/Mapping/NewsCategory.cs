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
    public class NewsCategoryMap : EntityTypeConfiguration<NewsCategory>
    {
        public NewsCategoryMap()
        {
            this.ToTable("NewsCategory");
            this.HasKey(m => m.NewsCategoryId);
            this.Property(m => m.NewsCategoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Title);
            this.Property(m => m.Sort);  
            this.Property(m => m.CTime);
            this.Property(m => m.UTime);
             
        }
    }
}
