using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Business;
using Exam.Domain.Model;
using Exam.IService;

namespace Exam.Service
{
    public class NotificationService: INotificationService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private INotificationBusiness _NotificationtBiz;

        public NotificationService(INotificationBusiness NotificationBiz)
        {
            _NotificationtBiz = NotificationBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Notification GetById(int id)
        {
            return this._NotificationtBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Notification Insert(Notification model)
        {
            return this._NotificationtBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Notification model)
        {
            this._NotificationtBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Notification model)
        {
            this._NotificationtBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="userid"></param> 
        /// <param name="notificationId"></param> 
        /// <returns></returns>
        public bool IsExistName(int userid, int notificationId)
        {
            return this._NotificationtBiz.IsExistName(userid, notificationId);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<Notification> GetManagerList(int userid, int pageNum, int pageSize, out int totalCount)
        {
            return this._NotificationtBiz.GetManagerList(userid, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Notification> GetAll()
        {
            return this._NotificationtBiz.GetAll();
        }


        /// <summary>
        /// 我的收藏列表
        /// </summary> 
        /// <returns></returns>
        public List<Notification> GetNotificationList(int userInfoId, int pageNum, int pageSize, out int totalCount)
        {
            return this._NotificationtBiz.GetNotificationList(userInfoId, pageNum, pageSize, out totalCount);
        }
    }
}
