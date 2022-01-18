using SmsPanel.FastSend_RayganSMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsPanel
{
    public class AuthenticationSms
    {
        private string UserName, PassWord;
        public string SMS_Footer { get; set; }
        public AuthenticationSms(string usr , string pss , string footer = "")
        {
            UserName = usr;
            PassWord = pss;
            SMS_Footer = footer;
        }
        public bool AutoSendCode(string Phone)
        {
            FastSendSoap sms = new FastSendSoapClient();
            AutoSendCodeRequestBody ReqBody = new AutoSendCodeRequestBody(UserName, PassWord, Phone, SMS_Footer);
            AutoSendCodeRequest Req = new AutoSendCodeRequest(ReqBody);
            long SendRslt = sms.AutoSendCode(Req).Body.AutoSendCodeResult;
            if (SendRslt > 2000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckSendCode(string Phone,string Code)
        {
            FastSendSoap sms = new FastSendSoapClient();
            CheckSendCodeRequestBody b = new CheckSendCodeRequestBody(UserName, PassWord, Phone, Code);
            CheckSendCodeRequest x = new CheckSendCodeRequest(b);
            if (sms.CheckSendCode(x).Body.CheckSendCodeResult)
            {
                return true;
            }
            else return false;
        }
        public bool SendMessageWithCode(string Phone , string Message)
        {
            FastSendSoap sms = new FastSendSoapClient();
            SendMessageWithCodeRequestBody ReqBody = new SendMessageWithCodeRequestBody(UserName, PassWord, Phone, Message);
            SendMessageWithCodeRequest Req = new SendMessageWithCodeRequest(ReqBody);
            if (sms.SendMessageWithCode(Req).Body.SendMessageWithCodeResult > 2000)
            {
                return true;
            }
            else return false;
        }
    }
}
