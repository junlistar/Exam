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
    public class LogService : ILogService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private ILogBusiness _LogBiz;

        public LogService(ILogBusiness LogBiz)
        {
            _LogBiz = LogBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Log GetById(int id)
        {
            return this._LogBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Log Insert(Log model)
        {
            return this._LogBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Log model)
        {
            this._LogBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Log model)
        {
            this._LogBiz.Delete(model);
        } 

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<Log> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._LogBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Log> GetAll()
        {
            return this._LogBiz.GetAll();
        }
         
    }
}
