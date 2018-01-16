using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public interface IProblemCollectBusiness
    { 
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProblemCollect GetById(int id);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ProblemCollect Insert(ProblemCollect model);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Update(ProblemCollect model);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Delete(ProblemCollect model);

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="userid"></param> 
        /// <param name="problemid"></param> 
        /// <returns></returns>
        bool IsExistName(int userid, int problemid);

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        List<ProblemCollect> GetManagerList(int userid, int pageNum, int pageSize, out int totalCount);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<ProblemCollect> GetAll(); 
    }
}
