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
    /// Lecturer菜单
    /// </summary>
    public class LecturerController : BaseController
    {
        // GET: Lecturer
        private readonly ILecturerService _LecturerService;
        private readonly IImageInfoService _imageInfoService;
        public LecturerController(ILecturerService LecturerService, IImageInfoService imageInfoService)
        {
            _LecturerService = LecturerService;
            _imageInfoService = imageInfoService;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_LecturerVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(LecturerVM _LecturerVM, int pn = 1)
        {
            int totalCount,
                pageIndex = pn,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _LecturerService.GetManagerList(_LecturerVM.QueryName, pageIndex, pageSize, out totalCount);
            var paging = new Paging<Lecturer>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _LecturerVM.Paging = paging;
            return View(_LecturerVM);
        }
        
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="_LecturerVM"></param>
        /// <returns></returns>
        public ActionResult Edit(LecturerVM _LecturerVM)
        {
            _LecturerVM.Lecturer = _LecturerService.GetById(_LecturerVM.Id) ?? new Lecturer();
            _LecturerVM.ImgInfo = _imageInfoService.GetById(_LecturerVM.Lecturer.ImageInfoId) ?? new ImageInfo();
            return View(_LecturerVM);
        }
        /// <summary>
        /// 添加、修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Edit(Lecturer model)
        {
            try
            {
                if (model.LecturerId > 0)
                {
                    var entity = _LecturerService.GetById(model.LecturerId);
                    //修改 
                    entity.Abstracts = model.Abstracts;
                    entity.ImageInfoId = model.ImageInfoId;
                    entity.Name = model.Name;
                    entity.Introduce = model.Introduce;
                    entity.Position = model.Position;
                    entity.Sort= model.Sort;
                    model.UTime = DateTime.Now;
                    _LecturerService.Update(entity);
                }
                else
                {
                    if (_LecturerService.IsExistName(model.Name))
                        return Json(new { Status = Successed.Repeat }, JsonRequestBehavior.AllowGet);
                    //添加 
                    model.CTime = DateTime.Now; 
                    model.UTime = DateTime.Now;

                    _LecturerService.Insert(model);
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
                var entity = _LecturerService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _LecturerService.Delete(entity);

                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
    
    }
}