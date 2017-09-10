using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using BankAccounts.Models;

namespace BankAccounts.Controllers
{

    public class UsersController : Controller
    {

        private BankContext _context;

        public UsersController(BankContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpPost]
        [Route("users")]
        public IActionResult Create(RegisterViewModel model)
        {
            // following validates for unique usernames and emails
            // working on a version that puts this in the Models where it belongs
            // in the meantime I'm leaving this here in the Controller until that version is working
            bool ExistingUserName = _context.Users.Any(user => user.UserName == model.UserName);
            bool ExistingEmail = _context.Users.Any(user => user.Email == model.Email);
            if(ExistingUserName == true)
            {
                ModelState.AddModelError("UserName", "Username already taken");
            }
            if(ExistingEmail == true)
            {
                ModelState.AddModelError("Email", "Email already registered");
            }

            if(ModelState.IsValid)
            {
                User NewUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    BirthDate = model.BirthDate,
                    Email = model.Email,
                    Password = model.Password,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
                _context.Users.Add(NewUser);
                _context.SaveChanges();
                User LoggedUser = _context.Users.SingleOrDefault(x => x.UserName == NewUser.UserName);
                HttpContext.Session.SetString("UserName", LoggedUser.UserName);
                HttpContext.Session.SetInt32("UserId", LoggedUser.Id);
                return RedirectToAction("Index", "Accounts");
            }
            else
            {
                return View("Register", model);
            }
        }

        [HttpPost]
        [Route("users/login")]
        public IActionResult UserLogin(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                User LoggingUser = _context.Users.SingleOrDefault(user => user.UserName == model.UserName);
                var Hasher = new PasswordHasher<User>();
                if(LoggingUser == null)
                {
                    ModelState.AddModelError("UserName", "Invalid Username or Password");
                    return View("Login", model);
                }
                else if(Hasher.VerifyHashedPassword(LoggingUser, LoggingUser.Password, model.Password) == 0)
                {
                    ModelState.AddModelError("UserName", "Invalid Username or Password");
                    return View("Login", model);
                }
                else
                {
                    HttpContext.Session.SetString("UserName", LoggingUser.UserName);
                    HttpContext.Session.SetInt32("UserId", LoggingUser.Id);
                    return RedirectToAction("Index", "Accounts");
                }

            }
            else
            {
                return View("Login", model);
            }

        }

    }

}