using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class ProblemCategoryBusiness : IProblemCategoryBusiness
    {
        private IRepository<ProblemCategory> _repoProblemCategory;

        public ProblemCategoryBusiness(
          IRepository<ProblemCategory> repoProblemCategory
          )
        {
            _repoProblemCategory = repoProblemCategory;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProblemCategory GetById(int id)
        {
            return this._repoProblemCategory.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ProblemCategory Insert(ProblemCategory model)
        {
            return this._repoProblemCategory.Insert(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoProblemCategory.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(ProblemCategory model)
        {
            this._repoProblemCategory.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(ProblemCategory model)
        {
            this._repoProblemCategory.Delete(model);
        }
         

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<ProblemCategory> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<ProblemCategory>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            totalCount = this._repoProblemCategory.Table.Where(where).Count();
            return this._repoProblemCategory.Table.Where(where).OrderBy(p => p.ProblemCategoryId).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<ProblemCategory> GetAll()
        {
            return this._repoProblemCategory.Table.ToList();
        }
    }
}


