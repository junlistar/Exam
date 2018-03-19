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
    public class VideoClassController : Controller
    {
        //方式1
        private readonly IVideoClassService _videoClassService;   
        private readonly IImageInfoService _imageInfoService;

        //方式2 

        public VideoClassController(IVideoClassService videoClassService,
            IImageInfoService imageInfoService)
        {
            _videoClassService = videoClassService;
            _imageInfoService = imageInfoService; 
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_VideoClassVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(VideoClassVM _VideoClassVM, int pn = 1)
        {
            int totalCount,
                pageIndex = pn,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _videoClassService.GetManagerList(_VideoClassVM.QueryName, pageIndex, pageSize, out totalCount);
            var paging = new Paging<VideoClass>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _VideoClassVM.Paging = paging;
            return View(_VideoClassVM);
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
                var entity = _videoClassService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                } 
                _videoClassService.Update(entity);
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
                var entity = _videoClassService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _videoClassService.Delete(entity);

                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="VideoClassVM"></param>
        /// <returns></returns>
        public ActionResult Edit(VideoClassVM vm)
        {
            vm.VideoClass = _videoClassService.GetById(vm.Id) ?? new VideoClass(); 
            return View(vm);
        }
        /// <summary>
        /// 添加、修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Edit(VideoClass model)
        {
            try
            {
                var entity = new VideoClass();
                if (model.VideoClassId > 0)
                {
                    entity = _videoClassService.GetById(model.VideoClassId);
                    //修改  
                    entity.UTime = DateTime.Now;
                    entity.Title = model.Title;
                    entity.Sort = model.Sort; 
                    _videoClassService.Update(entity);
                }
                else
                {
                    if (_videoClassService.IsExistName(model.Title))
                        return Json(new { Status = Successed.Repeat }, JsonRequestBehavior.AllowGet);
                    //添加 
                    entity.Title = model.Title;
                    entity.Sort = model.Sort;
                    entity.CTime = DateTime.Now;
                    entity.UTime = DateTime.Now;

                    _videoClassService.Insert(entity);
                }
                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}