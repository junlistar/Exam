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
    public class VersionTableService : IVersionTableService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IVersionTableBusiness _VersionTableBiz;

        public VersionTableService(IVersionTableBusiness VersionTableBiz)
        {
            _VersionTableBiz = VersionTableBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VersionTable GetById(int id)
        {
            return this._VersionTableBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public VersionTable Insert(VersionTable model)
        {
            return this._VersionTableBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(VersionTable model)
        {
            this._VersionTableBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(VersionTable model)
        {
            this._VersionTableBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._VersionTableBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<VersionTable> GetManagerList(string name, int typeId, int pageNum, int pageSize, out int totalCount)
        {
            return this._VersionTableBiz.GetManagerList(name,typeId,pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<VersionTable> GetAll()
        {
            return this._VersionTableBiz.GetAll();
        }
    }
}
