using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class AdvertisementBusiness : IAdvertisementBusiness
    {
        private IRepository<Advertisement> _repoAdvertisement;

        public AdvertisementBusiness(
          IRepository<Advertisement> repoAdvertisement
          )
        {
            _repoAdvertisement = repoAdvertisement;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Advertisement GetById(int id)
        {
            return this._repoAdvertisement.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Advertisement Insert(Advertisement model)
        {
            return this._repoAdvertisement.Insert(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoAdvertisement.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Advertisement model)
        {
            this._repoAdvertisement.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Advertisement model)
        {
            this._repoAdvertisement.Delete(model);
        }
         

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<Advertisement> GetManagerList(string name,int typeId, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<Advertisement>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            if (typeId != 0)
            {
                where = where.And(m => m.TypeId==typeId);
            }

            totalCount = this._repoAdvertisement.Table.Where(where).Count();
            return this._repoAdvertisement.Table.Where(where).OrderBy(p => p.AdvertisementId).Skip((pageNum-1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Advertisement> GetAll()
        {
            return this._repoAdvertisement.Table.ToList();
        }
    }
}


