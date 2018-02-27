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
    /// ProblemCollect菜单
    /// </summary>
    public class ProblemCollectController : BaseController
    {
        // GET: ProblemCollect
        private readonly IProblemCollectService _ProblemCollectService;
        public ProblemCollectController(IProblemCollectService ProblemCollectService)
        {
            _ProblemCollectService = ProblemCollectService;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_ProblemCollectVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(ProblemCollectVM _ProblemCollectVM, int pn = 1)
        {
            int totalCount,
                pageIndex = pn,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _ProblemCollectService.GetManagerList(_ProblemCollectVM.QueryUserInfoId, pageIndex, pageSize, out totalCount);
            var paging = new Paging<ProblemCollect>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _ProblemCollectVM.Paging = paging;
            return View(_ProblemCollectVM);
        }
        
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="_ProblemCollectVM"></param>
        /// <returns></returns>
        public ActionResult Edit(ProblemCollectVM _ProblemCollectVM)
        {
            _ProblemCollectVM.ProblemCollect = _ProblemCollectService.GetById(_ProblemCollectVM.Id) ?? new ProblemCollect(); 
            return View(_ProblemCollectVM);
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
                var entity = _ProblemCollectService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _ProblemCollectService.Delete(entity);

                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
    
    }
}