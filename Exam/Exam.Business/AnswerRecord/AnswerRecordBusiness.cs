using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Core.Data;
using Exam.Domain.Model;

namespace Exam.Business
{
    public class AnswerRecordBusiness: IAnswerRecordBusiness
    {
        private IRepository<AnswerRecord> _repoAnswerRecord;

        public AnswerRecordBusiness(
          IRepository<AnswerRecord> repoAnswerRecord
          )
        {
            _repoAnswerRecord = repoAnswerRecord;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AnswerRecord GetById(int id)
        {
            return this._repoAnswerRecord.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public AnswerRecord Insert(AnswerRecord model)
        {
            return this._repoAnswerRecord.Insert(model);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(AnswerRecord model)
        {
            this._repoAnswerRecord.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(AnswerRecord model)
        {
            this._repoAnswerRecord.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoAnswerRecord.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<AnswerRecord> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<AnswerRecord>();

            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            totalCount = this._repoAnswerRecord.Table.Where(where).Count();
            return this._repoAnswerRecord.Table.Where(where).OrderBy(p => p.AnswerRecordId).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<AnswerRecord> GetAll()
        {
            return this._repoAnswerRecord.Table.ToList();
        }
    }
}
