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
    public class ProblemCategoryService : IProblemCategoryService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IProblemCategoryBusiness _ProblemCategoryBiz;

        public ProblemCategoryService(IProblemCategoryBusiness ProblemCategoryBiz) {
            _ProblemCategoryBiz = ProblemCategoryBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProblemCategory GetById(int id)
        {
            return this._ProblemCategoryBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ProblemCategory Insert(ProblemCategory model)
        {
            return this._ProblemCategoryBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(ProblemCategory model)
        {
            this._ProblemCategoryBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(ProblemCategory model)
        {
            this._ProblemCategoryBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._ProblemCategoryBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ProblemCategory> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._ProblemCategoryBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<ProblemCategory> GetAll()
        {
            return this._ProblemCategoryBiz.GetAll();
        }
    }
}
