using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain.Model;
using Exam.IService;

namespace Exam.Service
{
    public class AnswerRecordService: IAnswerRecordService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IAnswerRecordService _AnswerRecordBiz;

        public AnswerRecordService(IAnswerRecordService AnswerRecordBiz)
        {
            _AnswerRecordBiz = AnswerRecordBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AnswerRecord GetById(int id)
        {
            return this._AnswerRecordBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public AnswerRecord Insert(AnswerRecord model)
        {
            return this._AnswerRecordBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(AnswerRecord model)
        {
            this._AnswerRecordBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(AnswerRecord model)
        {
            this._AnswerRecordBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistName(string name)
        {
            return this._AnswerRecordBiz.IsExistName(name);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<AnswerRecord> GetManagerList(string name, int pageNum, int pageSize, out int totalCount)
        {
            return this._AnswerRecordBiz.GetManagerList(name, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<AnswerRecord> GetAll()
        {
            return this._AnswerRecordBiz.GetAll();
        }
    }
}
