using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS_MVC.Controllers
{
    public class HomeController : Controller
    {
        SmsPanel.AuthenticationSms sms = new SmsPanel.AuthenticationSms("Test", "Test", "LightCompany.ir");
        public ActionResult Index()
        {
            bool SendRslt = sms.AutoSendCode("09117449564");
            if (SendRslt)
            {
                //Send Success
            }
            else
            {
                //Send Failed
            }
            return View();
        }
        [HttpPost]
        public ActionResult Verify(string Code)
        {
            ViewBag.Result = sms.CheckSendCode("09117449564", Code);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Result = sms.SendMessageWithCode("09117449564", "LightCompany Test Message");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}