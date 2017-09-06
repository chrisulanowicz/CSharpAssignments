using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LoginRegistration.Models;

namespace LoginRegistration.Controllers
{

    public class UsersController : Controller
    {

        private readonly DbConnector _dbConnector;

        public UsersController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        [HttpGet]
        [Route("")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Route("users")]
        public IActionResult Create(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                string FormatForMySql = model.DateOfBirth.ToString("yyyy-MM-dd HH:mm:ss");
                string query = $"INSERT INTO users (FirstName, LastName, UserName, DateOfBirth, Email, Password, CreatedAt, UpdatedAt) VALUES ('{model.FirstName}','{model.LastName}','{model.UserName}','{FormatForMySql}','{model.Email}','{model.Password}',NOW(),NOW())";
                _dbConnector.Execute(query);
                HttpContext.Session.SetString("UserName", model.UserName);
                return RedirectToAction("Index");
            }
            else
            {
                return View("New", model);
            }
        }

        [HttpGet]
        [Route("users")]
        public IActionResult Index()
        {
            List<Dictionary<string, object>> AllUsers = _dbConnector.Query("SELECT * FROM users");
            ViewBag.Users = AllUsers;
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("users/login")]
        public IActionResult LoginUser(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                string GetUser = $"SELECT * FROM users WHERE email='{model.Email}'";
                var User = _dbConnector.Query(GetUser);
                if(User.Count == 0)
                {
                    ModelState.AddModelError("Email", "Invalid Email or Password");
                    return View("Login", model);
                }
                else if((string)User[0]["Password"] != model.Password)
                {
                    ModelState.AddModelError("Email", "Invalid Email or Password");
                    return View("Login", model);
                }
                else
                {
                    HttpContext.Session.SetString("UserName", (string)User[0]["UserName"]);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View("Login", model);
            }
        }

    }

}
