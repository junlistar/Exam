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
    public class UserExamAnswerService : IUserExamAnswerService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IUserExamAnswerBusiness _UserExamAnswerBiz;

        public UserExamAnswerService(IUserExamAnswerBusiness UserExamAnswerBiz) {
            _UserExamAnswerBiz = UserExamAnswerBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserExamAnswer GetById(int id)
        {
            return this._UserExamAnswerBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserExamAnswer Insert(UserExamAnswer model)
        {
            return this._UserExamAnswerBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(UserExamAnswer model)
        {
            this._UserExamAnswerBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(UserExamAnswer model)
        {
            this._UserExamAnswerBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._UserExamAnswerBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<UserExamAnswer> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._UserExamAnswerBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<UserExamAnswer> GetAll()
        {
            return this._UserExamAnswerBiz.GetAll();
        }
    }
}
