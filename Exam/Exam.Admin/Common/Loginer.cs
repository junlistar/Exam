using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Admin.Common
{
    /// <summary>
    /// 登录公共常量
    /// </summary>
    public static class LoginerConst
    {
        /// <summary>
        /// 账号Id
        /// </summary>
        public const string ACCOUNT_ID = "AccountId";
        /// <summary>
        /// 账号
        /// </summary>
        public const string ACCOUNT = "Account";
        /// <summary>
        /// 头像图片
        /// </summary>
        public const string ACCOUNT_IMG = "AccountImg";
    }

    /// <summary>
    /// 用户登录信息
    /// </summary>
    public static class Loginer
    {
        /// <summary>
        /// 账号
        /// </summary>
        public static string Account
        {
            get
            {
                if (SessionHelper.Get(LoginerConst.ACCOUNT) == null)
                {
                    return null;
                }
                return SessionHelper.Get(LoginerConst.ACCOUNT);
            }
        }

        /// <summary>
        /// 账号Id
        /// </summary>
        public static int AccountId
        {
            get
            {
                if (SessionHelper.Get(LoginerConst.ACCOUNT_ID) == null)
                {
                    return 0;
                }
                return Convert.ToInt32(SessionHelper.Get(LoginerConst.ACCOUNT_ID));
            }
        }

        /// <summary>
        /// 头像图片
        /// </summary>
        public static string AccountImg
        {
            get
            {
                if (SessionHelper.Get(LoginerConst.ACCOUNT_IMG) == null)
                {
                    return null;
                }
                return SessionHelper.Get(LoginerConst.ACCOUNT_IMG);
            }
        }

        /// <summary>
        /// 删除账号缓存
        /// </summary>
        public static void DelAccountCache()
        {
            SessionHelper.Del(LoginerConst.ACCOUNT);
            SessionHelper.Del(LoginerConst.ACCOUNT_ID);
            SessionHelper.Del(LoginerConst.ACCOUNT_IMG);
        }
    }
}