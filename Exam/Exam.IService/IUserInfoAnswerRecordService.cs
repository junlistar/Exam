using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain.Model;

namespace Exam.IService
{
    public interface IUserInfoAnswerRecordService
    {
        UserInfoAnswerRecord GetById(int Id);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        UserInfoAnswerRecord Insert(UserInfoAnswerRecord model);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Update(UserInfoAnswerRecord model);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Delete(UserInfoAnswerRecord model);

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        bool IsExistName(string name, int type);

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<UserInfoAnswerRecord> GetManagerList(string name, int pageNum, int pageSize, out int totalCount);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<UserInfoAnswerRecord> GetAll();
    }
}
