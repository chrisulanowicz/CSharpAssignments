using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{

    public class WeddingsController : Controller
    {

        private WeddingContext _context;

        public WeddingsController(WeddingContext context)
        {
            _context = context;

        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(IsLoggedIn() == false)
            {
                return RedirectToAction("Login", "Users");
            }
            else
            {
                ViewBag.Firstname = HttpContext.Session.GetString("FirstName");
                ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
                List<Wedding> AllWeddings = _context.Weddings.Include(wedding => wedding.Attendees).ToList();
                foreach(var wedding in AllWeddings)
                {
                    if(wedding.WeddingDate < DateTime.Now)
                    {
                        AllWeddings.Remove(wedding);
                        _context.Weddings.Remove(wedding);
                    }
                }
                _context.SaveChanges();
                ViewBag.Weddings = AllWeddings;
                return View();
            }
        }

        [HttpGet]
        [Route("weddings/new")]
        public IActionResult New()
        {
            if(IsLoggedIn() == false)
            {
                return RedirectToAction("Login", "Users");
            }
            return View();
        }

        [HttpPost]
        [Route("weddings")]
        public IActionResult Create(WeddingViewModel model)
        {
            if(ModelState.IsValid)
            {
                Wedding NewWedding = new Wedding
                {
                    UserId = (int)HttpContext.Session.GetInt32("UserId"),
                    Partner1 = model.Partner1,
                    Partner2 = model.Partner2,
                    WeddingDate = model.WeddingDate,
                    Address1 = model.Address1,
                    Address2 = model.Address2,
                    City = model.City,
                    State = model.State.ToString(),
                    Zip = model.Zip,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Weddings.Add(NewWedding);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New", model);
            }
        }

        [HttpGet]
        [Route("weddings/{weddingId}")]
        public IActionResult Show(int weddingId)
        {
            if(IsLoggedIn() == false)
            {
                return RedirectToAction("Login", "Users");
            }
            Wedding ThisWedding = _context.Weddings.Include(wedding => wedding.Attendees).ThenInclude(attendee => attendee.User).SingleOrDefault(wedding => wedding.Id == weddingId);
            ViewBag.Wedding = ThisWedding;
            return View();
        }

        [HttpGet]
        [Route("weddings/{weddingId}/delete")]
        public IActionResult Destroy(int weddingId)
        {
            Wedding MyWedding = _context.Weddings.SingleOrDefault(wedding => wedding.Id == weddingId);
            _context.Weddings.Remove(MyWedding);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // placeholder route for now
        [HttpPost]
        [Route("weddings/{weddingId}")]
        public IActionResult Update(int weddingId, WeddingViewModel model)
        {
            return RedirectToAction("Index");
        }

        public bool IsLoggedIn()
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return false;
            }
            return true;
        }

    }

}