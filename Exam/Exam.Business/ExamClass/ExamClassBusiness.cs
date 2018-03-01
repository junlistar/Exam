﻿using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class ExamClassBusiness : IExamClassBusiness
    {
        private IRepository<ExamClass> _repoExamClass;

        public ExamClassBusiness(
          IRepository<ExamClass> repoExamClass
          )
        {
            _repoExamClass = repoExamClass;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ExamClass GetById(int id)
        {
            return this._repoExamClass.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ExamClass Insert(ExamClass model)
        {
            return this._repoExamClass.Insert(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._repoExamClass.Table.Any(p => p.Title == name);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(ExamClass model)
        {
            this._repoExamClass.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(ExamClass model)
        {
            this._repoExamClass.Delete(model);
        }
         

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<ExamClass> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<ExamClass>();
             
            // name过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }

            totalCount = this._repoExamClass.Table.Where(where).Count();
            return this._repoExamClass.Table.Where(where).OrderBy(p => p.ExamClassId).Skip((pageNum-1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<ExamClass> GetAll()
        {
            return this._repoExamClass.Table.ToList();
        }

        /// <summary>
        /// 获取考试分类
        /// </summary> 
        /// <returns></returns>
        public List<ExamClass> GetExamClassList()
        {
            var where = PredicateBuilder.True<ExamClass>();
            where = where.And(m => m.IsShow==1);
            return this._repoExamClass.Table.Where(where).OrderBy(p => p.ExamClassId).ToList();
        }
    }
}


