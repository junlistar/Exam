using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class NewsCategoryBusiness : INewsCategoryBusiness
    {
        private IRepository<NewsCategory> _repoNewsCategory;

        public NewsCategoryBusiness(
          IRepository<NewsCategory> repoNewsCategory
          )
        {
            _repoNewsCategory = repoNewsCategory;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NewsCategory GetById(int id)
        {
            return this._repoNewsCategory.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public NewsCategory Insert(NewsCategory model)
        {
            return this._repoNewsCategory.Insert(model);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(NewsCategory model)
        {
            this._repoNewsCategory.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(NewsCategory model)
        {
            this._repoNewsCategory.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoNewsCategory.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<NewsCategory> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<NewsCategory>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            totalCount = this._repoNewsCategory.Table.Where(where).Count();
            return this._repoNewsCategory.Table.Where(where).OrderBy(p => p.NewsCategoryId).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<NewsCategory> GetAll()
        {
            return this._repoNewsCategory.Table.ToList();
        }
    }
}


