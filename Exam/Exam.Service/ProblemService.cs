using Exam.Business;
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
        /// <param name="chapterid"></param> 
        /// <returns></returns>
        public bool IsExistName(string name,int chapterid)
        {
            return this._ProblemBiz.IsExistName(name,chapterid);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<Problem> GetManagerList(string name, int belongId, int chapterId, int subjectInfoId, int problemCategoryId, int pageNum, int pageSize, out int totalCount)
        {
            return this._ProblemBiz.GetManagerList(name, belongId, chapterId, subjectInfoId, problemCategoryId, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Problem> GetAll()
        {
            return this._ProblemBiz.GetAll();
        }
        /// <summary>
        /// 根据分类获取必刷题目
        /// </summary>
        /// <param name="belongId">分类编号，注会</param>
        /// <returns></returns>
        public List<Problem> GetIntensive(int belongId)
        {
            return this._ProblemBiz.GetIntensive(belongId);
        }


        /// <summary>
        /// 获取题目列表
        /// </summary>
        /// <param name="belongId">分类id</param>
        /// <param name="chapterId">章节id</param>
        /// <param name="SubjectInfoId">科目id</param>
        /// <returns></returns>
        public List<Problem> GetProblemList(int belongId, int chapterId,int SubjectInfoId) {
            return this._ProblemBiz.GetProblemList(belongId,chapterId, SubjectInfoId);
        }
    }
}
