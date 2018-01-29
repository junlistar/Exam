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
    /// <summary>
    /// 题库
    /// </summary>
   public class ProblemLibraryMap : EntityTypeConfiguration<ProblemLibrary>
    {
        public ProblemLibraryMap()
        {
            this.ToTable("ProblemLibrary");
            this.HasKey(m => m.ProblemLibraryId);
            this.Property(m => m.ProblemLibraryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Title);
            this.Property(m => m.ProblemCategoryId);
            this.Property(m => m.isVideo);
            this.Property(m => m.IsUse);
            this.Property(m => m.CTime);
            this.Property(m => m.c_tips);
            this.Property(m => m.c_sortid);
            this.Property(m => m.c_sctid);
            this.Property(m => m.c_score);
            this.Property(m => m.c_qustiontype);
            this.Property(m => m.c_qid);
            this.Property(m => m.c_options);
            this.Property(m => m.c_MistakeNum);
            this.Property(m => m.c_assistantsortid);
            this.Property(m => m.c_answer);
            this.Property(m => m.BelongId);
            this.Property(m => m.c_sctname);
            
        }
    }
}
