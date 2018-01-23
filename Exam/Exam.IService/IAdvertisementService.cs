using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain.Model;

namespace Exam.IService
{
   public interface IAdvertisementService
    {

        Advertisement GetById(int Id);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Advertisement Insert(Advertisement model);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Update(Advertisement model);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Delete(Advertisement model);

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        bool IsExistName(string name);
        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<Advertisement> GetManagerList(string name, int typeId, int pageNum, int pageSize, out int totalCount);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<Advertisement> GetAll();
    }
}
