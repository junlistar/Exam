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
    public class ProblemCollectService : IProblemCollectService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IProblemCollectBusiness _ProblemCollectBiz;

        public ProblemCollectService(IProblemCollectBusiness ProblemCollectBiz)
        {
            _ProblemCollectBiz = ProblemCollectBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProblemCollect GetById(int id)
        {
            return this._ProblemCollectBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ProblemCollect Insert(ProblemCollect model)
        {
            return this._ProblemCollectBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(ProblemCollect model)
        {
            this._ProblemCollectBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(ProblemCollect model)
        {
            this._ProblemCollectBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="userid"></param> 
        /// <param name="problemid"></param> 
        /// <returns></returns>
        public bool IsExistName(int userid, int problemid)
        {
            return this._ProblemCollectBiz.IsExistName(userid, problemid);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<ProblemCollect> GetManagerList(int userid, int pageNum, int pageSize, out int totalCount)
        {
            return this._ProblemCollectBiz.GetManagerList(userid, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<ProblemCollect> GetAll()
        {
            return this._ProblemCollectBiz.GetAll();
        }

    }
}
