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
    public class SysMenuService : ISysMenuService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private ISysMenuBusiness _sysMenuBiz;

        public SysMenuService(ISysMenuBusiness sysMenuBiz) {
            _sysMenuBiz = sysMenuBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysMenu GetById(int id)
        {
            return this._sysMenuBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SysMenu Insert(SysMenu model)
        {
            return this._sysMenuBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(SysMenu model)
        {
            this._sysMenuBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(SysMenu model)
        {
            this._sysMenuBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsExistName(string name,int type)
        {
            return this._sysMenuBiz.IsExistName(name, type);
        }
        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<SysMenu> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._sysMenuBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<SysMenu> GetAll()
        {
            return this._sysMenuBiz.GetAll();
        }
    }
}
