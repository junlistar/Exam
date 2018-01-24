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
    public class AdvertisementService : IAdvertisementService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IAdvertisementBusiness _AdvertisementBiz;

        public AdvertisementService(IAdvertisementBusiness AdvertisementBiz)
        {
            _AdvertisementBiz = AdvertisementBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Advertisement GetById(int id)
        {
            return this._AdvertisementBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Advertisement Insert(Advertisement model)
        {
            return this._AdvertisementBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Advertisement model)
        {
            this._AdvertisementBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Advertisement model)
        {
            this._AdvertisementBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._AdvertisementBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<Advertisement> GetManagerList(string name, int typeId, int pageNum, int pageSize, out int totalCount)
        {
            return this._AdvertisementBiz.GetManagerList(name,typeId,pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Advertisement> GetAll()
        {
            return this._AdvertisementBiz.GetAll();
        }
    }
}
