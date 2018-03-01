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
    public class ExamProblemService : IExamProblemService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IExamProblemBusiness _ExamProblemBiz;

        public ExamProblemService(IExamProblemBusiness ExamProblemBiz) {
            _ExamProblemBiz = ExamProblemBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ExamProblem GetById(int id)
        {
            return this._ExamProblemBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ExamProblem Insert(ExamProblem model)
        {
            return this._ExamProblemBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(ExamProblem model)
        {
            this._ExamProblemBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(ExamProblem model)
        {
            this._ExamProblemBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._ExamProblemBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ExamProblem> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._ExamProblemBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<ExamProblem> GetAll()
        {
            return this._ExamProblemBiz.GetAll();
        }
    }
}
