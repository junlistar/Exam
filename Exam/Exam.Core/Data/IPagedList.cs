using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam.Core.Data
{
    /// <summary>
    /// 数据分页接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedList<T> : IList<T>
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}
