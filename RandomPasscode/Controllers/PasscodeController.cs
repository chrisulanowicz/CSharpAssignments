using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
{

    public class PasscodeController : Controller
    {

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int? Counter = HttpContext.Session.GetInt32("Attempt");
            string Password = HttpContext.Session.GetString("Passcode");

            Counter = Counter == null ? 0 : Counter +1;
            Password = Password == null ? "Click the button to generate a passcode" : GeneratePasscode();
            
            HttpContext.Session.SetInt32("Attempt", (int)Counter);
            HttpContext.Session.SetString("Passcode", Password);
           
            ViewBag.Attempt = Counter;
            ViewBag.Code = Password;

            return View();
        }

        public string GeneratePasscode()
        {
            string temp = "";
            Random rand = new Random();
            char[] Characters = new char[66]{'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','0','1','2','3','4','5','6','7','8','9','!','?','#','$'};
            for(int i=0;i<14;i++)
            {
                temp += Characters[rand.Next(66)];
            }
            return temp;
        }

        [HttpGet]
        [Route("ajax")]
        public JsonResult AjaxCall()
        {

            int? Counter = HttpContext.Session.GetInt32("Attempt");
            string Password = HttpContext.Session.GetString("Passcode");

            Counter++;
            Password = GeneratePasscode();

            HttpContext.Session.SetInt32("Attempt", (int)Counter);

            var Result = new {
                Attempt = Counter,
                Passcode = Password
            };

            return Json(Result);
        }

    }

}