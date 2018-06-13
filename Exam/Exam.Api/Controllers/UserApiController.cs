using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Exam.Api.Common;
using Exam.Api.Models;
using Exam.Core.Infrastructure;
using Exam.Domain.Model;
using Exam.IService;

namespace Exam.Api.Controllers
{
    public class UserApiController : ApiController
    {

        //方式2
        private readonly IUserInfoService _userInfo = EngineContext.Current.Resolve<IUserInfoService>();
        private readonly IImageInfoService _imageInfo = EngineContext.Current.Resolve<IImageInfoService>();
        //方式1
        //IUserInfoService _userService;

        //public UserApiController() { }
        //public UserApiController(IUserInfoService userService)
        //{
        //    _userService = userService;
        //}
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Register(string phone = "", string code = "")
        {
            
            string pcode = CacheHelper.GetCache(phone + "Code").ToString();
            if (!string.IsNullOrWhiteSpace(phone))
            {
                if (!string.IsNullOrWhiteSpace(code) && code == pcode)
                {
                    if (_userInfo.IsExistPhone(phone))
                    {
                        return Json(new { Success = false, Msg = "电话号码已经存在", Data = "" });
                    }
                    else
                    {
                        UserInfo userInfo = _userInfo.Insert(new UserInfo
                        {
                            CTime = DateTime.Now,
                            Gender = 0,
                            ImageInfoId = 1000,
                            IsEnable = 0,
                            Phone = phone,
                            UTime = DateTime.Now
                        });
                        throw new Exception("注册成功，请等待审核！");
                    }
                }
                else
                {
                    return Json(new { Success = false, Msg = "验证码不正确", Data = "" });
                }
            }
            else
            {
                return Json(new { Success = false, Msg = "手机号码不正确", Data = "" });
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Login(LoginVM loginVM)
        {
            var lcode = CacheHelper.GetCache(loginVM.Phone + "Login");
            if (lcode != null && !string.IsNullOrWhiteSpace(loginVM.Code) && loginVM.Code == lcode.ToString())
            {
                var userInfo = _userInfo.Login(loginVM.Phone);

                if (userInfo == null)
                {
                    UserInfo userInfoRegister = _userInfo.Insert(new UserInfo
                    {
                        CTime = DateTime.Now,
                        Gender = 0,
                        ImageInfoId = 1000,
                        IsEnable = 0,
                        Phone = loginVM.Phone,
                        UTime = DateTime.Now,
                        NikeName = loginVM.Phone,
                        GradeId=1001,
                        Password= "e10adc3949ba59abbe56e057f20f883e",
                        SysGroupId=1002

                    });
                    CacheHelper.RemoveAllCache(loginVM.Phone + "Login");
                    throw new Exception("您还没有通过审核！");
                }
                return Json(new { Success = true, Msg = "OK", Data = userInfo });
            }
            else
            {
                return Json(new { Success = false, Msg = "验证码不正确", Data = "" });
            }
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult UpdateUserInfo(UpdateUserInfoVM updateUserInfoVM)
        {
            var userInfo = _userInfo.GetById(updateUserInfoVM.UserInfoId);

            if (userInfo != null)
            {
                userInfo.NikeName = updateUserInfoVM.NikeName;
                //userInfo.GradeId = updateUserInfoVM.GradeId;
                userInfo.Gender = updateUserInfoVM.Gender;
                userInfo.UTime = DateTime.Now;
                _userInfo.Update(userInfo);
                return Json(new { Success = true, Msg = "用户信息修改成功", Data = userInfo });
            }
            else
            {
                return Json(new { Success = false, Msg = "用户不存在", Data = "" });
            }
        }

        /// <summary>
        /// 修改用户图像
        /// </summary>
        /// <param name="uploadImageVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult UpdateUserHead(UploadImageVM uploadImageVM)
        {
            string path = string.Format("/UploadImge/" + DateTime.Now.ToString("yyyyMMdd") + "/");
            byte[] imgByte = Convert.FromBase64String(uploadImageVM.Base64);
            MemoryStream ms = new MemoryStream(imgByte);
            Image image = System.Drawing.Image.FromStream(ms);
            string fileName = string.Format("{0}." + uploadImageVM.SuffixType, DateTime.Now.ToString("yyyyMMddhhmmssffff") + RandomHelper.GenerateCheckCodeNum(6));
            string filePath = string.Format("{0}{1}", path, fileName);
            string serverPath = HttpContext.Current.Server.MapPath("~" + path);
            if (!Directory.Exists(serverPath))
            {
                Directory.CreateDirectory(serverPath);
            }
            //保存图片
            image.Save(serverPath + fileName);
            var url = ConfigurationManager.AppSettings["ImgUrl"];

            var imageInfo = _imageInfo.Insert(new ImageInfo
            {
                CTime = DateTime.Now,
                Title = "头像",
                Url = filePath,
                Source= url
            });

            var userInfo = _userInfo.GetById(uploadImageVM.UserInfoId);
            userInfo.ImageInfoId = imageInfo.ImageInfoId;
            userInfo.UTime = DateTime.Now;
            _userInfo.Update(userInfo);

            return Json(new { Success = true, Msg = "用户图像修改成功", Data = userInfo });
        }
        /// <summary>
        /// 根据UserInfoId得到用户信息
        /// </summary>
        /// <param name="UserInfoId"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetUserInfo(int UserInfoId=0)
        {
            return Json(new { Success = true, Msg = "OK", Data = _userInfo.GetById(UserInfoId) });
        }
    }
}
