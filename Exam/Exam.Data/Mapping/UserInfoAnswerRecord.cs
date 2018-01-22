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
    /// 用户答题记录表
    /// </summary>
    public class UserInfoAnswerRecordMap : EntityTypeConfiguration<Domain.Model.UserInfoAnswerRecord>
    {
        public UserInfoAnswerRecordMap()
        {
            this.ToTable("UserInfoAnswerRecord");
            this.HasKey(m => m.UserInfoAnswerRecordId);
            this.Property(m => m.UserInfoAnswerRecordId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.UserInfoId);
            this.Property(m => m.Score);
            this.Property(m => m.Title);
            this.Property(m => m.BelongId);
            this.Property(m => m.ChapterId);
            this.Property(m => m.CTime);
            this.Property(m => m.UTime);
        }
    }
}
