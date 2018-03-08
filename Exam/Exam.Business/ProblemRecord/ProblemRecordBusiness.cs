using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Core.Data;
using Exam.Domain.Model;

namespace Exam.Business
{
    public class ProblemRecordBusiness : IProblemRecordBusiness
    {
        private IRepository<ProblemRecord> _repoProblemRecord;

        public ProblemRecordBusiness(
          IRepository<ProblemRecord> repoProblemRecord
          )
        {
            _repoProblemRecord = repoProblemRecord;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProblemRecord GetById(int id)
        {
            return this._repoProblemRecord.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ProblemRecord Insert(ProblemRecord model)
        {
            return this._repoProblemRecord.Insert(model);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(ProblemRecord model)
        {
            this._repoProblemRecord.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(ProblemRecord model)
        {
            this._repoProblemRecord.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoProblemRecord.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<ProblemRecord> GetManagerList(int parentRecordId, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<ProblemRecord>();

            // parentRecordId
            if (parentRecordId!=0)
            {
                where = where.And(m => m.UserInfoAnswerRecordId== parentRecordId);
            }

            totalCount = this._repoProblemRecord.Table.Where(where).Count();
            return this._repoProblemRecord.Table.Where(where).OrderBy(p => p.ProblemRecordId).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<ProblemRecord> GetAll()
        {
            return this._repoProblemRecord.Table.ToList();
        }

        /// <summary>
        /// 根据记录id获取测试过的题目
        /// </summary> 
        /// <returns></returns>
        public List<ProblemRecord> GetForUserInfoRecordId(int userInfoAnswerRecordId)
        {
            var where = PredicateBuilder.True<ProblemRecord>();

            where = where.And(m => m.UserInfoAnswerRecordId == userInfoAnswerRecordId);
            
            return this._repoProblemRecord.Table.Where(where).OrderBy(p => p.ProblemRecordId).ToList();
        }

        /// <summary>
        /// 获取个人做题统计
        /// </summary> 
        /// <returns></returns>
        public List<ProblemRecord> GetUserPractiseReportList(int userInfoId, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<ProblemRecord>();


            //t-sql
            string t_sql = @" select UserInfoId,COUNT(1) as totalCount,
  (select COUNT(1) from ProblemRecord a where YesOrNo = 1 and a.userinfoid = tmp_a.userinfoid) as rightCount,
  (select COUNT(1) from ProblemRecord a where YesOrNo = 2 and a.userinfoid = tmp_a.userinfoid) as wrongCount
  FROM ProblemRecord tmp_a
  group by userinfoid";

            var result = this._repoProblemRecord.SqlQuery(t_sql,null).AsQueryable();

            if (userInfoId != 0)
            {
                where = where.And(m => m.UserInfoId == userInfoId);
            } 
            totalCount = result.Where(where).GroupBy(p=>p.UserInfoId).Count();
            return this._repoProblemRecord.Table.Where(where).OrderBy(p => p.UserInfoId).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        } 
    }
}
