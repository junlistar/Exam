﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    public class NewsInfo : IAggregateRoot
    {
        public virtual int NewsInfoId { get; set; }
        public virtual string Title { get; set; } 
        public virtual string Content { get; set; } 
        public virtual string Author { get; set; } 
        public virtual int NewsCategoryId { get; set; } 
        public virtual int ImageInfoId { get; set; }  
        public virtual int Sort { get; set; } 
        public virtual int Reads { get; set; } 
        public virtual int isTop { get; set; } 
        public virtual int isHot { get; set; }
        public virtual DateTime CTime { get; set; }
        public virtual DateTime UTime { get; set; }

        public virtual ImageInfo ImageInfo { get;set;}
        public virtual NewsCategory NewsCategory { get;set; }

    }
}
