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
    public class LecturerMap : EntityTypeConfiguration<Lecturer>
    {
        public LecturerMap()
        {
            this.ToTable("Lecturer");
            this.HasKey(m => m.LecturerId);
            this.Property(m => m.LecturerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.abstracts);
            this.Property(m => m.CTime); 
            this.Property(m => m.ImageInfoId);
            this.Property(m => m.Introduce);
            this.Property(m => m.LecturerId);
            this.Property(m => m.Name);
            this.Property(m => m.Position);
            this.Property(m => m.Sort); 
             
        }
    }
}
