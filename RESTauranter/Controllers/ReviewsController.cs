using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{

    public class ReviewsController : Controller
    {

        private ReviewsContext _context;

        public ReviewsController(ReviewsContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Home()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("reviews")]
        public IActionResult Index()
        {
            List<Review> AllReviews = _context.Reviews.OrderByDescending(review => review.CreatedAt).ToList();
            ViewBag.Reviews = AllReviews;
            return View();
        }

        [HttpGet]
        [Route("reviews/new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Route("reviews")]
        public IActionResult Create(Review review)
        {
            if(ModelState.IsValid)
            {
                Review NewReview = new Review
                {
                    Reviewer = review.Reviewer,
                    Restaurant = review.Restaurant,
                    ReviewBody = review.ReviewBody,
                    Rating = review.Rating,
                    VisitDate = review.VisitDate,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Reviews.Add(NewReview);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New", review);
            }
        }

        [HttpGet]
        [Route("reviews/{id}/{help}")]
        public IActionResult Update(string id, string help)
        {
            int ReviewId;
            int.TryParse(id, out ReviewId);
            Review ReviewToEdit = _context.Reviews.SingleOrDefault(review => review.Id == ReviewId);
            if(help.Equals("helpful"))
            {
                ReviewToEdit.Helpful++;
            }
            else if(help.Equals("unhelpful"))
            {
                ReviewToEdit.UnHelpful++;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
            // return Json(ReviewToEdit); would like to just update helpful/unhelpful numbers via AJAX later
        }
    }
}