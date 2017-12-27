using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class LecturerBusiness : ILecturerBusiness
    {
        private IRepository<Lecturer> _repoLecturer;

        public LecturerBusiness(
          IRepository<Lecturer> repoLecturer
          )
        {
            _repoLecturer = repoLecturer;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Lecturer GetById(int id)
        {
            return this._repoLecturer.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Lecturer Insert(Lecturer model)
        {
            return this._repoLecturer.Insert(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoLecturer.Table.Any(p => p.Name == name);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Lecturer model)
        {
            this._repoLecturer.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Lecturer model)
        {
            this._repoLecturer.Delete(model);
        }
         

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<Lecturer> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<Lecturer>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Name.Contains(name));
            }

            totalCount = this._repoLecturer.Table.Where(where).Count();
            return this._repoLecturer.Table.Where(where).OrderBy(p => p.LecturerId).Skip(pageNum * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Lecturer> GetAll()
        {
            return this._repoLecturer.Table.ToList();
        }
    }
}


