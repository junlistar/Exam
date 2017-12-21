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
    public class SysGroupMenuService : ISysGroupMenuService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private ISysGroupMenuBusiness _sysGroupMenuBiz;

        public SysGroupMenuService(ISysGroupMenuBusiness sysGroupMenuBiz) {
            _sysGroupMenuBiz = sysGroupMenuBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysGroupMenu GetById(int id)
        {
            return this._sysGroupMenuBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SysGroupMenu Insert(SysGroupMenu model)
        {
            return this._sysGroupMenuBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(SysGroupMenu model)
        {
            this._sysGroupMenuBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(SysGroupMenu model)
        {
            this._sysGroupMenuBiz.Delete(model);
        }

        /// <summary>
        /// 删除实体( groupId )
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public void DeleteByGroupId(int groupId)
        {
            this._sysGroupMenuBiz.DeleteByGroupId(groupId);
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<SysGroupMenu> GetAll()
        {
            return this._sysGroupMenuBiz.GetAll();
        }
    }
}
