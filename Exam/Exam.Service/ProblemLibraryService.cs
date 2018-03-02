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
    public class ProblemLibraryService : IProblemLibraryService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IProblemLibraryBusiness _ProblemLibraryBiz;

        public ProblemLibraryService(IProblemLibraryBusiness ProblemLibraryBiz)
        {
            _ProblemLibraryBiz = ProblemLibraryBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProblemLibrary GetById(int id)
        {
            return this._ProblemLibraryBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ProblemLibrary Insert(ProblemLibrary model)
        {
            return this._ProblemLibraryBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(ProblemLibrary model)
        {
            this._ProblemLibraryBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(ProblemLibrary model)
        {
            this._ProblemLibraryBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._ProblemLibraryBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ProblemLibrary> GetManagerList(string name, int typeId, int pageNum, int pageSize, out int totalCount)
        {
            return this._ProblemLibraryBiz.GetManagerList(name, typeId, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<ProblemLibrary> GetAll()
        {
            return this._ProblemLibraryBiz.GetAll();
        }


        /// <summary>
        /// 获取所有(分页)
        /// </summary> 
        /// <returns></returns>
        public List<ProblemLibrary> GetAllByPage(int belongId, int pageNum, int pageSize)
        {
            return this._ProblemLibraryBiz.GetAllByPage(belongId, pageNum, pageSize);
        }
    }
}
