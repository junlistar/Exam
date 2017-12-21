using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Exam.Core.Utils
{
    /// <summary>
    /// 分页实体类。
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class Paging<T>
    {
        private int size;
        private int total;
        private int index;
        /// <summary>
        /// 获取或设置当前数据列表。
        /// </summary>
        public List<T> Items { get; set; }
        /// <summary>
        /// 获取或设置当前索引页数。
        /// </summary>
        public int Index
        {
            get { return this.index; }
            set { this.index = value; }
        }
        /// <summary>
        /// 获取或设置每页显示的条数。
        /// </summary>
        public int Size
        {
            get { return this.size; }
            set { this.size = value; this.SetCount(); }
        }
        /// <summary>
        /// 获取或设置总记录数。
        /// </summary>
        public int Total
        {
            get { return this.total; }
            set { this.total = value; this.SetCount(); }
        }
        /// <summary>
        /// 获取分页字符。
        /// </summary>
        public string Text
        {
            get
            {
                var text = new StringBuilder(255);
                text.Append("<div class=\"btn-toolbar pull-right btn-group\">");
                if (Count > 0)
                {
                    string path = this.Path;
                    int i, show = 5, num = show * 2, currNum, pageNum;
                    currNum = Index - show;
                    pageNum = (Index + show) - 1;
                    if (pageNum < num) pageNum = num;
                    if (currNum <= 0) currNum = 1;
                    if (pageNum >= Count)
                    {
                        pageNum = Count;
                        currNum = (Count - num) + 1;
                        if (currNum < 1) currNum = 1;
                    }
                    if (string.IsNullOrEmpty(path))
                    {
                        path = HttpContext.Current.Request.Url.PathAndQuery;
                        if (path.IndexOf('?') == -1)
                        {
                            path = path + "?";
                        }
                        else if (path.IndexOf("pn") == -1)
                        {
                            path = path + "&";
                        }
                        else
                        {
                            var nv = HttpContext.Current.Request.QueryString;
                            path = HttpContext.Current.Request.Url.AbsolutePath + "?";
                            for (i = 0; i < nv.Count; i++)
                            {
                                if (nv.GetKey(i) != null && nv.GetKey(i).Equals("pn") == false)
                                {
                                    path = string.Format("{0}{1}={2}&", path, nv.GetKey(i), nv[i]);
                                }
                            }
                        }
                    }

                    if (Index > 1)
                    {
                        text.AppendFormat("<a href=\"{0}pn={1}\" class=\"btn btn-white\"><i class=\"fa fa-chevron-left\"></i></a>", path, Index - 1);
                    }
                    else
                    {
                        text.Append("<a class=\"btn btn-white\"><i class=\"fa fa-chevron-left\"></i></a>");
                    }
                    for (i = currNum; i <= pageNum; i++)
                    {
                        if (i == Index)
                        {
                            text.AppendFormat("<a class=\"btn btn-white active-page\">{0}</a>", i);
                        }
                        else
                        {
                            text.AppendFormat("<a href=\"{0}pn={1}\" class=\"btn btn-white\">{1}</a>", path, i);
                        }
                    }
                    if (Index < Count)
                    {
                        text.AppendFormat("<a href=\"{0}pn={1}\" class=\"btn btn-white\"><i class=\"fa fa-chevron-right\"></i></a>", path, Index + 1);
                    }
                    else
                    {
                        text.Append("<a class=\"btn btn-white\"><i class=\"fa fa-chevron-right\"></i></a>");
                    }
                }
                else
                {
                    text.Append("<a class=\"btn btn-white active-page\">1</a>");
                }
                text.Append("</div>");
                return text.ToString();
            }
        }
        void SetCount()
        {
            if (this.total == 0 || this.size == 0) return;
            this.Count = this.total / Size;
            if (this.total % Size > 0) this.Count = this.total / Size + 1;
        }
        /// <summary>
        /// 获取总页数。
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// 获取或设置路径。
        /// </summary>
        public string Path { get; set; }
    }

    /// <summary>
    /// 分页常量实体类
    /// </summary>
    public static class PagingConfig
    {
        public const int PAGE_SIZE = 12;
    }
}