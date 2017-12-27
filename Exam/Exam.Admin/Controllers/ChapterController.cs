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
    /// Chapter菜单
    /// </summary>
    public class ChapterController : BaseController
    {
        // GET: Chapter
        private readonly IChapterService _ChapterService;
        public ChapterController(IChapterService ChapterService)
        {
            _ChapterService = ChapterService;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_ChapterVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(ChapterVM _ChapterVM, int pn = 1)
        {
            int totalCount,
                pageIndex = (pn - 1) * PagingConfig.PAGE_SIZE,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _ChapterService.GetManagerList(_ChapterVM.QueryName, pageIndex, pageSize, out totalCount);
            var paging = new Paging<Chapter>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _ChapterVM.Paging = paging;
            return View(_ChapterVM);
        }
        
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="_ChapterVM"></param>
        /// <returns></returns>
        public ActionResult Edit(ChapterVM _ChapterVM)
        {
            _ChapterVM.Chapter = _ChapterService.GetById(_ChapterVM.Id) ?? new Chapter(); 
            return View(_ChapterVM);
        }
        /// <summary>
        /// 添加、修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Edit(Chapter model)
        {
            try
            {
                if (model.ChapterId > 0)
                {
                    var entity = _ChapterService.GetById(model.ChapterId);
                    //修改 
                    entity.ChapterId = model.ChapterId;
                    entity.Title = model.Title;
                    entity.UTime = model.UTime; 
                    entity.Sort= model.Sort; 
                    _ChapterService.Update(entity);
                }
                else
                {
                    if (_ChapterService.IsExistName(model.Title))
                        return Json(new { Status = Successed.Repeat }, JsonRequestBehavior.AllowGet);
                    //添加 
                    model.CTime = DateTime.Now;
                    model.UTime = model.UTime;

                    _ChapterService.Insert(model);
                }
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
                var entity = _ChapterService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _ChapterService.Delete(entity);

                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
    
    }
}