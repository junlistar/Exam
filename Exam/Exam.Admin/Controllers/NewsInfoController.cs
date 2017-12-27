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
    /// 用户分组
    /// </summary>
    public class NewsInfoController : BaseController
    {
        // GET: NewsInfo
        private readonly INewsInfoService _newsInfoService;
        private readonly INewsCategoryService _newsCategoryService;
        private readonly IImageInfoService _imageInfoService;
        public NewsInfoController(INewsInfoService NewsInfoService, IImageInfoService imageInfoService, INewsCategoryService newsCategoryService)
        {
            _newsInfoService = NewsInfoService;
            _newsCategoryService = newsCategoryService;
            _imageInfoService = imageInfoService;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_NewsInfoVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(NewsInfoVM _NewsInfoVM, int pn = 1)
        {
            int totalCount,
                pageIndex = (pn - 1) * PagingConfig.PAGE_SIZE,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _newsInfoService.GetManagerList(_NewsInfoVM.QueryName, pageIndex, pageSize, out totalCount);
            var paging = new Paging<NewsInfo>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _NewsInfoVM.Paging = paging;
            return View(_NewsInfoVM);
        }
      
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="_NewsInfoVM"></param>
        /// <returns></returns>
        public ActionResult Edit(NewsInfoVM _NewsInfoVM)
        {
            _NewsInfoVM.NewsInfo = _newsInfoService.GetById(_NewsInfoVM.Id) ?? new NewsInfo();
            _NewsInfoVM.ImgInfo = _imageInfoService.GetById(_NewsInfoVM.NewsInfo.ImageId) ?? new ImageInfo();
            _NewsInfoVM.NewsCategories = _newsCategoryService.GetAll();
            return View(_NewsInfoVM);
        }
        /// <summary>
        /// 添加、修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Edit(NewsInfo model)
        {
            try
            {
                var entity = new NewsInfo();
                if (model.NewsInfoId > 0)
                {
                    entity = _newsInfoService.GetById(model.NewsInfoId);
                    //修改  
                    entity.UTime = DateTime.Now;
                    entity.ImageId = model.ImageId;
                    entity.NewsCategoryId = model.NewsCategoryId;
                    entity.Title = model.Title;
                    entity.Author = model.Author;
                    entity.Content = model.Content;
                    entity.Sort = model.Sort; 
                    entity.isHot = model.isHot; 
                    entity.isTop = model.isTop;
                    _newsInfoService.Update(entity);
                }
                else
                {
                    if (_newsInfoService.IsExistName(model.Title))
                        return Json(new { Status = Successed.Repeat }, JsonRequestBehavior.AllowGet);
                    //添加 
                    entity.Title = model.Title;
                    entity.ImageId = model.ImageId;
                    entity.NewsCategoryId = model.NewsCategoryId;
                    entity.Title = model.Title;
                    entity.Author = model.Author;
                    entity.Content = model.Content;
                    entity.Sort = model.Sort;
                    entity.isHot = model.isHot;
                    entity.isTop = model.isTop;
                    entity.CTime = DateTime.Now;
                    entity.UTime = DateTime.Now;

                    _newsInfoService.Insert(entity);
                }
                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
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
                var entity = _newsInfoService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _newsInfoService.Delete(entity);

                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        } 
    }
}