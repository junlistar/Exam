using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class GradeBusiness : IGradeBusiness
    {
        private IRepository<Grade> _repoGrade;

        public GradeBusiness(
          IRepository<Grade> repoGrade
          )
        {
            _repoGrade = repoGrade;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Grade GetById(int id)
        {
            return this._repoGrade.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Grade Insert(Grade model)
        {
            return this._repoGrade.Insert(model);
        } 

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Grade model)
        {
            this._repoGrade.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Grade model)
        {
            this._repoGrade.Delete(model);
        }
         
        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoGrade.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<Grade> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<Grade>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            totalCount = this._repoGrade.Table.Where(where).Count();
            return this._repoGrade.Table.Where(where).OrderBy(p => p.GradeId).Skip(pageNum * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Grade> GetAll()
        {
            return this._repoGrade.Table.ToList();
        }
    }
}


