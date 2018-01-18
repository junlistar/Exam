using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Core.Data;
using Exam.Domain.Model;

namespace Exam.Business
{
    public class NotificationBusiness
    {
        private IRepository<Notification> _repoNotification;

        public NotificationBusiness(
          IRepository<Notification> repoNotification
          )
        {
            _repoNotification = repoNotification;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Notification GetById(int id)
        {
            return this._repoNotification.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Notification Insert(Notification model)
        {
            return this._repoNotification.Insert(model);

        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Notification model)
        {
            this._repoNotification.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Notification model)
        {
            this._repoNotification.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="userid"></param> 
        /// <param name="problemid"></param> 
        /// <returns></returns>
        public bool IsExistName(int userid, int notificationId)
        {
            return this._repoNotification.Table.Any(p => p.UserInfoId == userid && p.NotificationId == notificationId);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<Notification> GetManagerList(int userid, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<Notification>();

            // userid filter
            if (userid != 0)
            {
                where = where.And(m => m.UserInfoId == userid);
            }

            totalCount = this._repoNotification.Table.Where(where).Count();
            return this._repoNotification.Table.Where(where).OrderBy(p => p.NotificationId).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Notification> GetAll()
        {
            return this._repoNotification.Table.ToList();
        }

        /// <summary>
        /// 我的收藏列表
        /// </summary> 
        /// <returns></returns>
        public List<Notification> GetNotificationList(int userInfoId, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<Notification>();
            where = where.And(m => m.UserInfoId == userInfoId);

            totalCount = this._repoNotification.Table.Where(where).Count();
            return this._repoNotification.Table.Where(where).OrderBy(p => p.NotificationId).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
