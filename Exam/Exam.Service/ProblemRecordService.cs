using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Business;
using Exam.Domain.Model;
using Exam.IService;

namespace Exam.Service
{
    public class ProblemRecordService : IProblemRecordService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IProblemRecordBusiness _ProblemRecordBiz;

        public ProblemRecordService(IProblemRecordBusiness ProblemRecordBiz)
        {
            _ProblemRecordBiz = ProblemRecordBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProblemRecord GetById(int id)
        {
            return this._ProblemRecordBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ProblemRecord Insert(ProblemRecord model)
        {
            return this._ProblemRecordBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(ProblemRecord model)
        {
            this._ProblemRecordBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(ProblemRecord model)
        {
            this._ProblemRecordBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._ProblemRecordBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ProblemRecord> GetManagerList(int parentRecordId, int pageNum, int pageSize, out int totalCount)
        {
            return this._ProblemRecordBiz.GetManagerList(parentRecordId, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<ProblemRecord> GetAll()
        {
            return this._ProblemRecordBiz.GetAll();
        }

        /// <summary>
        /// 根据记录id获取测试过的题目
        /// </summary> 
        /// <returns></returns>
        public List<ProblemRecord> GetForUserInfoRecordId(int userInfoAnswerRecordId)
        {
            return this._ProblemRecordBiz.GetForUserInfoRecordId(userInfoAnswerRecordId);
        }


        /// <summary>
        /// 用户答题记录统计列表
        /// </summary>
        /// <param name="userInfoId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<UserPractiseReportModel> GetUserPractiseReportList(int userInfoId, int pageNum, int pageSize, out int totalCount)
        {
            return this._ProblemRecordBiz.GetUserPractiseReportList(userInfoId, pageNum, pageSize, out totalCount);
        }

        /// <summary>
        /// 获取个人做题统计(正确或者错误的题目列表)
        /// </summary> 
        /// <returns></returns>
        public List<ProblemRecord> GetUserPractiseReportList(int userInfoId, int yesno, int pageNum, int pageSize, out int totalCount)
        {
            return this._ProblemRecordBiz.GetUserPractiseReportList(userInfoId, yesno, pageNum, pageSize, out totalCount);
        }

        /// <summary>
        /// 获取题目做题统计列表
        /// </summary>
        /// <param name="problemId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<ProblemPractiseReportModel> GetProblemPractiseReportList(int problemId, int pageNum, int pageSize, out int totalCount)
        {
            return this._ProblemRecordBiz.GetProblemPractiseReportList(problemId, pageNum, pageSize, out totalCount);
        }

        /// <summary>
        /// 获取题目做题统计列表(正确或者错误的题目列表)
        /// </summary> 
        /// <returns></returns>
        public List<ProblemRecord> GetProblemPractiseReportList(int problemId, int yesno, int pageNum, int pageSize, out int totalCount)
        {
            return this._ProblemRecordBiz.GetProblemPractiseReportList(problemId, yesno, pageNum, pageSize, out totalCount);
        }
    }
}
