using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class ExamProblemBusiness : IExamProblemBusiness
    {
        private IRepository<ExamProblem> _repoExamProblem;

        public ExamProblemBusiness(
          IRepository<ExamProblem> repoExamProblem
          )
        {
            _repoExamProblem = repoExamProblem;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ExamProblem GetById(int id)
        {
            return this._repoExamProblem.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ExamProblem Insert(ExamProblem model)
        {
            return this._repoExamProblem.Insert(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoExamProblem.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(ExamProblem model)
        {
            this._repoExamProblem.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(ExamProblem model)
        {
            this._repoExamProblem.Delete(model);
        }
         

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<ExamProblem> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<ExamProblem>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            totalCount = this._repoExamProblem.Table.Where(where).Count();
            return this._repoExamProblem.Table.Where(where).OrderBy(p => p.ExamProblemId).Skip((pageNum-1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<ExamProblem> GetAll()
        {
            return this._repoExamProblem.Table.ToList();
        }
    }
}


