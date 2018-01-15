using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Core.Data;
using Exam.Domain.Model;

namespace Exam.Business
{
    public class ProblemRecordBusiness: IProblemRecordBusiness
    {
        private IRepository<ProblemRecord> _repoProblemRecord;

        public ProblemRecordBusiness(
          IRepository<ProblemRecord> repoProblemRecord
          )
        {
            _repoProblemRecord = repoProblemRecord;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProblemRecord GetById(int id)
        {
            return this._repoProblemRecord.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ProblemRecord Insert(ProblemRecord model)
        {
            return this._repoProblemRecord.Insert(model);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(ProblemRecord model)
        {
            this._repoProblemRecord.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(ProblemRecord model)
        {
            this._repoProblemRecord.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoProblemRecord.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<ProblemRecord> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<ProblemRecord>();

            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            totalCount = this._repoProblemRecord.Table.Where(where).Count();
            return this._repoProblemRecord.Table.Where(where).OrderBy(p => p.ProblemRecordId).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<ProblemRecord> GetAll()
        {
            return this._repoProblemRecord.Table.ToList();
        }
    }
}
