﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Model
{
    public class ImageInfo : IAggregateRoot
    {
        public virtual int ImageInfoId { get; set; }
        public virtual string Title { get; set; } 
        public virtual string Url { get; set; }  
        public virtual string Source { get; set; }
        public virtual DateTime CTime { get; set; } 
         
    }
}
