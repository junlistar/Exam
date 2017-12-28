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
    public class QuestionService : IQuestionService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IQuestionBusiness _QuestionBiz;

        public QuestionService(IQuestionBusiness QuestionBiz) {
            _QuestionBiz = QuestionBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Question GetById(int id)
        {
            return this._QuestionBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Question Insert(Question model)
        {
            return this._QuestionBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Question model)
        {
            this._QuestionBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Question model)
        {
            this._QuestionBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._QuestionBiz.IsExistName(name);
        }
        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<Question> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._QuestionBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Question> GetAll()
        {
            return this._QuestionBiz.GetAll();
        }
    }
}
