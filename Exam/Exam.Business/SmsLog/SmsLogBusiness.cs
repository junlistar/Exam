using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class SmsLogBusiness : ISmsLogBusiness
    {
        private IRepository<SmsLog> _repoSmsLog;

        public SmsLogBusiness(
          IRepository<SmsLog> repoSmsLog
          )
        {
            _repoSmsLog = repoSmsLog;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SmsLog GetById(int id)
        {
            return this._repoSmsLog.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SmsLog Insert(SmsLog model)
        {
            return this._repoSmsLog.Insert(model);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(SmsLog model)
        {
            this._repoSmsLog.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(SmsLog model)
        {
            this._repoSmsLog.Delete(model);
        }
       

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<SmsLog> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<SmsLog>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Phone.Contains(name));
            }

            totalCount = this._repoSmsLog.Table.Where(where).Count();
            return this._repoSmsLog.Table.Where(where).OrderBy(p => p.SmsLogId).Skip((pageNum-1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<SmsLog> GetAll()
        {
            return this._repoSmsLog.Table.ToList();
        }
        
    }

   
}


