using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JHB.Business
{
    /// <summary>
    /// 业务层错误消息管理
    /// </summary>
    public class BizResult
    {
        /// <summary>
        /// The view errors
        /// </summary>
        private List<string> errorMsgs;        

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorMessage"/> class.
        /// </summary>
        public BizResult()
        {
            this.errorMsgs = new List<string>();
            IsSuccess = true;
        }

        /// <summary>
        /// Gets the view errors.
        /// </summary>
        /// <value>
        /// The view errors.
        /// </value>
        public List<string> Errors
        {
            get
            {
                return this.errorMsgs;
            }
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has error; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess
        {
            get;
            set;
        }

        /// <summary>
        /// 获取最后一条错误消息
        /// </summary>
        /// <value>
        /// The first message.
        /// </value>
        /// <returns>每一条消息</returns>
        public string LastMessage
        {
            get
            {
                return this.errorMsgs.LastOrDefault();
            }
        }

        /// <summary>
        /// 添加错误消息
        /// </summary>
        /// <param name="message">The message.</param>
        public void AddError(string message)
        {
            IsSuccess = false;

            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            this.errorMsgs.Add(message);
        }

        /// <summary>
        /// 添加错误
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="index">The index.</param>
        public void AddError(string message, int index)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            this.errorMsgs.Insert(index, message);
        }

        /// <summary>
        /// Sets the error.
        /// </summary>
        /// <param name="messages">The messages.</param>
        public void AddError(List<string> messages)
        {
            if (messages != null && messages.Count > 0)
            {
                this.errorMsgs.AddRange(messages);
            }
        }
    }

    /// <summary>
    /// 业务层错误消息管理
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BizResult<T> : BizResult
    {
        public T ReturnModel
        {
            get;
            set;
        }
    }
}
