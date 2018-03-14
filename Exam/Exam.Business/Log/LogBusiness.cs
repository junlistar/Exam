using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class LogBusiness : ILogBusiness
    {
        private IRepository<Log> _repoLog;

        public LogBusiness(
          IRepository<Log> repoLog
          )
        {
            _repoLog = repoLog;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Log GetById(int id)
        {
            return this._repoLog.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Log Insert(Log model)
        {
            return this._repoLog.Insert(model);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Log model)
        {
            this._repoLog.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Log model)
        {
            this._repoLog.Delete(model);
        }
       

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<Log> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<Log>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.TargetTitle.Contains(name));
            }

            totalCount = this._repoLog.Table.Where(where).Count();
            return this._repoLog.Table.Where(where).OrderBy(p => p.LogId).Skip((pageNum-1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Log> GetAll()
        {
            return this._repoLog.Table.ToList();
        }
        
    }

   
}


