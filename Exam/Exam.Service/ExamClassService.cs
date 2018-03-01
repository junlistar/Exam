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
    public class ExamClassService : IExamClassService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IExamClassBusiness _ExamClassBiz;

        public ExamClassService(IExamClassBusiness ExamClassBiz) {
            _ExamClassBiz = ExamClassBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ExamClass GetById(int id)
        {
            return this._ExamClassBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ExamClass Insert(ExamClass model)
        {
            return this._ExamClassBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(ExamClass model)
        {
            this._ExamClassBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(ExamClass model)
        {
            this._ExamClassBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._ExamClassBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ExamClass> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._ExamClassBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<ExamClass> GetAll()
        {
            return this._ExamClassBiz.GetAll();
        }

        /// <summary>
        /// 获取考试分类
        /// </summary> 
        /// <returns></returns>
        public List<ExamClass> GetExamClassList() {
            return this._ExamClassBiz.GetExamClassList();
        }
    }
}
