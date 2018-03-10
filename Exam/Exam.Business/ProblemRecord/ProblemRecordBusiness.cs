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
        private IRepository<UserPractiseReportModel> _repoUserPractiseReport;
        private IRepository<ProblemPractiseReportModel> _repoProblemPractiseReport;

        public ProblemRecordBusiness(
          IRepository<ProblemRecord> repoProblemRecord,
          IRepository<UserPractiseReportModel> repoUserPractiseReport,
          IRepository<ProblemPractiseReportModel> repoProblemPractiseReport
          )
        {
            _repoProblemRecord = repoProblemRecord;
            _repoUserPractiseReport = repoUserPractiseReport;
            _repoProblemPractiseReport = repoProblemPractiseReport;
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
            if (parentRecordId != 0)
            {
                where = where.And(m => m.UserInfoAnswerRecordId == parentRecordId);
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
        public List<UserPractiseReportModel> GetUserPractiseReportList(int userInfoId, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<UserPractiseReportModel>();


            //t-sql
            string t_sql = @" select UserInfoId,COUNT(1) as totalCount,
  (select COUNT(1) from ProblemRecord a where YesOrNo = 1 and a.userinfoid = tmp_a.userinfoid) as rightCount,
  (select COUNT(1) from ProblemRecord a where YesOrNo = 2 and a.userinfoid = tmp_a.userinfoid) as wrongCount,
     MAX(CTime) as CTime
  FROM ProblemRecord tmp_a {0}
  group by userinfoid";
            string whereStr = " where 1=1 ";

            if (userInfoId != 0)
            {
                whereStr += "and  UserInfoId=" + userInfoId;
            }
            t_sql = string.Format(t_sql, whereStr);

            var result = this._repoUserPractiseReport.SqlQuery(t_sql, new object[] { });
             
            totalCount = result.Count();
            return result.OrderByDescending(p => p.CTime).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取个人做题统计(正确或者错误的题目列表)
        /// </summary> 
        /// <returns></returns>
        public List<ProblemRecord> GetUserPractiseReportList(int userInfoId, int yesno, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<ProblemRecord>();

            where = where.And(m => m.UserInfoId == userInfoId);

            if (yesno != 0)
            {
                where = where.And(m => m.YesOrNo == yesno);
            }

            totalCount = this._repoProblemRecord.Table.Where(where).Count();
            return this._repoProblemRecord.Table.Where(where).OrderByDescending(p => p.CTime).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取题目做题统计
        /// </summary> 
        /// <returns></returns>
        public List<ProblemPractiseReportModel> GetProblemPractiseReportList(int problemId, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<ProblemPractiseReportModel>();


            //t-sql
            string t_sql = @"select ProblemId,COUNT(1) as totalCount,
  (select COUNT(1) from ProblemRecord a where YesOrNo=1 and a.ProblemId=tmp_a.ProblemId) as rightCount,
  (select COUNT(1) from ProblemRecord a where YesOrNo=2 and a.ProblemId=tmp_a.ProblemId) as wrongCount,
    MAX(CTime) as CTime
  FROM ProblemRecord tmp_a {0}
  group by ProblemId";
            string whereStr = " where 1=1 ";

            if (problemId != 0)
            {
                whereStr += "and  ProblemId=" + problemId;
            }
            t_sql = string.Format(t_sql, whereStr);

            var result = this._repoProblemPractiseReport.SqlQuery(t_sql, new object[] { });

            totalCount = result.Count();
            return result.OrderByDescending(p => p.CTime).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取题目做题统计(正确或者错误的题目列表)
        /// </summary> 
        /// <returns></returns>
        public List<ProblemRecord> GetProblemPractiseReportList(int problemId, int yesno, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<ProblemRecord>();

            where = where.And(m => m.ProblemId == problemId);

            if (yesno!=0)
            {
                where = where.And(m => m.YesOrNo == yesno);
            }

            totalCount = this._repoProblemRecord.Table.Where(where).Count();
            return this._repoProblemRecord.Table.Where(where).OrderByDescending(p => p.CTime).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
