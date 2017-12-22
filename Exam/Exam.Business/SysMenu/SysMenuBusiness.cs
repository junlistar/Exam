using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class SysMenuBusiness : ISysMenuBusiness
    {
        private IRepository<SysMenu> _repoSysMenu;

        public SysMenuBusiness(
          IRepository<SysMenu> repoSysMenu
          )
        {
            _repoSysMenu = repoSysMenu;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysMenu GetById(int id)
        {
            return this._repoSysMenu.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SysMenu Insert(SysMenu model)
        {
            return this._repoSysMenu.Insert(model);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(SysMenu model)
        {
            this._repoSysMenu.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(SysMenu model)
        {
            this._repoSysMenu.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsExistName(string name,int type)
        {
            return this._repoSysMenu.Table.Any(p => p.Name == name && p.Type == type);
        }

        /// <summary>
        /// 管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<SysMenu> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<SysMenu>();

            where = where.And(m => m.Fid == 0);

            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Name.Contains(name));
            }

            totalCount = this._repoSysMenu.Table.Where(where).Count();
            return this._repoSysMenu.Table.Where(where).OrderBy(p => p.SortNo).Skip(pageNum * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<SysMenu> GetAll()
        {
            return this._repoSysMenu.Table.ToList();
        }
    }
}


