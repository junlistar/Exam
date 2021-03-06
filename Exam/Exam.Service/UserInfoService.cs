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
    public class UserInfoService : IUserInfoService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IUserInfoBusiness _userBiz;

        public UserInfoService(IUserInfoBusiness userBiz)
        {
            _userBiz = userBiz;
        }

        public UserInfo GetById(int Id)
        {
            return _userBiz.GetById(Id);
        }

        public UserInfo Insert(UserInfo model)
        {
            return _userBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(UserInfo model)
        {
            this._userBiz.Update(model);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(UserInfo model)
        {
            this._userBiz.Delete(model);
        }

        /// <summary>
        /// 管理后台用户列表
        /// </summary> 
        /// <returns></returns>
        public List<UserInfo> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return _userBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._userBiz.IsExistName(name);
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserInfo Login(string phone, string password)
        {
            return this._userBiz.Login(phone, password);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistPhone(string phone)
        {
            return this._userBiz.IsExistPhone(phone);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="phone">电话</param>
        /// <returns></returns>
        public UserInfo Login(string phone) {
            return this._userBiz.Login(phone);
        }
    }
}
