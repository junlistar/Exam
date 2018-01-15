using Exam.Admin.Models;
using Exam.Business;
using Exam.Common;
using Exam.Core.Infrastructure;
using Exam.Core.Utils;
using Exam.Domain;
using Exam.Domain.Model;
using Exam.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.Admin.Controllers
{
    public class ReplyController : Controller
    {
        //方式1 
        private readonly IReplyService _replyService;

        public ReplyController(IReplyService replyService)
        {
            _replyService = replyService;
        }

        /// <summary>
        /// 状态修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateStatus(int id = 0, Exam.Domain.EnumHelp.EnabledEnum isEnabled = EnumHelp.EnabledEnum.有效)
        {
            try
            {
                var entity = _replyService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }
                entity.IsEnable = (int)isEnabled;
                _replyService.Update(entity);
                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(int id = 0)
        {
            try
            {
                var entity = _replyService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _replyService.Delete(entity);

                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}