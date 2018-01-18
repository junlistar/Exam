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
   public class ProblemRecordService: IProblemRecordService
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
        public List<ProblemRecord> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._ProblemRecordBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
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
        public List<ProblemRecord> GetForUserInfoRecordId(int userInfoAnswerRecordId) {
            return this._ProblemRecordBiz.GetForUserInfoRecordId(userInfoAnswerRecordId);
        }
    }
}
