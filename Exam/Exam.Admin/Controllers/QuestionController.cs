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
    public class QuestionController : Controller
    {
        //方式1
        private readonly IQuestionService _qeustionService;  
        private readonly IReplyService _replyService;

        //方式2 

        public QuestionController(IQuestionService qeustionService, IReplyService replyService, 
            ISysGroupService sysGroupService,
            IImageInfoService imageInfoService)
        {
            _qeustionService = qeustionService;
            _replyService = replyService; 
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_questionVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(QuestionVM _questionVM, int pn = 1)
        {
            int totalCount,
                pageIndex = pn,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _qeustionService.GetManagerList(_questionVM.QueryName, pageIndex, pageSize, out totalCount);
            var paging = new Paging<Question>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _questionVM.Paging = paging;
            return View(_questionVM);
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
                var entity = _qeustionService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }
                entity.IsEnable = (int)isEnabled;
                _qeustionService.Update(entity);
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
                var entity = _qeustionService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _qeustionService.Delete(entity);

                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 答案列表
        /// </summary> 
        /// <returns></returns>
        public ActionResult ReplyList(QuestionVM vm)
        {

            vm.Question = _qeustionService.GetById(vm.Id);

            var entity = _replyService.GetAll().Where(p=>p.QuestionId == vm.Id);

            vm.ReplyList = entity.ToList(); 


            return View(vm);
        }
    }
}