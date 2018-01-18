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
    /// 消息
    /// </summary>
    public class NotificationMap : EntityTypeConfiguration<Notification>
    {
        public NotificationMap()
        {
            this.ToTable("Notification");
            this.HasKey(m => m.NotificationId);
            this.Property(m => m.NotificationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.ObjectId);
            this.Property(m => m.UserInfoId);
            this.Property(m => m.TypeId);
            this.Property(m => m.CTime);
            this.Property(m => m.UTime);
            this.Property(m => m.Title);

            HasRequired(t => t.UserInfo);

        }
    }
}
