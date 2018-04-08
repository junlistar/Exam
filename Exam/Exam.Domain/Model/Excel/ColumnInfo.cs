using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Excel
{
    public class ColumnInfo
    {
        public ColumnInfo(string header, int width,CellDataType type)
        {
            this.Header = header;
            this.Width = width;
            this.CellDataType = type;
            AutoFilter = false;
        }
        /// <summary>
        /// 列头
        /// </summary>
        public string Header
        {
            get;
            set;
        }

        /// <summary>
        /// 宽度
        /// </summary>
        public int Width
        {
            get;
            set;
        }

        /// <summary>
        /// 该列内容格式
        /// </summary>
        public CellDataType CellDataType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic filter].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [automatic filter]; otherwise, <c>false</c>.
        /// </value>
        public bool AutoFilter { get; set; }
    }
}
