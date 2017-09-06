using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TheWall.Models;

namespace TheWall.Controllers
{

    public class UsersController : Controller
    {

        private readonly DbConnector _dbConnector;

        public UsersController(DbConnector connect)
        {
            _dbConnector = connect;
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
            if(ModelState.IsValid)
            {
                string FormatForMySql = model.DateOfBirth.ToString("yyyy-MM-dd HH:mm:ss");
                string AddUserQuery = $"INSERT INTO users (FirstName, LastName, UserName, DateOfBirth, Email, Password, CreatedAt, UpdatedAt) VALUES ('{model.FirstName}','{model.LastName}','{model.UserName}','{FormatForMySql}','{model.Email}','{model.Password}',NOW(),NOW())";
                _dbConnector.Execute(AddUserQuery);
                HttpContext.Session.SetString("UserName", model.UserName);
                string GetUserQuery = $"SELECT Id, UserName FROM users WHERE UserName='{model.UserName}'";
                var User = _dbConnector.Query(GetUserQuery);
                if(User.Count == 0)
                {
                    ModelState.AddModelError("FirstName", "There was a problem with registering, Please try again");
                    return View("Register", model);
                }
                else
                {
                    HttpContext.Session.SetString("UserName", (string)User[0]["UserName"]);
                    HttpContext.Session.SetString("UserId", User[0]["Id"].ToString());
                }
                return RedirectToAction("Index", "Posts");
            }
            else
            {
                return View("Register", model);
            }
        }

        [HttpPost]
        [Route("users/login")]
        public IActionResult LoginUser(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                string GetUserQuery = $"SELECT Id, UserName, Password FROM users WHERE UserName='{model.UserName}'";
                var User = _dbConnector.Query(GetUserQuery);
                if(User.Count == 0)
                {
                    ModelState.AddModelError("UserName", "Invalid Username or Password");
                    return View("Login", model);
                }
                else if((string)User[0]["Password"] != model.Password)
                {
                    ModelState.AddModelError("UserName", "Invalid Username or Password");
                    return View("Login", model);
                }
                else
                {
                    HttpContext.Session.SetString("UserName", (string)User[0]["UserName"]);
                    HttpContext.Session.SetString("UserId", User[0]["Id"].ToString());
                    return RedirectToAction("Index", "Posts");
                }
            }
            else
            {
                return View("Login", model);
            }
        }

    }

}