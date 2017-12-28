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
    public class ReplyMap : EntityTypeConfiguration<Reply>
    {
        public ReplyMap()
        {
            this.ToTable("Reply");
            this.HasKey(m => m.ReplyId);
            this.Property(m => m.ReplyId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.UserInfoId); 
            this.Property(m => m.Content);  
            this.Property(m => m.QuestionId); 
            this.Property(m => m.Reads);
            this.Property(m => m.Sort);  
            this.Property(m => m.CTime);
             
        }
    }
}
