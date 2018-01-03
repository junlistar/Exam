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
    public class UserInfoController : Controller
    {
        //方式1
        IUserInfoService _userService; 
        IGradeService _gradeService; 
        ISysGroupService _sysGroupService;
        IImageInfoService _imageInfoService;

        //方式2
        private readonly IUserInfoService _userInfo = EngineContext.Current.Resolve<IUserInfoService>(); 

        public UserInfoController(IUserInfoService userService, IGradeService gradeService, 
            ISysGroupService sysGroupService,
            IImageInfoService imageInfoService)
        {
            _userService = userService;
            _gradeService = gradeService;
            _sysGroupService = sysGroupService;
            _imageInfoService = imageInfoService;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="_userInfoVM"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult List(UserInfoVM _userInfoVM, int pn = 1)
        {
            int totalCount,
                pageIndex = (pn - 1) * PagingConfig.PAGE_SIZE,
                pageSize = PagingConfig.PAGE_SIZE;
            var list = _userService.GetManagerList(_userInfoVM.QueryLoginName, pageIndex, pageSize, out totalCount);
            var paging = new Paging<UserInfo>()
            {
                Items = list,
                Size = PagingConfig.PAGE_SIZE,
                Total = totalCount,
                Index = pn,
            };
            _userInfoVM.Paging = paging;
            return View(_userInfoVM);
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
                var entity = _userService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }
                entity.IsEnable = (int)isEnabled;
                _userService.Update(entity);
                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }

        /// 编辑
        /// </summary>
        /// <param name="_UserInfoVM"></param>
        /// <returns></returns>
        public ActionResult Edit(UserInfoVM _UserInfoVM)
        {
            _UserInfoVM.UserInfo = _userInfo.GetById(_UserInfoVM.Id) ?? new UserInfo();
            _UserInfoVM.ImgInfo = _imageInfoService.GetById(_UserInfoVM.UserInfo.ImageInfoId) ?? new ImageInfo();
            _UserInfoVM.SysGroupList = _sysGroupService.GetAll().ToList();
            _UserInfoVM.GradeList = _gradeService.GetAll().ToList();
            return View(_UserInfoVM);
        }
        /// <summary>
        /// 添加、修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Edit(UserInfo model)
        {
            try
            {
                if (model.UserInfoId > 0)
                {
                    var entity = _userInfo.GetById(model.UserInfoId);
                    //修改 
                    entity.Gender = model.Gender;
                    entity.UTime = DateTime.Now;
                    entity.GradeId = model.GradeId;
                    entity.ImageInfoId = model.ImageInfoId;
                    entity.NikeName = model.NikeName;
                    entity.Phone = model.Phone;
                    _userInfo.Update(entity);
                }
                else
                {
                    if (_userInfo.IsExistName(model.NikeName))
                        return Json(new { Status = Successed.Repeat }, JsonRequestBehavior.AllowGet);
                    //添加
                    model.IsEnable = (int)EnumHelp.EnabledEnum.有效;
                    model.CTime = DateTime.Now;
                    model.UTime = DateTime.Now;

                    _userInfo.Insert(model);
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
                var entity = _userInfo.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _userInfo.Delete(entity);

                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
        
    }
}