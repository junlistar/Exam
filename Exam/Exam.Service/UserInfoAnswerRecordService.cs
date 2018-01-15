﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain.Model;
using Exam.IService;

namespace Exam.Service
{
   public class UserInfoAnswerRecordService: IUserInfoAnswerRecordService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IUserInfoAnswerRecordService _userInfoAnswerRecordService;

        public UserInfoAnswerRecordService(IUserInfoAnswerRecordService userInfoAnswerRecordService)
        {
            _userInfoAnswerRecordService = userInfoAnswerRecordService;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfoAnswerRecord GetById(int id)
        {
            return this._userInfoAnswerRecordService.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserInfoAnswerRecord Insert(UserInfoAnswerRecord model)
        {
            return this._userInfoAnswerRecordService.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(UserInfoAnswerRecord model)
        {
            this._userInfoAnswerRecordService.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(UserInfoAnswerRecord model)
        {
            this._userInfoAnswerRecordService.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsExistName(string name, int type)
        {
            return this._userInfoAnswerRecordService.IsExistName(name, type);
        }
        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<UserInfoAnswerRecord> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._userInfoAnswerRecordService.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<UserInfoAnswerRecord> GetAll()
        {
            return this._userInfoAnswerRecordService.GetAll();
        }
    }
}
