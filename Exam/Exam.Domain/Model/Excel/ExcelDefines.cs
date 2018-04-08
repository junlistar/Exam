using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Excel
{
    public enum CellDataType
    {
        /// <summary>
        /// 字符串类型
        /// </summary>
        contentCellStyle = 0,
        /// <summary>
        /// 数值类型
        /// </summary>
        numberCellStyle = 1,
        /// <summary>
        /// 拼接连续两列类型
        /// </summary>
        combinecontentCellStyle = 2
    }


}
