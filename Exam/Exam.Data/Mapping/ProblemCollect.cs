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
    public class ProblemCollectMap : EntityTypeConfiguration<ProblemCollect>
    {
        public ProblemCollectMap()
        {
            this.ToTable("ProblemCollect");
            this.HasKey(m => m.ProblemCollectId);
            this.Property(m => m.ProblemCollectId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.ProblemCollectId);
            this.Property(m => m.UserInfoId); 
            this.Property(m => m.CTime);
            this.Property(m => m.UTime);

            HasRequired(m => m.Problem);
        }
    }
}
