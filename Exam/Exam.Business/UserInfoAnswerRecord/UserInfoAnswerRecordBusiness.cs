using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Core.Data;
using Exam.Domain.Model;

namespace Exam.Business
{
    public class UserInfoAnswerRecordBusiness : IUserInfoAnswerRecordBusiness
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
        public List<UserInfoAnswerRecord> GetManagerList(int userinfoId, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<UserInfoAnswerRecord>();

            // userinfoId
            if (userinfoId != 0)
            {
                where = where.And(m => m.UserInfoId == userinfoId);
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

        /// <summary>
        /// 根据用户ID得到答题记录
        /// </summary>
        /// <returns></returns>
        public List<UserInfoAnswerRecord> GetListForUserInfoId(int userInfoId, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<UserInfoAnswerRecord>();

            where = where.And(m => m.UserInfoId == userInfoId);

            totalCount = this._repoUserInfoAnswerRecord.Table.Where(where).Count();
            return this._repoUserInfoAnswerRecord.Table.Where(where).OrderBy(p => p.UserInfoAnswerRecordId).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }
        /// <summary>
        /// 通过章节编号，用户编号，获取用户最后一次对于该章节的答题记录
        /// </summary>
        /// <param name="belongId">科目编号</param>
        /// <param name="chapterId">章节编号</param>
        /// <param name="userInfoId">用户编号</param>
        /// <returns></returns>
        public UserInfoAnswerRecord GetUserLastRecord(int chapterId, int userInfoId)
        {
            var where = PredicateBuilder.True<UserInfoAnswerRecord>();

            where = where.And(m => m.UserInfoId == userInfoId);
            where = where.And(m => m.ChapterId == chapterId);
            return this._repoUserInfoAnswerRecord.Table.Where(where).OrderByDescending(p => p.UTime).FirstOrDefault();
            //return this._repoUserInfoAnswerRecord.Table.Where(where).OrderByDescending(p => p.UTime).First();

        }

    }
}
