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
    public class ExamAnswerService : IExamAnswerService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IExamAnswerBusiness _ExamAnswerBiz;

        public ExamAnswerService(IExamAnswerBusiness ExamAnswerBiz) {
            _ExamAnswerBiz = ExamAnswerBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ExamAnswer GetById(int id)
        {
            return this._ExamAnswerBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ExamAnswer Insert(ExamAnswer model)
        {
            return this._ExamAnswerBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(ExamAnswer model)
        {
            this._ExamAnswerBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(ExamAnswer model)
        {
            this._ExamAnswerBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._ExamAnswerBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ExamAnswer> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._ExamAnswerBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<ExamAnswer> GetAll()
        {
            return this._ExamAnswerBiz.GetAll();
        }
    }
}
