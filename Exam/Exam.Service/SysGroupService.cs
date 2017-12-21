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
    public class SysGroupService : ISysGroupService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private ISysGroupBusiness _SysGroupBiz;

        public SysGroupService(ISysGroupBusiness SysGroupBiz) {
            _SysGroupBiz = SysGroupBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysGroup GetById(int id)
        {
            return this._SysGroupBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SysGroup Insert(SysGroup model)
        {
            return this._SysGroupBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(SysGroup model)
        {
            this._SysGroupBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(SysGroup model)
        {
            this._SysGroupBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._SysGroupBiz.IsExistName(name);
        }
        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<SysGroup> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._SysGroupBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<SysGroup> GetAll()
        {
            return this._SysGroupBiz.GetAll();
        }
    }
}
