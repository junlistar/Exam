﻿using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public interface IVersionTableBusiness
    {
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        VersionTable GetById(int id);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        VersionTable Insert(VersionTable model);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Update(VersionTable model);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Delete(VersionTable model);

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        bool IsExistName(string name);

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<VersionTable> GetManagerList(string name, int typeId, int pageNum, int pageSize, out int totalCount);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<VersionTable> GetAll();
    }
}
