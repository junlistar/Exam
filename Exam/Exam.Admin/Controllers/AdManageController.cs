using Exam.Admin.Common;
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
    /// Advertisement
    /// </summary>
    public class AdManageController : BaseController
    {
        // GET: Advertisement
        private readonly IAdvertisementService _AdvertisementService;
        private readonly IImageInfoService _imageInfoService;

        public AdManageController(IAdvertisementService AdvertisementService,
             IImageInfoService imageInfoService)
        {
            _AdvertisementService = AdvertisementService;
            _imageInfoService = imageInfoService;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_AdvertisementVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(AdvertisementVM _AdvertisementVM, int pn = 1)
        {
            int totalCount,
                pageIndex = pn,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _AdvertisementService.GetManagerList(_AdvertisementVM.QueryName, _AdvertisementVM.Type, pageIndex, pageSize, out totalCount);
            var paging = new Paging<Advertisement>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _AdvertisementVM.Paging = paging;
            return View(_AdvertisementVM);
        }
        
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="_AdvertisementVM"></param>
        /// <returns></returns>
        public ActionResult Edit(AdvertisementVM _AdvertisementVM)
        {
            _AdvertisementVM.Advertisement = _AdvertisementService.GetById(_AdvertisementVM.Id) ?? new Advertisement();

            _AdvertisementVM.ImgInfo = _imageInfoService.GetById(_AdvertisementVM.Advertisement.ImageInfoId) ?? new ImageInfo();
            return View(_AdvertisementVM);
        }
        /// <summary>
        /// 添加、修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Edit(Advertisement model)
        {
            try
            {
                if (model.AdvertisementId > 0)
                {
                    var entity = _AdvertisementService.GetById(model.AdvertisementId);
                    //修改 
                    entity.AdvertisementId = model.AdvertisementId;
                    entity.Title = model.Title;
                    entity.TypeId = model.TypeId;
                    entity.UTime = DateTime.Now; 
                    entity.ImageInfoId= model.ImageInfoId; 
                    entity.UserInfoId = model.ImageInfoId; 
                    _AdvertisementService.Update(entity);
                }
                else
                {
                    if (_AdvertisementService.IsExistName(model.Title))
                        return Json(new { Status = Successed.Repeat }, JsonRequestBehavior.AllowGet);
                    //添加 
                    model.UserInfoId = Loginer.AccountId;
                    model.CTime = DateTime.Now;
                    model.UTime = DateTime.Now;

                    _AdvertisementService.Insert(model);
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
                var entity = _AdvertisementService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _AdvertisementService.Delete(entity);

                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
    
    }
}