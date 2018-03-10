using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain.Model;

namespace Exam.Business
{
   public interface IProblemRecordBusiness
    {
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProblemRecord GetById(int id);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ProblemRecord Insert(ProblemRecord model);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Update(ProblemRecord model);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Delete(ProblemRecord model);

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        bool IsExistName(string name);

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<ProblemRecord> GetManagerList(int parentRecordId, int pageNum, int pageSize, out int totalCount);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<ProblemRecord> GetAll();

        /// <summary>
        /// 根据记录id获取测试过的题目
        /// </summary> 
        /// <returns></returns>
        List<ProblemRecord> GetForUserInfoRecordId(int userInfoAnswerRecordId);

        /// <summary>
        /// 用户答题记录统计列表
        /// </summary>
        /// <param name="userInfoId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<UserPractiseReportModel> GetUserPractiseReportList(int userInfoId, int pageNum, int pageSize, out int totalCount);
        
        /// <summary>
        /// 获取个人做题统计(正确或者错误的题目列表)
        /// </summary> 
        /// <returns></returns>
        List<ProblemRecord> GetUserPractiseReportList(int userInfoId, int yesno, int pageNum, int pageSize, out int totalCount);

        /// <summary>
        /// 获取题目做题统计列表
        /// </summary>
        /// <param name="problemId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<ProblemPractiseReportModel> GetProblemPractiseReportList(int problemId, int pageNum, int pageSize, out int totalCount);

        /// <summary>
        /// 获取题目做题统计(正确或者错误的题目列表)
        /// </summary> 
        /// <returns></returns>
        List<ProblemRecord> GetProblemPractiseReportList(int problemId, int yesno, int pageNum, int pageSize, out int totalCount);
    }
}
