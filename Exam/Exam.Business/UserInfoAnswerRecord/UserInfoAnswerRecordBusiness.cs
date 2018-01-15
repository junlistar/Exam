using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Core.Data;
using Exam.Domain.Model;

namespace Exam.Business
{
   public class UserInfoAnswerRecordBusiness:IUserInfoAnswerRecordBusiness
    {
        private IRepository<UserInfoAnswerRecord> _repoUserInfoAnswerRecord;

        public UserInfoAnswerRecordBusiness(
          IRepository<UserInfoAnswerRecord> repoUserInfoAnswerRecord
          )
        {
            _repoUserInfoAnswerRecord = repoUserInfoAnswerRecord;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfoAnswerRecord GetById(int id)
        {
            return this._repoUserInfoAnswerRecord.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserInfoAnswerRecord Insert(UserInfoAnswerRecord model)
        {
            return this._repoUserInfoAnswerRecord.Insert(model);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(UserInfoAnswerRecord model)
        {
            this._repoUserInfoAnswerRecord.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(UserInfoAnswerRecord model)
        {
            this._repoUserInfoAnswerRecord.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoUserInfoAnswerRecord.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<UserInfoAnswerRecord> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<UserInfoAnswerRecord>();

            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            totalCount = this._repoUserInfoAnswerRecord.Table.Where(where).Count();
            return this._repoUserInfoAnswerRecord.Table.Where(where).OrderBy(p => p.UserInfoAnswerRecordId).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<UserInfoAnswerRecord> GetAll()
        {
            return this._repoUserInfoAnswerRecord.Table.ToList();
        }
    }
}
