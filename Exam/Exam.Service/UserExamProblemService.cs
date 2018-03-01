using Exam.Business;
using Exam.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain.Model;

namespace Exam.Service
{
    public class UserExamProblemService : IUserExamProblemService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IUserExamProblemBusiness _UserExamProblemBiz;

        public UserExamProblemService(IUserExamProblemBusiness UserExamProblemBiz) {
            _UserExamProblemBiz = UserExamProblemBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserExamProblem GetById(int id)
        {
            return this._UserExamProblemBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserExamProblem Insert(UserExamProblem model)
        {
            return this._UserExamProblemBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(UserExamProblem model)
        {
            this._UserExamProblemBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(UserExamProblem model)
        {
            this._UserExamProblemBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._UserExamProblemBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<UserExamProblem> GetManagerList(int parentRecordId, int pageNum, int pageSize, out int totalCount)
        {
            return this._UserExamProblemBiz.GetManagerList(parentRecordId, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<UserExamProblem> GetAll()
        {
            return this._UserExamProblemBiz.GetAll();
        }
    }
}
