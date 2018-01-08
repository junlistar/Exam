using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class ReplyBusiness : IReplyBusiness
    {
        private IRepository<Reply> _repoReply;

        public ReplyBusiness(
          IRepository<Reply> repoReply
          )
        {
            _repoReply = repoReply;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Reply GetById(int id)
        {
            return this._repoReply.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Reply Insert(Reply model)
        {
            return this._repoReply.Insert(model);
        } 

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Reply model)
        {
            this._repoReply.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Reply model)
        {
            this._repoReply.Delete(model);
        }
         

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<Reply> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<Reply>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Content.Contains(name));
            }

            totalCount = this._repoReply.Table.Where(where).Count();
            return this._repoReply.Table.Where(where).OrderBy(p => p.ReplyId).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Reply> GetAll()
        {
            return this._repoReply.Table.ToList();
        }
    }
}


