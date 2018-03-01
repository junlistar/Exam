using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class UserExamAnswerBusiness : IUserExamAnswerBusiness
    {
        private IRepository<UserExamAnswer> _repoUserExamAnswer;

        public UserExamAnswerBusiness(
          IRepository<UserExamAnswer> repoUserExamAnswer
          )
        {
            _repoUserExamAnswer = repoUserExamAnswer;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserExamAnswer GetById(int id)
        {
            return this._repoUserExamAnswer.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserExamAnswer Insert(UserExamAnswer model)
        {
            return this._repoUserExamAnswer.Insert(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoUserExamAnswer.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(UserExamAnswer model)
        {
            this._repoUserExamAnswer.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(UserExamAnswer model)
        {
            this._repoUserExamAnswer.Delete(model);
        }
         

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<UserExamAnswer> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<UserExamAnswer>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            totalCount = this._repoUserExamAnswer.Table.Where(where).Count();
            return this._repoUserExamAnswer.Table.Where(where).OrderBy(p => p.UserExamAnswerId).Skip((pageNum-1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<UserExamAnswer> GetAll()
        {
            return this._repoUserExamAnswer.Table.ToList();
        }
    }
}


