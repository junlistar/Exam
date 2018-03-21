using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Business;
using Exam.Domain.Model;
using Exam.IService;

namespace Exam.Service
{
    public class VideoService : IVideoService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IVideoBusiness _VideoBiz;

        public VideoService(IVideoBusiness VideoBiz)
        {
            _VideoBiz = VideoBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Video GetById(int id)
        {
            return this._VideoBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Video Insert(Video model)
        {
            return this._VideoBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Video model)
        {
            this._VideoBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Video model)
        {
            this._VideoBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._VideoBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<Video> GetManagerList(string name, int videoClassId, int pageNum, int pageSize, out int totalCount)
        {
            return this._VideoBiz.GetManagerList(name, videoClassId,pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Video> GetAll()
        {
            return this._VideoBiz.GetAll();
        }

        /// <summary>
        /// 根据分类id和top获取视频列表
        /// </summary> 
        /// <returns></returns>
        public List<Video> GetVideoList(string name, int videoClassId, int isTop, int pageNum, int pageSize, out int totalCount) {
            return this._VideoBiz.GetVideoList(name, videoClassId, isTop,pageNum, pageSize, out totalCount);
        }
    }
}
