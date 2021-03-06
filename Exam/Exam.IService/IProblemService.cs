﻿using Exam.Domain.Model;
using Exam.Domain.Model.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.IService
{
    public interface IProblemService
    {
        Problem GetById(int Id);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Problem Insert(Problem model);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Update(Problem model);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Delete(Problem model);

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <param name="chapterid"></param> 
        /// <returns></returns>
        bool IsExistName(string name, int chapterid);

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<Problem> GetManagerList(string name, int belongId, int chapterId, int subjectInfoId, int problemCategoryId, int pageNum, int pageSize,out int totalCount);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<Problem> GetAll();
        /// <summary>
        /// 根据分类获取必刷题目
        /// </summary>
        /// <param name="belongId">分类编号，注会</param>
        /// <returns></returns>
        List<Problem> GetIntensive(int belongId);

        /// <summary>
        /// 获取题目列表
        /// </summary>
        /// <param name="belongId">分类id</param>
        /// <param name="chapterId">章节id</param>
        /// <param name="SubjectInfoId">科目id</param>
        /// <returns></returns>
        List<Problem> GetProblemList(int belongId, int chapterId,int SubjectInfoId);

        /// <summary>
        /// 导入题目文件
        /// </summary>
        /// <param name="fileServerPath"></param>
        /// <returns></returns>
        ImportResponseModel ImportProblem(string fileServerPath);
    }
}
