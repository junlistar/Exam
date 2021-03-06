﻿using System;
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
    /// 科目表
    /// </summary>
    public class SubjectInfoMap : EntityTypeConfiguration<SubjectInfo>
    {
        public SubjectInfoMap()
        {
            this.ToTable("SubjectInfo");
            this.HasKey(m => m.SubjectInfoId);
            this.Property(m => m.SubjectInfoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Title);
            this.Property(m => m.Sort);
            this.Property(m => m.CTime);
            this.Property(m => m.UTime);
            this.Property(m=>m.BelongId);
            HasMany(m => m.ChapterList).WithRequired(n => n.SubjectInfo);
        }
    }
}
