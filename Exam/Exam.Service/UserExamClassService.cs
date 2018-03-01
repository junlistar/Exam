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
    public class UserExamClassService : IUserExamClassService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IUserExamClassBusiness _UserExamClassBiz;

        public UserExamClassService(IUserExamClassBusiness UserExamClassBiz) {
            _UserExamClassBiz = UserExamClassBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserExamClass GetById(int id)
        {
            return this._UserExamClassBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserExamClass Insert(UserExamClass model)
        {
            return this._UserExamClassBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(UserExamClass model)
        {
            this._UserExamClassBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(UserExamClass model)
        {
            this._UserExamClassBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._UserExamClassBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<UserExamClass> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._UserExamClassBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<UserExamClass> GetAll()
        {
            return this._UserExamClassBiz.GetAll();
        }
    }
}
