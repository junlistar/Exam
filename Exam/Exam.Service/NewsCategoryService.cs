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
    public class NewsCategoryService : INewsCategoryService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private INewsCategoryBusiness _NewsCategoryBiz;

        public NewsCategoryService(INewsCategoryBusiness NewsCategoryBiz)
        {
            _NewsCategoryBiz = NewsCategoryBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NewsCategory GetById(int id)
        {
            return this._NewsCategoryBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public NewsCategory Insert(NewsCategory model)
        {
            return this._NewsCategoryBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(NewsCategory model)
        {
            this._NewsCategoryBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(NewsCategory model)
        {
            this._NewsCategoryBiz.Delete(model);
        }
         
        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._NewsCategoryBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<NewsCategory> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._NewsCategoryBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<NewsCategory> GetAll()
        {
            return this._NewsCategoryBiz.GetAll();
        }
    }
}
