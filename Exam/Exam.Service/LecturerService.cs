﻿using Exam.Business;
using Exam.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain.Model;

namespace Exam.Service
{
    public class LecturerService : ILecturerService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private ILecturerBusiness _LecturerBiz;

        public LecturerService(ILecturerBusiness LecturerBiz) {
            _LecturerBiz = LecturerBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Lecturer GetById(int id)
        {
            return this._LecturerBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Lecturer Insert(Lecturer model)
        {
            return this._LecturerBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Lecturer model)
        {
            this._LecturerBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Lecturer model)
        {
            this._LecturerBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._LecturerBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<Lecturer> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._LecturerBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Lecturer> GetAll()
        {
            return this._LecturerBiz.GetAll();
        }
    }
}
