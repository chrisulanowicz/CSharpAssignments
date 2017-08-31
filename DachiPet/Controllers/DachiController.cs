using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DachiPet.Controllers
{

    public class DachiController : Controller
    {

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetObjectFromJson<Dachi>("dachi") == null)
            {
                HttpContext.Session.SetObjectAsJson("dachi", new Dachi("doe"));
            }
            ViewBag.Dachi = HttpContext.Session.GetObjectFromJson<Dachi>("dachi");
            return View();
        }

        [HttpGet]
        [Route("restart")]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("process/{choice}")]
        public JsonResult Process(string choice)
        {
            var Pet = HttpContext.Session.GetObjectFromJson<Dachi>("dachi");
            switch(choice)
            {
                case "feed":
                    Pet.Feed();
                    break;
                case "play":
                    Pet.Play();
                    break;
                case "work":
                    Pet.Work();
                    break;
                case "sleep":
                    Pet.Sleep();
                    break;
                default:
                    break;
            }
            Pet.CheckHealth();
            HttpContext.Session.SetObjectAsJson("dachi", Pet);
            return Json(Pet);
        }

        [HttpGet]
        [Route("setName/{name}")]
        public IActionResult Rename(string name)
        {
            var Pet = HttpContext.Session.GetObjectFromJson<Dachi>("dachi");
            Pet.Name = name;
            HttpContext.Session.SetObjectAsJson("dachi", Pet);
            return RedirectToAction("Index");
        }

    }

}