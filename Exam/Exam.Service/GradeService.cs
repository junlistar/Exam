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
    public class GradeService : IGradeService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IGradeBusiness _GradeBiz;

        public GradeService(IGradeBusiness GradeBiz) {
            _GradeBiz = GradeBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Grade GetById(int id)
        {
            return this._GradeBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Grade Insert(Grade model)
        {
            return this._GradeBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Grade model)
        {
            this._GradeBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Grade model)
        {
            this._GradeBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._GradeBiz.IsExistName(name);
        }
        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<Grade> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._GradeBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Grade> GetAll()
        {
            return this._GradeBiz.GetAll();
        }
    }
}
