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
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoNewsInfo.Table.Any(p => p.Title == name);
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
            return this._repoNewsInfo.Table.Where(where).OrderBy(p => p.NewsInfoId).Skip((pageNum-1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<NewsInfo> GetAll()
        {
            return this._repoNewsInfo.Table.ToList();
        }

        /// <summary>
        /// 消息列表
        /// </summary> 
        /// <returns></returns>
        public List<NewsInfo> GetNewsInfoList(string name,int newsCategoryId,int isHot, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<NewsInfo>();

            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }
            if (newsCategoryId!=0)
            {
                where = where.And(m => m.NewsCategoryId== newsCategoryId);
            }
            if (isHot != 0)
            {
                where = where.And(m => m.isHot == isHot);
            }

            totalCount = this._repoNewsInfo.Table.Where(where).Count();
            return this._repoNewsInfo.Table.Where(where).OrderBy(p => p.NewsInfoId).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }
    }

   
}


