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
    public class VideoController : Controller
    {
        //方式1
        private readonly IVideoService _videoService;  
        private readonly IImageInfoService _imageService;
        private readonly IBelongService _belongService;
        private readonly IVideoClassService _videoClassService;

        //方式2 

        public VideoController(IVideoService videoService, IReplyService replyService, 
            IImageInfoService imageInfoService, IBelongService belongService, IVideoClassService videoClassService)
        {
            _videoService = videoService;
            _imageService = imageInfoService;
            _belongService = belongService;
            _videoClassService = videoClassService;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_VideoVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(VideoVM _VideoVM, int pn = 1)
        {
            int totalCount,
                pageIndex = pn,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _videoService.GetManagerList(_VideoVM.QueryName, _VideoVM.QueryClassId, pageIndex, pageSize, out totalCount);
            var paging = new Paging<Video>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _VideoVM.Paging = paging;
            return View(_VideoVM);
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
                var entity = _videoService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }
                _videoService.Update(entity);
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
                var entity = _videoService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _videoService.Delete(entity);

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
        /// <param name="_VideoVM"></param>
        /// <returns></returns>
        public ActionResult Edit(VideoVM vm)
        {
            vm.Video = _videoService.GetById(vm.Id) ?? new Video();
            vm.ImgInfo = _imageService.GetById(vm.Video.ImageInfoId) ?? new ImageInfo();
            vm.Belongs = _belongService.GetAll();
            vm.VideoClasses = _videoClassService.GetAll();
            return View(vm);
        }
        /// <summary>
        /// 添加、修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Edit(Video model)
        {
            try
            {
                var entity = new Video();
                if (model.VideoId > 0)
                {
                    entity = _videoService.GetById(model.VideoId);
                    //修改  
                    entity.UTime = DateTime.Now;
                    entity.ImageInfoId = model.ImageInfoId;
                    entity.VideoClassId = model.VideoClassId;
                    entity.Title = model.Title;
                    entity.BelongId = model.BelongId;
                    entity.Url = model.Url;
                    entity.Sort = model.Sort;
                    entity.IsTop = model.IsTop;
                    _videoService.Update(entity);
                }
                else
                {
                    if (_videoService.IsExistName(model.Title))
                        return Json(new { Status = Successed.Repeat }, JsonRequestBehavior.AllowGet);
                    //添加 
                    entity.Title = model.Title;
                    entity.ImageInfoId = model.ImageInfoId;
                    entity.VideoClassId = model.VideoClassId;
                    entity.Title = model.Title;
                    entity.BelongId = model.BelongId;
                    entity.Url = model.Url;
                    entity.Sort = model.Sort;
                    entity.IsTop = model.IsTop;
                    entity.CTime = DateTime.Now;
                    entity.UTime = DateTime.Now;

                    _videoService.Insert(entity);
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