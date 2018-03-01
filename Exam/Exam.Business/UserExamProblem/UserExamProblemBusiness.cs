using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class UserExamProblemBusiness : IUserExamProblemBusiness
    {
        private IRepository<UserExamProblem> _repoUserExamProblem;

        public UserExamProblemBusiness(
          IRepository<UserExamProblem> repoUserExamProblem
          )
        {
            _repoUserExamProblem = repoUserExamProblem;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserExamProblem GetById(int id)
        {
            return this._repoUserExamProblem.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserExamProblem Insert(UserExamProblem model)
        {
            return this._repoUserExamProblem.Insert(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoUserExamProblem.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(UserExamProblem model)
        {
            this._repoUserExamProblem.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(UserExamProblem model)
        {
            this._repoUserExamProblem.Delete(model);
        }
         

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<UserExamProblem> GetManagerList(int parentRecordId, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<UserExamProblem>();
             
            // name过滤
            if (parentRecordId != 0)
            {
                where = where.And(m => m.UserExamClassId == parentRecordId);
            }

            totalCount = this._repoUserExamProblem.Table.Where(where).Count();
            return this._repoUserExamProblem.Table.Where(where).OrderBy(p => p.UserExamProblemId).Skip((pageNum-1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<UserExamProblem> GetAll()
        {
            return this._repoUserExamProblem.Table.ToList();
        }
    }
}


