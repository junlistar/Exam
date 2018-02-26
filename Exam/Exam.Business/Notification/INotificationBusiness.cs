using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain.Model;

namespace Exam.Business
{
    /// <summary>
    /// 消息
    /// </summary>
    public interface INotificationBusiness
    {
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Notification GetById(int id);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Notification Insert(Notification model);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Update(Notification model);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Delete(Notification model);

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="userid"></param> 
        /// <param name="notificationId"></param> 
        /// <returns></returns>
        bool IsExistName(int userid, int notificationId);

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        List<Notification> GetManagerList(int userid, int pageNum, int pageSize, out int totalCount);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<Notification> GetAll();

        /// <summary>
        /// 我的收藏列表
        /// </summary> 
        /// <returns></returns>
        List<Notification> GetNotificationList(int userInfoId, int Status, int TypeId, int pageNum, int pageSize, out int totalCount);
    }
}
