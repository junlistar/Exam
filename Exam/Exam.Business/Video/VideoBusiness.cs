using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class VideoBusiness : IVideoBusiness
    {
        private IRepository<Video> _repoVideo;

        public VideoBusiness(
          IRepository<Video> repoVideo
          )
        {
            _repoVideo = repoVideo;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Video GetById(int id)
        {
            return this._repoVideo.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Video Insert(Video model)
        {
            return this._repoVideo.Insert(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoVideo.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Video model)
        {
            this._repoVideo.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Video model)
        {
            this._repoVideo.Delete(model);
        }
         

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<Video> GetManagerList(string name,int videoClassId, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<Video>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            if (videoClassId != 0)
            {
                where = where.And(m => m.VideoClassId== videoClassId);
            }

            totalCount = this._repoVideo.Table.Where(where).Count();
            return this._repoVideo.Table.Where(where).OrderBy(p => p.VideoId).Skip((pageNum-1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Video> GetAll()
        {
            return this._repoVideo.Table.ToList();
        }


        /// <summary>
        /// 根据分类id和top获取视频列表
        /// </summary> 
        /// <returns></returns>
        public List<Video> GetVideoList(string name, int videoClassId,int isTop, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<Video>();

            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            if (videoClassId != 0)
            {
                where = where.And(m => m.VideoClassId == videoClassId);
            }

            if (isTop != 0)
            {
                where = where.And(m => m.IsTop == isTop);
            }

            totalCount = this._repoVideo.Table.Where(where).Count();
            return this._repoVideo.Table.Where(where).OrderBy(p => p.VideoId).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}


