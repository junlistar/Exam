using Exam.Admin.Models;
using Exam.Common;
using Exam.Core.Utils;
using Exam.Domain;
using Exam.Domain.Model;
using Exam.IService;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Exam.Admin.Controllers
{
    /// <summary>
    /// ProblemRecord菜单
    /// </summary>
    public class ProblemRecordController : BaseController
    {
        // GET: ProblemRecord
        private readonly IProblemRecordService _ProblemRecordService;
        private readonly IUserInfoAnswerRecordService _UserInfoAnswerRecordService;
        public ProblemRecordController(IProblemRecordService ProblemRecordService, IUserInfoAnswerRecordService UserInfoAnswerRecordService)
        {
            _ProblemRecordService = ProblemRecordService;
            _UserInfoAnswerRecordService = UserInfoAnswerRecordService;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_ProblemRecordVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(ProblemRecordVM _ProblemRecordVM, int pn = 1)
        {
            int totalCount,
                pageIndex = pn,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _UserInfoAnswerRecordService.GetManagerList(_ProblemRecordVM.QueryUserInfoId, pageIndex, pageSize, out totalCount);
            var paging = new Paging<UserInfoAnswerRecord>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _ProblemRecordVM.Paging = paging;
            return View(_ProblemRecordVM);
        }

        /// <summary>
        /// 答题详情列表
        /// </summary>
        /// <param name="_ProblemRecordVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult ProblemList(ProblemRecordVM _ProblemRecordVM, int pn = 1)
        {
            int totalCount,
                pageIndex = pn,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _ProblemRecordService.GetManagerList(_ProblemRecordVM.Id, pageIndex, pageSize, out totalCount);
            var paging = new Paging<ProblemRecord>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _ProblemRecordVM.DetailPaging = paging;
            return View(_ProblemRecordVM);
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
                var entity = _ProblemRecordService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _ProblemRecordService.Delete(entity);

                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
    
    }
}