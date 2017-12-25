using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class NewsInfoBusiness : INewsInfoBusiness
    {
        private IRepository<NewsInfo> _repoNewsInfo;

        public NewsInfoBusiness(
          IRepository<NewsInfo> repoNewsInfo
          )
        {
            _repoNewsInfo = repoNewsInfo;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NewsInfo GetById(int id)
        {
            return this._repoNewsInfo.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public NewsInfo Insert(NewsInfo model)
        {
            return this._repoNewsInfo.Insert(model);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(NewsInfo model)
        {
            this._repoNewsInfo.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(NewsInfo model)
        {
            this._repoNewsInfo.Delete(model);
        }
         

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<NewsInfo> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<NewsInfo>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            totalCount = this._repoNewsInfo.Table.Where(where).Count();
            return this._repoNewsInfo.Table.Where(where).OrderBy(p => p.NewsInfoId).Skip(pageNum * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<NewsInfo> GetAll()
        {
            return this._repoNewsInfo.Table.ToList();
        }
    }
}


