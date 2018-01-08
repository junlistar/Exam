using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.Api.Models
{
    /// <summary>
    /// 上传用户图像
    /// </summary>
    public class UploadImageVM
    {
        /// <summary>
        /// 64位编码
        /// </summary>
        [Required(ErrorMessage = "base64是必须的")]
        public string Base64 { get; set; }


        /// <summary>
        /// 后缀类型
        /// </summary>
        [Required(ErrorMessage = "SuffixType是必须的")]
        public string SuffixType { get; set; }


        /// <summary>
        /// 用户id
        /// </summary>
        public int UserInfoId { get; set; }
    }
}