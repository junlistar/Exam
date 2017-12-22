﻿using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class UserInfoBusiness:IUserInfoBusiness
    {
        private IRepository<UserInfo> _repoUserInfo;

        public UserInfoBusiness(
          IRepository<UserInfo> repoUserInfo
          )
        {
            _repoUserInfo = repoUserInfo;
        }
        /// <summary>
        /// 根据ID查找用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfo GetById(int id)
        {
            return this._repoUserInfo.GetById(id);
        }

        public UserInfo Insert(UserInfo model)
        {
            return this._repoUserInfo.Insert(model);
        }
        /// <summary>
        /// 管理后台用户列表
        /// </summary> 
        /// <returns></returns>
        public List<UserInfo> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<UserInfo>();
              
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.NikeName.Contains(name));
            }

            totalCount = this._repoUserInfo.Table.Where(where).Count();
            return this._repoUserInfo.Table.Where(where).OrderBy(p => p.UserInfoId).Skip(pageNum * pageSize).Take(pageSize).ToList();
        }
    }
}


