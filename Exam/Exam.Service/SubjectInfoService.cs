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
    public class SubjectInfoService : ISubjectInfoService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private ISubjectInfoBusiness _SubjectInfoBiz;

        public SubjectInfoService(ISubjectInfoBusiness SubjectInfoBiz)
        {
            _SubjectInfoBiz = SubjectInfoBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SubjectInfo GetById(int id)
        {
            return this._SubjectInfoBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SubjectInfo Insert(SubjectInfo model)
        {
            return this._SubjectInfoBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(SubjectInfo model)
        {
            this._SubjectInfoBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(SubjectInfo model)
        {
            this._SubjectInfoBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._SubjectInfoBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<SubjectInfo> GetManagerList(string name, int typeId, int pageNum, int pageSize, out int totalCount)
        {
            return this._SubjectInfoBiz.GetManagerList(name,typeId,pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<SubjectInfo> GetAll()
        {
            return this._SubjectInfoBiz.GetAll();
        }
    }
}
