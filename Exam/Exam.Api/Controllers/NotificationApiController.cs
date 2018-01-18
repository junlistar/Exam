using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exam.Api.Models;
using Exam.Core.Infrastructure;
using Exam.Domain.Model;
using Exam.IService;

namespace Exam.Api.Controllers
{
    /// <summary>
    /// 消息
    /// </summary>
    public class NotificationApiController : ApiController
    {
        private readonly INotificationService _notificationService = EngineContext.Current.Resolve<INotificationService>();

        /// <summary>
        /// 添加消息
        /// </summary>
        /// <param name="addNotificationDto"></param>
        /// <returns></returns>
        public IHttpActionResult AddNotification(AddNotificationDto addNotificationDto)
        {
            _notificationService.Insert(new Domain.Model.Notification
            {
                CTime = DateTime.Now,
                ObjectId = addNotificationDto.ObjectId,
                Title = addNotificationDto.Title,
                TypeId = addNotificationDto.TypeId,
                UserInfoId = addNotificationDto.UserInfoId,
                UTime = DateTime.Now
            });
            return Json(new { Success = true, Msg = "OK", Data = "" });
        }

        /// <summary>
        /// 我的消息
        /// </summary>
        /// <param name="selNotificationDto"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetNotificationList([FromUri]SelNotificationDto selNotificationDto)
        {
            ResultJson<Notification> list = new ResultJson<Notification>();
            int count = 0;
            list.Data = _notificationService.GetNotificationList(selNotificationDto.UserInfoId, selNotificationDto.PageIndex, selNotificationDto.PageSize, out count);
            list.RCount = count;
            list.PCount = count % selNotificationDto.PageSize == 0 ? (count / selNotificationDto.PageSize) : (count / selNotificationDto.PageSize + 1);//(count + pageDto.PageIndex - 1) / pageDto.PageSize;

            return Json(new { Success = true, Msg = "OK", Data = list });
        }
    }
}
