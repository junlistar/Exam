using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class ExamAnswerBusiness : IExamAnswerBusiness
    {
        private IRepository<ExamAnswer> _repoExamAnswer;

        public ExamAnswerBusiness(
          IRepository<ExamAnswer> repoExamAnswer
          )
        {
            _repoExamAnswer = repoExamAnswer;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ExamAnswer GetById(int id)
        {
            return this._repoExamAnswer.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ExamAnswer Insert(ExamAnswer model)
        {
            return this._repoExamAnswer.Insert(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoExamAnswer.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(ExamAnswer model)
        {
            this._repoExamAnswer.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(ExamAnswer model)
        {
            this._repoExamAnswer.Delete(model);
        }
         

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<ExamAnswer> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<ExamAnswer>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            totalCount = this._repoExamAnswer.Table.Where(where).Count();
            return this._repoExamAnswer.Table.Where(where).OrderBy(p => p.ExamAnswerId).Skip((pageNum-1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<ExamAnswer> GetAll()
        {
            return this._repoExamAnswer.Table.ToList();
        }
    }
}


