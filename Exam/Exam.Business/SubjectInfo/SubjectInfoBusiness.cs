﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Core.Data;
using Exam.Domain.Model;

namespace Exam.Business
{
    public class SubjectInfoBusiness : ISubjectInfoBusiness
    {
        private IRepository<SubjectInfo> _repoSubjectInfo;

        public SubjectInfoBusiness(
          IRepository<SubjectInfo> repoSubjectInfo
          )
        {
            _repoSubjectInfo = repoSubjectInfo;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SubjectInfo GetById(int id)
        {
            return this._repoSubjectInfo.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SubjectInfo Insert(SubjectInfo model)
        {
            return this._repoSubjectInfo.Insert(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoSubjectInfo.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(SubjectInfo model)
        {
            this._repoSubjectInfo.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(SubjectInfo model)
        {
            this._repoSubjectInfo.Delete(model);
        }


        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<SubjectInfo> GetManagerList(string name, int typeId, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<SubjectInfo>();

            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            totalCount = this._repoSubjectInfo.Table.Where(where).Count();
            return this._repoSubjectInfo.Table.Where(where).OrderBy(p => p.SubjectInfoId).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<SubjectInfo> GetAll()
        {
            return this._repoSubjectInfo.Table.ToList();
        }


        /// <summary>
        /// 根据分类id获取科目列表
        /// </summary>
        /// <returns></returns>
        public List<SubjectInfo> GetSubjectInfoList(int belongId)
        {

            var where = PredicateBuilder.True<SubjectInfo>();

            // name过滤
            if (belongId != 0)
            {
                where = where.And(m => m.BelongId == belongId);
            }
            return this._repoSubjectInfo.Table.Where(where).ToList();
        }
    }
}
