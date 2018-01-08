using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Api.Models
{
    /// <summary>
    /// 分布查询
    /// </summary>
    public class PageDto
    {
        private int _PageIndex;
        /// <summary>
        /// 开始页
        /// </summary>
        public int PageIndex
        {
            get
            {
                if (_PageIndex < 1)
                {
                    return 1;
                }
                else
                {
                    return _PageIndex;
                }
            }
            set
            {
                this._PageIndex = value;
            }
        }


        private int _PageSize;
        /// <summary>
        /// 页面总数
        /// </summary>
        public int PageSize
        {
            get
            {
                if (_PageSize < 1)
                {
                    return 10;
                }
                else
                {
                    return _PageSize;
                }
            }
            set
            {
                this._PageSize = value;
            }

        }
    }
}
