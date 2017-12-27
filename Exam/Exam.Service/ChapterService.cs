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
    public class ChapterService : IChapterService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IChapterBusiness _ChapterBiz;

        public ChapterService(IChapterBusiness ChapterBiz) {
            _ChapterBiz = ChapterBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Chapter GetById(int id)
        {
            return this._ChapterBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Chapter Insert(Chapter model)
        {
            return this._ChapterBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Chapter model)
        {
            this._ChapterBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Chapter model)
        {
            this._ChapterBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._ChapterBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<Chapter> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._ChapterBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Chapter> GetAll()
        {
            return this._ChapterBiz.GetAll();
        }
    }
}
