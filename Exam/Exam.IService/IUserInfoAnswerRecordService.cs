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
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<UserInfoAnswerRecord> GetManagerList(int userinfoId, int pageNum, int pageSize, out int totalCount);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<UserInfoAnswerRecord> GetAll();

        /// <summary>
        /// 根据用户ID得到答题记录
        /// </summary>
        /// <returns></returns>
        List<UserInfoAnswerRecord> GetListForUserInfoId(int userInfoId, int pageNum, int pageSize, out int totalCount);
    }
}
