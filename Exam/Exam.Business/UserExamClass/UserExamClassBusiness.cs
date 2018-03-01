using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class UserExamClassBusiness : IUserExamClassBusiness
    {
        private IRepository<UserExamClass> _repoUserExamClass;

        public UserExamClassBusiness(
          IRepository<UserExamClass> repoUserExamClass
          )
        {
            _repoUserExamClass = repoUserExamClass;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserExamClass GetById(int id)
        {
            return this._repoUserExamClass.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserExamClass Insert(UserExamClass model)
        {
            return this._repoUserExamClass.Insert(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoUserExamClass.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(UserExamClass model)
        {
            this._repoUserExamClass.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(UserExamClass model)
        {
            this._repoUserExamClass.Delete(model);
        }
         

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<UserExamClass> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<UserExamClass>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            totalCount = this._repoUserExamClass.Table.Where(where).Count();
            return this._repoUserExamClass.Table.Where(where).OrderBy(p => p.UserExamClassId).Skip((pageNum-1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<UserExamClass> GetAll()
        {
            return this._repoUserExamClass.Table.ToList();
        }
    }
}


