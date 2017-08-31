using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace SurveyForm.Controllers
{

    public class SurveyController : Controller
    {

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(string name, string location, string language, string comment)
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            
            return View("Result");
        }

    }

}