using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.IService
{
    public interface ILecturerService
    {
        Lecturer GetById(int Id);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Lecturer Insert(Lecturer model);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Update(Lecturer model);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Delete(Lecturer model);
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
        List<Lecturer> GetManagerList(string name, int pageNum, int pageSize,out int totalCount);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<Lecturer> GetAll();

        
    }
}
