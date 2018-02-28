using Exam.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exam.Service
{
    /// <summary>
    /// 抓取中级的服务
    /// </summary>
    public class IntermediateService
    {
        /// <summary>
        /// 获取中级科目
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static List<IdAndTitle> GetZJKeMu(string html)
        {
            var match = Regex.Matches(html, @"<div class=""CrosswiseMenuItem([\s\S]*?)</div>");
            var subList = new List<IdAndTitle>();
            foreach (Match m in match)
            {
                var id = Regex.Match(m.Value, @"scid=""\d+?""").Value.Replace("scid=\"", "")
                    .Replace("\"", "").Replace("/r", "").Replace("/n", "").Trim();
                var title = HttpHelp.ClearHtml(m.Value);
                subList.Add(new IdAndTitle()
                {
                    Id = id,
                    Title = title
                });
            }
            return subList;
        }

        
        public class IdAndTitle
        {
            public string Id { get; set; }
            public string Title { get; set; }
        }
    }
}
