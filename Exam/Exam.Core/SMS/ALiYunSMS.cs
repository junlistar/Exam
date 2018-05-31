using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliyun.MNS.Model;
using Aliyun.MNS;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Dysmsapi.Model.V20170525;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
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

            String product = "Dysmsapi";//短信API产品名称（短信产品名固定，无需修改）
            String domain = "dysmsapi.aliyuncs.com";//短信API产品域名（接口地址固定，无需修改）
            String accessKeyId = "LTAIAw8Qxhw9d0fV";//你的accessKeyId，参考本文档步骤2
            String accessKeySecret = "ZvrWJnEHws9DA7UWRXd2lN6HUEgm3O";//你的accessKeySecret，参考本文档步骤2
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);
            //IAcsClient client = new DefaultAcsClient(profile);
            // SingleSendSmsRequest request = new SingleSendSmsRequest();
            //初始化ascClient,暂时不支持多region（请勿修改）
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            //SendSmsRequest request = new SendSmsRequest();
            try
            {
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
                //request.PhoneNumbers = "xxxxxxxx";
                ////必填:短信签名-可在短信控制台中找到
                //request.SignName = "xxxxxxxx";
                ////必填:短信模板-可在短信控制台中找到
                //request.TemplateCode = "SMS_00000001";
                ////可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                //request.TemplateParam = "{\"name\":\"Tom\"， \"code\":\"123\"}";
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                //request.OutId = "yourOutId";
                //请求失败这里会抛ClientException异常

                //默认签名
                if (string.IsNullOrWhiteSpace(req.SignName))
                {
                    req.SignName = SmsSignNameTemplate.DefaultSignName;
                }
                SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(req);
                System.Console.WriteLine(sendSmsResponse.Message);
                 
            }
            catch (ServerException e)
            {
                log4net.ILog log = log4net.LogManager.GetLogger("SendSMS");
                log.Error("Error", e);
                //System.Console.WriteLine("Hello World!");
            }
            catch (ClientException e)
            {
                log4net.ILog log = log4net.LogManager.GetLogger("SendSMS");
                log.Error("Error", e);
                //System.Console.WriteLine("Hello World!");
            }

            return true;
            //#region
            //var flag = true;
            ///**
            // * Step 1. 初始化Client
            // */
            //IMNS client = new Aliyun.MNS.MNSClient(_accessKeyId, _secretAccessKey, _endpoint);
            ///**
            // * Step 2. 获取主题引用
            // */
            //Topic topic = client.GetNativeTopic(_topicName);
            ///**
            // * Step 3. 生成SMS消息属性
            // */
            //MessageAttributes messageAttributes = new MessageAttributes();
            //BatchSmsAttributes batchSmsAttributes = new BatchSmsAttributes();
            //// 3.1 设置发送短信的签名：SMSSignName
            //batchSmsAttributes.FreeSignName = req.SignName;
            //// 3.2 设置发送短信的模板SMSTemplateCode
            ////batchSmsAttributes.TemplateCode = "SMS_61750032";
            //batchSmsAttributes.TemplateCode = req.TemplateCode;
            ////Dictionary<string, string> param = new Dictionary<string, string>();
            //// 3.3 （如果短信模板中定义了参数）设置短信模板中的参数，发送短信时，会进行替换

            ////param.Add("code", "4567");
            //// 3.4 设置短信接收者手机号码


            //if (!string.IsNullOrWhiteSpace(req.RecNum))
            //{
            //    batchSmsAttributes.AddReceiver(req.RecNum, req.ParamString);
            //}
            //else
            //{
            //    ///循环电话号码
            //    foreach (var item in req.LiRecNum)
            //    {
            //        batchSmsAttributes.AddReceiver(item, req.ParamString);
            //    }
            //}



            //messageAttributes.BatchSmsAttributes = batchSmsAttributes;
            //PublishMessageRequest request = new PublishMessageRequest();
            //request.MessageAttributes = messageAttributes;
            ///**
            // * Step 4. 设置SMS消息体（必须）
            // *
            // * 注：目前暂时不支持消息内容为空，需要指定消息内容，不为空即可。
            // */
            //request.MessageBody = "smsmessage";
            //try
            //{
            //    /**
            //     * Step 5. 发布SMS消息
            //     */
            //    PublishMessageResponse resp = topic.PublishMessage(request);
            //    //Console.WriteLine(resp.MessageId);
            //}
            //catch (Exception ex)
            //{
            //    //Console.WriteLine("Publish SMS message failed, exception info: " + ex.Message);
            //    //Logger.Debug("错误信息:"+ex.Message + "!接收号码：" + req.RecNum + "!短信码:" + req.ParamString["code"] + "！签名：" + req.SignName + "！模板" + req.TemplateCode);
            //    flag = false;
            //}

            //return flag;
            //#endregion
        }

        /// <summary>
        /// 阿里云短信参数
        /// </summary>
        //public class SendSmsRequest
        //{
        //    /// <summary>
        //    /// 管理控制台中配置的审核通过的短信模板的模板CODE（状态必须是验证通过）
        //    /// </summary>
        //    public string TemplateCode { get; set; }
        //    /// <summary>
        //    /// 接收号码List
        //    /// </summary>
        //    public List<string> LiRecNum { get; set; }
        //    /// <summary>
        //    /// 接收号码
        //    /// </summary>
        //    public string PhoneNumbers { get; set; }

        //    public string _SignName { get; set; }

        //    public string TemplateParam { get; set; }

        //    public string OutId { get; set; }
        //    /// <summary>
        //    /// 签名
        //    /// </summary>

        //    public string SignName
        //    {
        //        get
        //        {
        //            if (_SignName == null)
        //            {
        //                //默认短信配置模版
        //                return SmsSignNameTemplate.DefaultSignName;
        //            }
        //            else
        //            {
        //                return _SignName;
        //            }
        //        }
        //        set
        //        {
        //            this._SignName = value;
        //        }
        //    }
        //    /// <summary>
        //    /// 短信模板中的变量
        //    /// </summary>
        //    public Dictionary<string, string> ParamString { get; set; }
        //}
    }
}
