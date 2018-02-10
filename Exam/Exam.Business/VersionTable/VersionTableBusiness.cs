using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Core.Data;
using Exam.Domain.Model;

namespace Exam.Business
{
    public class VersionTableBusiness : IVersionTableBusiness
    {
        private IRepository<VersionTable> _repoVersionTable;

        public VersionTableBusiness(
          IRepository<VersionTable> repoVersionTable
          )
        {
            _repoVersionTable = repoVersionTable;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VersionTable GetById(int id)
        {
            return this._repoVersionTable.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public VersionTable Insert(VersionTable model)
        {
            return this._repoVersionTable.Insert(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoVersionTable.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(VersionTable model)
        {
            this._repoVersionTable.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(VersionTable model)
        {
            this._repoVersionTable.Delete(model);
        }


        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<VersionTable> GetManagerList(string name, int typeId, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<VersionTable>();

            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            if (typeId != 0)
            {
                where = where.And(m => m.TypeId == typeId);
            }

            totalCount = this._repoVersionTable.Table.Where(where).Count();
            return this._repoVersionTable.Table.Where(where).OrderBy(p => p.VersionTableId).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<VersionTable> GetAll()
        {
            return this._repoVersionTable.Table.ToList();
        }
    }
}
