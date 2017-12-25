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
    public class NewsInfoService : INewsInfoService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private INewsInfoBusiness _NewsInfoBiz;

        public NewsInfoService(INewsInfoBusiness NewsInfoBiz) {
            _NewsInfoBiz = NewsInfoBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NewsInfo GetById(int id)
        {
            return this._NewsInfoBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public NewsInfo Insert(NewsInfo model)
        {
            return this._NewsInfoBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(NewsInfo model)
        {
            this._NewsInfoBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(NewsInfo model)
        {
            this._NewsInfoBiz.Delete(model);
        }
         
        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<NewsInfo> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._NewsInfoBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<NewsInfo> GetAll()
        {
            return this._NewsInfoBiz.GetAll();
        }
    }
}
