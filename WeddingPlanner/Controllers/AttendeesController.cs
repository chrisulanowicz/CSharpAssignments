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

    public class AttendeesController : Controller
    {

        private WeddingContext _context;

        public AttendeesController(WeddingContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("attendees/{weddingId}")]
        public IActionResult Create(int weddingId)
        {
            Attendee NewRSVP = new Attendee
            {
                UserId = (int)HttpContext.Session.GetInt32("UserId"),
                WeddingId = weddingId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _context.Attendees.Add(NewRSVP);
            _context.SaveChanges();
            return RedirectToAction("Index", "Weddings");
        }

        [HttpGet]
        [Route("attendees/{weddingId}/delete")]
        public IActionResult Update(int weddingId)
        {
            int AttendeeId = (int)HttpContext.Session.GetInt32("UserId");
            Attendee RetrievedUser = _context.Attendees.SingleOrDefault(attendee => attendee.UserId == AttendeeId && attendee.WeddingId == weddingId);
            _context.Attendees.Remove(RetrievedUser);
            _context.SaveChanges();
            return RedirectToAction("Index", "Weddings");
        }

    }

}