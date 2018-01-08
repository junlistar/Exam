using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class SysGroupBusiness : ISysGroupBusiness
    {
        private IRepository<SysGroup> _repoSysGroup;

        public SysGroupBusiness(
          IRepository<SysGroup> repoSysGroup
          )
        {
            _repoSysGroup = repoSysGroup;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysGroup GetById(int id)
        {
            return this._repoSysGroup.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SysGroup Insert(SysGroup model)
        {
            return this._repoSysGroup.Insert(model);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(SysGroup model)
        {
            this._repoSysGroup.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(SysGroup model)
        {
            this._repoSysGroup.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoSysGroup.Table.Any(p => p.Name == name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<SysGroup> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<SysGroup>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Name.Contains(name));
            }

            totalCount = this._repoSysGroup.Table.Where(where).Count();
            return this._repoSysGroup.Table.Where(where).OrderBy(p => p.SortNo).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<SysGroup> GetAll()
        {
            return this._repoSysGroup.Table.ToList();
        }
    }
}


