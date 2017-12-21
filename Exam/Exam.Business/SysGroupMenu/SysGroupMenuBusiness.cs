using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class SysGroupMenuBusiness : ISysGroupMenuBusiness
    {
        private IRepository<SysGroupMenu> _repoSysGroupMenu;

        public SysGroupMenuBusiness(
          IRepository<SysGroupMenu> repoSysGroupMenu
          )
        {
            _repoSysGroupMenu = repoSysGroupMenu;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysGroupMenu GetById(int id)
        {
            return this._repoSysGroupMenu.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SysGroupMenu Insert(SysGroupMenu model)
        {
            return this._repoSysGroupMenu.Insert(model);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(SysGroupMenu model)
        {
            this._repoSysGroupMenu.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(SysGroupMenu model)
        {
            this._repoSysGroupMenu.Delete(model);
        }

        /// <summary>
        /// 删除实体( groupId )
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void DeleteByGroupId(int groupId)
        {
            var entities = _repoSysGroupMenu.Table.Where(p => p.SysGroupId == groupId);
            if (entities != null && entities.Count() > 0)
            {
                this._repoSysGroupMenu.Delete(entities); 
            }
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<SysGroupMenu> GetAll()
        {
            return this._repoSysGroupMenu.Table.ToList();
        }
    }
}


