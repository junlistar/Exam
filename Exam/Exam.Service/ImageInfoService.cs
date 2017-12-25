using Exam.Business;
using Exam.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain.Model;

namespace Exam.Service
{
    public class ImageInfoService : IImageInfoService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IImageInfoBusiness _ImageInfoBiz;

        public ImageInfoService(IImageInfoBusiness ImageInfoBiz) {
            _ImageInfoBiz = ImageInfoBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ImageInfo GetById(int id)
        {
            return this._ImageInfoBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ImageInfo Insert(ImageInfo model)
        {
            return this._ImageInfoBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(ImageInfo model)
        {
            this._ImageInfoBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(ImageInfo model)
        {
            this._ImageInfoBiz.Delete(model);
        }
         
        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ImageInfo> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._ImageInfoBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<ImageInfo> GetAll()
        {
            return this._ImageInfoBiz.GetAll();
        }
    }
}
