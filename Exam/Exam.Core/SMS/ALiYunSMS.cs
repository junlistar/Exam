using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliyun.MNS.Model;
using Aliyun.MNS;

namespace Exam.Core.SMS
{

    public class ALiYunSMS
    {
        private const string _endpoint = "http://1725389126977477.mns.cn-hangzhou.aliyuncs.com/"; // eg. http://1234567890123456.mns.cn-shenzhen.aliyuncs.com
        private const string _accessKeyId = "LTAIAw8Qxhw9d0fV";
        private const string _secretAccessKey = "ZvrWJnEHws9DA7UWRXd2lN6HUEgm3O";
        private const string _topicName = "sms.topic-cn-hangzhou";


        /// 管理控制台中配置的短信签名（状态必须是验证通过）
        //private const string SignName = "深圳市利德行";
        //private const string SignName = "一生时光";

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static bool SendSMS(SendSmsRequest req)
        {
            var flag = true;
            /**
             * Step 1. 初始化Client
             */
            IMNS client = new Aliyun.MNS.MNSClient(_accessKeyId, _secretAccessKey, _endpoint);
            /**
             * Step 2. 获取主题引用
             */
            Topic topic = client.GetNativeTopic(_topicName);
            /**
             * Step 3. 生成SMS消息属性
             */
            MessageAttributes messageAttributes = new MessageAttributes();
            BatchSmsAttributes batchSmsAttributes = new BatchSmsAttributes();
            // 3.1 设置发送短信的签名：SMSSignName
            batchSmsAttributes.FreeSignName = req.SignName;
            // 3.2 设置发送短信的模板SMSTemplateCode
            //batchSmsAttributes.TemplateCode = "SMS_61750032";
            batchSmsAttributes.TemplateCode = req.TemplateCode;
            //Dictionary<string, string> param = new Dictionary<string, string>();
            // 3.3 （如果短信模板中定义了参数）设置短信模板中的参数，发送短信时，会进行替换

            //param.Add("code", "4567");
            // 3.4 设置短信接收者手机号码


            if (!string.IsNullOrWhiteSpace(req.RecNum))
            {
                batchSmsAttributes.AddReceiver(req.RecNum, req.ParamString);
            }
            else
            {
                ///循环电话号码
                foreach (var item in req.LiRecNum)
                {
                    batchSmsAttributes.AddReceiver(item, req.ParamString);
                }
            }



            messageAttributes.BatchSmsAttributes = batchSmsAttributes;
            PublishMessageRequest request = new PublishMessageRequest();
            request.MessageAttributes = messageAttributes;
            /**
             * Step 4. 设置SMS消息体（必须）
             *
             * 注：目前暂时不支持消息内容为空，需要指定消息内容，不为空即可。
             */
            request.MessageBody = "smsmessage";
            try
            {
                /**
                 * Step 5. 发布SMS消息
                 */
                PublishMessageResponse resp = topic.PublishMessage(request);
                //Console.WriteLine(resp.MessageId);
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Publish SMS message failed, exception info: " + ex.Message);
                //Logger.Debug("错误信息:"+ex.Message + "!接收号码：" + req.RecNum + "!短信码:" + req.ParamString["code"] + "！签名：" + req.SignName + "！模板" + req.TemplateCode);
                flag = false;
            }

            return flag;
        }

        /// <summary>
        /// 阿里云短信参数
        /// </summary>
        public class SendSmsRequest
        {
            /// <summary>
            /// 管理控制台中配置的审核通过的短信模板的模板CODE（状态必须是验证通过）
            /// </summary>
            public string TemplateCode { get; set; }
            /// <summary>
            /// 接收号码List
            /// </summary>
            public List<string> LiRecNum { get; set; }
            /// <summary>
            /// 接收号码
            /// </summary>
            public string RecNum { get; set; }

            public string _SignName { get; set; }
            /// <summary>
            /// 签名
            /// </summary>

            public string SignName
            {
                get
                {
                    if (_SignName == null)
                    {
                        //默认短信配置模版
                        return SmsSignNameTemplate.YssgDefaultSignName;
                    }
                    else
                    {
                        return _SignName;
                    }
                }
                set
                {
                    this._SignName = value;
                }
            }
            /// <summary>
            /// 短信模板中的变量
            /// </summary>
            public Dictionary<string, string> ParamString { get; set; }
        }
    }
}
