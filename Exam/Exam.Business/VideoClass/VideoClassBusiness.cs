using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class VideoClassBusiness : IVideoClassBusiness
    {
        private IRepository<VideoClass> _repoVideoClass;

        public VideoClassBusiness(
          IRepository<VideoClass> repoVideoClass
          )
        {
            _repoVideoClass = repoVideoClass;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VideoClass GetById(int id)
        {
            return this._repoVideoClass.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public VideoClass Insert(VideoClass model)
        {
            return this._repoVideoClass.Insert(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoVideoClass.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(VideoClass model)
        {
            this._repoVideoClass.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(VideoClass model)
        {
            this._repoVideoClass.Delete(model);
        }
         

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<VideoClass> GetManagerList(string name,int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<VideoClass>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            totalCount = this._repoVideoClass.Table.Where(where).Count();
            return this._repoVideoClass.Table.Where(where).OrderBy(p => p.VideoClassId).Skip((pageNum-1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<VideoClass> GetAll()
        {
            return this._repoVideoClass.Table.ToList();
        }
    }
}


