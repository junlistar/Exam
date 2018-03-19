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
    public class VideoClassService : IVideoClassService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IVideoClassBusiness _VideoClassBiz;

        public VideoClassService(IVideoClassBusiness VideoClassBiz)
        {
            _VideoClassBiz = VideoClassBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VideoClass GetById(int id)
        {
            return this._VideoClassBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public VideoClass Insert(VideoClass model)
        {
            return this._VideoClassBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(VideoClass model)
        {
            this._VideoClassBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(VideoClass model)
        {
            this._VideoClassBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._VideoClassBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<VideoClass> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._VideoClassBiz.GetManagerList(name,pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<VideoClass> GetAll()
        {
            return this._VideoClassBiz.GetAll();
        }
    }
}
