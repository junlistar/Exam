using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Business;
using Exam.Domain.Model;
using Exam.IService;

namespace Exam.Service
{
    public class UserInfoAnswerRecordService : IUserInfoAnswerRecordService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IUserInfoAnswerRecordBusiness _userInfoAnswerRecordService;

        public UserInfoAnswerRecordService(IUserInfoAnswerRecordBusiness userInfoAnswerRecordService)
        {
            _userInfoAnswerRecordService = userInfoAnswerRecordService;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfoAnswerRecord GetById(int id)
        {
            return this._userInfoAnswerRecordService.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserInfoAnswerRecord Insert(UserInfoAnswerRecord model)
        {
            return this._userInfoAnswerRecordService.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(UserInfoAnswerRecord model)
        {
            this._userInfoAnswerRecordService.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(UserInfoAnswerRecord model)
        {
            this._userInfoAnswerRecordService.Delete(model);
        }


        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<UserInfoAnswerRecord> GetManagerList(int userinfoId, int pageNum, int pageSize, out int totalCount)
        {
            return this._userInfoAnswerRecordService.GetManagerList(userinfoId, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<UserInfoAnswerRecord> GetAll()
        {
            return this._userInfoAnswerRecordService.GetAll();
        }

        /// <summary>
        /// 根据用户ID得到答题记录
        /// </summary>
        /// <returns></returns>
        public List<UserInfoAnswerRecord> GetListForUserInfoId(int userInfoId, int pageNum, int pageSize, out int totalCount)
        {
            return this._userInfoAnswerRecordService.GetListForUserInfoId(userInfoId, pageNum, pageSize, out totalCount);
        }

        /// <summary>
        /// 通过章节编号，用户编号，获取用户最后一次对于该章节的答题记录
        /// </summary>
        /// <param name="chapterId">章节编号</param>
        /// <param name="userInfoId">用户编号</param>
        /// <returns></returns>
        public UserInfoAnswerRecord GetUserLastRecord(int chapterId, int userInfoId)
        {
            return this._userInfoAnswerRecordService.GetUserLastRecord( chapterId, userInfoId);
        }
    }
}
