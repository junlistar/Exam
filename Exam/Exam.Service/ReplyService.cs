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
    public class ReplyService : IReplyService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IReplyBusiness _ReplyBiz;

        public ReplyService(IReplyBusiness ReplyBiz) {
            _ReplyBiz = ReplyBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Reply GetById(int id)
        {
            return this._ReplyBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Reply Insert(Reply model)
        {
            return this._ReplyBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Reply model)
        {
            this._ReplyBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Reply model)
        {
            this._ReplyBiz.Delete(model);
        }
 
        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<Reply> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._ReplyBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Reply> GetAll()
        {
            return this._ReplyBiz.GetAll();
        }
    }
}
