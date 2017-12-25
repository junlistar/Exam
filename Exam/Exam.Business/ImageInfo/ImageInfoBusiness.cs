using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class ImageInfoBusiness : IImageInfoBusiness
    {
        private IRepository<ImageInfo> _repoImageInfo;

        public ImageInfoBusiness(
          IRepository<ImageInfo> repoImageInfo
          )
        {
            _repoImageInfo = repoImageInfo;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ImageInfo GetById(int id)
        {
            return this._repoImageInfo.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ImageInfo Insert(ImageInfo model)
        {
            return this._repoImageInfo.Insert(model);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(ImageInfo model)
        {
            this._repoImageInfo.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(ImageInfo model)
        {
            this._repoImageInfo.Delete(model);
        }
         

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<ImageInfo> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<ImageInfo>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            totalCount = this._repoImageInfo.Table.Where(where).Count();
            return this._repoImageInfo.Table.Where(where).OrderBy(p => p.ImageInfoId).Skip(pageNum * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<ImageInfo> GetAll()
        {
            return this._repoImageInfo.Table.ToList();
        }
    }
}


