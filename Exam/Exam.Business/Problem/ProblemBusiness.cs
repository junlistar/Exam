﻿using Exam.Core.Data;
using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public class ProblemBusiness : IProblemBusiness
    {
        private IRepository<Problem> _repoProblem;

        public ProblemBusiness(
          IRepository<Problem> repoProblem
          )
        {
            _repoProblem = repoProblem;
        }
        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Problem GetById(int id)
        {
            return this._repoProblem.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Problem Insert(Problem model)
        {
            return this._repoProblem.Insert(model);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Problem model)
        {
            this._repoProblem.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Problem model)
        {
            this._repoProblem.Delete(model);
        }



        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <param name="chapterid"></param> 
        /// <returns></returns>
        public bool IsExistName(string name, int chapterid)
        {
            return this._repoProblem.Table.Any(p => p.Title == name && p.ChapterId == chapterid);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary> 
        /// <returns></returns>
        public List<Problem> GetManagerList(string name,int belongId, int chapterId, int subjectInfoId, int problemCategoryId, int pageNum, int pageSize, out int totalCount)
        {
            var where = PredicateBuilder.True<Problem>();

            // 过滤
            if (!string.IsNullOrEmpty(name))
            {
                where = where.And(m => m.Title.Contains(name));
            }
            if (belongId!=0)
            {
                where = where.And(m => m.BelongId == belongId);
            }
            if (chapterId != 0)
            {
                where = where.And(m => m.ChapterId == chapterId);
            }
            if (subjectInfoId != 0)
            {
                where = where.And(m => m.SubjectInfoId == subjectInfoId);
            }
            if (problemCategoryId != 0)
            {
                where = where.And(m => m.ProblemCategoryId == problemCategoryId);
            }

            totalCount = this._repoProblem.Table.Where(where).Count();
            return this._repoProblem.Table.Where(where).OrderBy(p => p.ProblemId).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Problem> GetAll()
        {
            return this._repoProblem.Table.ToList();
        }
        /// <summary>
        /// 根据分类获取必刷题目
        /// </summary>
        /// <param name="belongId"></param>
        /// <returns></returns>
        public List<Problem> GetIntensive(int belongId)
        {
            var where = PredicateBuilder.True<Problem>();

            if (belongId != 0)
            {
                where = where.And(m => m.BelongId == belongId);
            }
            else
            {
                return new List<Problem>();
            }
            where = where.And(m => m.IsImportant == 1);

            return this._repoProblem.Table.Where(where).OrderBy(p => p.ProblemId).ToList();
        }
        /// <summary>
        /// 获取题目列表
        /// </summary>
        /// <param name="belongId">分类id</param>
        /// <param name="chapterId">章节id</param>
        /// <param name="SubjectInfoId">科目id</param>
        /// <returns></returns>
        public List<Problem> GetProblemList(int belongId, int chapterId,int SubjectInfoId)
        {
            var where = PredicateBuilder.True<Problem>();

            if (belongId != 0)
            {
                where = where.And(m => m.BelongId == belongId);
            }
            if (chapterId != 0)
            {
                where = where.And(m => m.ChapterId == chapterId);
            }

            if (SubjectInfoId != 0)
            {
                where = where.And(m => m.SubjectInfoId == SubjectInfoId);
            }
            return this._repoProblem.Table.Where(where).OrderBy(p => p.ProblemId).ToList();
        }
    }
}


