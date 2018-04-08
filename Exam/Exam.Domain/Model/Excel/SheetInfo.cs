using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Excel
{
   public class SheetInfo
    {
        public string SheetName { get; set; }

        public DataTable Data { get; set; }

        public List<ColumnInfo> CloumnInfos
        {
            get;
            set;
        }
    }
}
