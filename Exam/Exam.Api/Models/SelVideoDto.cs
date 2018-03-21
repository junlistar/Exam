using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Api.Models
{
    public class SelVideoDto:PageDto
    {
        public int VideoClassId { get; set; }

        public int IsTop { get; set; }
    }
}