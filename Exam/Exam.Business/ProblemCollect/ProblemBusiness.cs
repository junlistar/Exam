using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class ProblemCollectBusiness : IProblemCollectBusiness
    {
        private IRepository<ProblemCollect> _repoProblemCollect;

        public ProblemCollectBusiness(
          IRepository<ProblemCollect> repoProblemCollect
          )
        {
            _repoProblemCollect = repoProblemCollect;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProblemCollect GetById(int id)
        {
            return this._repoProblemCollect.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ProblemCollect Insert(ProblemCollect model)
        {
            return this._repoProblemCollect.Insert(model);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(ProblemCollect model)
        {
            this._repoProblemCollect.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(ProblemCollect model)
        {
            this._repoProblemCollect.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="userid"></param> 
        /// <param name="problemid"></param> 
        /// <returns></returns>
        public bool IsExistName(int userid,int problemid)
        {
            return this._repoProblemCollect.Table.Any(p => p.UserInfoId == userid && p.ProblemId == problemid);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<ProblemCollect> GetManagerList(int userid, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<ProblemCollect>();

            // userid filter
            if (userid != 0)
            {
                where = where.And(m => m.UserInfoId == userid);
            }

            totalCount = this._repoProblemCollect.Table.Where(where).Count();
            return this._repoProblemCollect.Table.Where(where).OrderBy(p => p.ProblemCollectId).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<ProblemCollect> GetAll()
        {
            return this._repoProblemCollect.Table.ToList();
        }
         
    }
}


