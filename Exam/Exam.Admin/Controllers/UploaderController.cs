using Exam.Core.Utils;
using Exam.Domain.Model;
using Exam.IService;
using System;
using System.IO;
using System.Web.Mvc;
using System.Linq;

namespace Exam.Admin.Controllers
{
    /// <summary>
    /// 图片上传控制器
    /// </summary>
    public class UploaderController : Controller
    {
        // GET: Uploader
        private readonly IImageInfoService _baseImgInfoService;
        public UploaderController(IImageInfoService baseImgInfoService)
        {
            _baseImgInfoService = baseImgInfoService;
        }

        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="folder">文件夹名称</param>
        /// <param name="title">图片标题</param>
        /// <returns></returns>
        private static readonly object imgLock = new object();
        [HttpPost]
        public JsonResult ImgFile(string folder = "ImgUploader", string title = "title")
        {
            lock (imgLock)
            {
                var fileBase = Request.Files[0];
                string path = string.Format("/Uploaders/{0}", folder);
                string newFileName = fileBase.FileName.Substring(fileBase.FileName.LastIndexOf(".") + 1);
                string fileName = Path.GetFileName(DateTime.Now.ToString("yyyyMMddhhmmssffff") + "." + newFileName);
                string fileServerPath = Server.MapPath(path);
                if (!Directory.Exists(fileServerPath))
                    Directory.CreateDirectory(fileServerPath);
                var filePath = Path.Combine(fileServerPath, fileName);
                //保存图片
                fileBase.SaveAs(filePath);
               
                var model = new ImageInfo()
                {
                    Url = string.Format("{0}/{1}", path, fileName),
                    Title = title, 
                    Source = WebConfigHelper.GetAppSettingsInfo("ImgPath"),
                    CTime = DateTime.Now,
                };
                var entity = _baseImgInfoService.Insert(model);
                return Json(entity.ImageInfoId, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 图片上传压缩
        /// </summary>
        /// <param name="folder">文件夹名称</param>
        /// <param name="title">图片标题</param>
        /// <returns></returns>
        private static readonly object compress = new object();
        [HttpPost]
        public JsonResult Compress(string folder = "CompressUploader", string title = "title")
        {
            lock (compress)
            {
                var fileBase = Request.Files[0];
                //源图路径
                string filePath = Server.MapPath(string.Format("/Uploaders/{0}", folder));
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                string newFileName = fileBase.FileName.Substring(fileBase.FileName.LastIndexOf(".") + 1);
                var path = Path.Combine(filePath, Path.GetFileName(DateTime.Now.ToString("yyyyMMddhhmmssffff") + "." + newFileName));
                //保存图片
                fileBase.SaveAs(path);
                string extendName = Path.GetExtension(path);
                //缩略图路径
                string thumbnailPath = string.Format("/Uploaders/{0}/{1}{2}{3}", folder, DateTime.Now.ToString("yyyyMMddhhmmssffff"), "_th", extendName);
                string serverPath = Server.MapPath(thumbnailPath);
                ImageHelper.MakeThumbnail(path, serverPath, 64, 64, "Cut");
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                var model = new ImageInfo()
                {
                    Url = thumbnailPath,
                    Title = title,
                    Source = WebConfigHelper.GetAppSettingsInfo("ImgPath"),
                    CTime = DateTime.Now
                };
                var entity = _baseImgInfoService.Insert(model);
                return Json(entity.ImageInfoId, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 文件删除
        /// </summary>
        /// <param name="path">路径地址</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteFile(int id = 0)
        {
            var info = _baseImgInfoService.GetById(id);
            if (info == null) return Json(0, JsonRequestBehavior.AllowGet);
            string serverPath = Server.MapPath(Path.Combine(info.Url));
            if (System.IO.File.Exists(serverPath))
                System.IO.File.Delete(serverPath);
            _baseImgInfoService.Delete(info);
            return Json(0, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除多张图片
        /// </summary>
        /// <param name="fileImgs">图片id数组</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteFileImgs(string fileImgs = "")
        {
            var imgs = fileImgs.Split(',');
            for (int i = 0; i < imgs.Length; i++)
            {
                var id = Convert.ToInt32(imgs[i]);
                var info = _baseImgInfoService.GetById(id);
                string serverPath = Server.MapPath(Path.Combine(info.Url));
                if (System.IO.File.Exists(serverPath))
                    System.IO.File.Delete(serverPath);
                _baseImgInfoService.Delete(info);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取图片列表
        /// </summary>
        /// <param name="ids">图片id字符串</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetImgInfos(string ids = "")
        {
            if (string.IsNullOrWhiteSpace(ids)) return Json("", JsonRequestBehavior.AllowGet);
            var list = _baseImgInfoService.GetAll().Where(p=> ids.Contains(p.ImageInfoId.ToString()));
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
