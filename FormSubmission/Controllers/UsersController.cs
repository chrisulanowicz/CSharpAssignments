using System;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{

    public class UsersController : Controller
    {

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = ModelState.Values;
            return View();
        }

        [HttpPost]
        [Route("users")]
        public IActionResult Create(string firstName, string lastName, int age, string email, string password, string confirmPassword)
        {
            User NewUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Email = email,
                Password = password
            };

            if(TryValidateModel(NewUser))
            {
                return RedirectToAction("Success");
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                return View("Index");
            }
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            return View();
        }

    }

}