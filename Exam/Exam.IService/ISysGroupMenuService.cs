using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.IService
{
    public interface ISysGroupMenuService
    {
        SysGroupMenu GetById(int Id);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        SysGroupMenu Insert(SysGroupMenu model);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Update(SysGroupMenu model);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Delete(SysGroupMenu model);

        /// <summary>
        /// 删除实体( groupId )
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void DeleteByGroupId(int groupId);

        ///<summary>
        /// 获取所有
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<SysGroupMenu> GetAll();
    }
}
