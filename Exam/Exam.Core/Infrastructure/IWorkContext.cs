using Exam.Domain.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Core.Infrastructure
{
    /// <summary>
    /// 工作上下文
    /// </summary>
    public interface IWorkContext
    {
        /// <summary>
        /// 用户是否登录
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is login; otherwise, <c>false</c>.
        /// </value>
        bool IsLogin { get; }
         
        /// <summary>
        /// 获取或设置用户信息
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        UserInfo User { get; }
           

        /// <summary>
        /// 用户是否有效
        /// </summary>
        /// <returns></returns>
        bool IsUserValid();
    }
}
