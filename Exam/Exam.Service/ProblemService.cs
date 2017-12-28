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
    public class ProblemService : IProblemService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IProblemBusiness _ProblemBiz;

        public ProblemService(IProblemBusiness ProblemBiz) {
            _ProblemBiz = ProblemBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Problem GetById(int id)
        {
            return this._ProblemBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Problem Insert(Problem model)
        {
            return this._ProblemBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Problem model)
        {
            this._ProblemBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Problem model)
        {
            this._ProblemBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._ProblemBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<Problem> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._ProblemBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Problem> GetAll()
        {
            return this._ProblemBiz.GetAll();
        }
    }
}