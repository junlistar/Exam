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
    /// UserExamClass菜单
    /// </summary>
    public class UserExamClassController : BaseController
    {
        // GET: UserExamClass
        private readonly IUserExamClassService _UserExamClassService;
        private readonly IUserExamProblemService _UserExamProblemService;
        public UserExamClassController(IUserExamClassService UserExamClassService, IUserExamProblemService UserExamProblemService)
        {
            _UserExamClassService = UserExamClassService;
            _UserExamProblemService = UserExamProblemService;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_UserExamClassVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(UserExamClassVM _UserExamClassVM, int pn = 1)
        {
            int totalCount,
                pageIndex = pn,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _UserExamClassService.GetManagerList(_UserExamClassVM.QueryUserInfoId, pageIndex, pageSize, out totalCount);
            var paging = new Paging<UserExamClass>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _UserExamClassVM.Paging = paging;
            return View(_UserExamClassVM);
        }

        /// <summary>
        /// 答题详情列表
        /// </summary>
        /// <param name="_UserExamClassVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult ProblemList(UserExamClassVM _UserExamClassVM, int pn = 1)
        {
            int totalCount,
                pageIndex = pn,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _UserExamProblemService.GetManagerList(_UserExamClassVM.Id, pageIndex, pageSize, out totalCount);
            var paging = new Paging<UserExamProblem>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _UserExamClassVM.DetailPaging = paging;
            return View(_UserExamClassVM);
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
                var entity = _UserExamClassService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _UserExamClassService.Delete(entity);

                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
    
    }
}