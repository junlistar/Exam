using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class ProblemLibraryBusiness : IProblemLibraryBusiness
    {
        private IRepository<ProblemLibrary> _repoProblemLibrary;

        public ProblemLibraryBusiness(
          IRepository<ProblemLibrary> repoProblemLibrary
          )
        {
            _repoProblemLibrary = repoProblemLibrary;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProblemLibrary GetById(int id)
        {
            return this._repoProblemLibrary.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ProblemLibrary Insert(ProblemLibrary model)
        {
            return this._repoProblemLibrary.Insert(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoProblemLibrary.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(ProblemLibrary model)
        {
            this._repoProblemLibrary.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(ProblemLibrary model)
        {
            this._repoProblemLibrary.Delete(model);
        }
         

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<ProblemLibrary> GetManagerList(string name,int isUse, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<ProblemLibrary>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            if (isUse != 0)
            {
                where = where.And(m => m.IsUse == isUse);
            }

            totalCount = this._repoProblemLibrary.Table.Where(where).Count();
            return this._repoProblemLibrary.Table.Where(where).OrderBy(p => p.ProblemLibraryId).Skip((pageNum-1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<ProblemLibrary> GetAll()
        {
            return this._repoProblemLibrary.Table.ToList();
        }

        /// <summary>
        /// 获取所有(分页)
        /// </summary> 
        /// <returns></returns>
        public List<ProblemLibrary> GetAllByPage(int belongId,int pageNum, int pageSize)
        {
            var where = PredicateBuilder.True<ProblemLibrary>();

            // name过滤
            if (belongId!=0)
            {
                where = where.And(m => m.BelongId == belongId);
            }
            return this._repoProblemLibrary.Table.Where(where).OrderBy(p => p.ProblemLibraryId).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}


