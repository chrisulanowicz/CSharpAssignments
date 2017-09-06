using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TheWall.Models;

namespace TheWall
{

    public class PostsController : Controller
    {

        private readonly DbConnector _dbConnector;

        public PostsController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("UserId") != null)
            {
                if(TempData["PostError"] != null)
                {
                    ViewBag.Error = TempData["PostError"];
                }
                ViewBag.UserName = HttpContext.Session.GetString("UserName");
                ViewBag.UserId = HttpContext.Session.GetString("UserId");
                string GetPostsQuery = $"SELECT posts.Id, posts.Message, posts.CreatedAt, users.FirstName, users.LastName FROM posts JOIN users ON posts.UserId = users.Id";
                List<Dictionary<string, object>> AllPosts = _dbConnector.Query(GetPostsQuery);
                foreach(var post in AllPosts)
                {
                    string thisId = post["Id"].ToString();
                    string GetCommentsQuery = $"SELECT comments.Id, comments.Content, comments.CreatedAt, users.FirstName, users.LastName FROM comments JOIN users ON comments.UserId = users.Id WHERE comments.PostId = {thisId}";
                    List<Dictionary<string, object>> AllComments = _dbConnector.Query(GetCommentsQuery);
                    post["comments"] = AllComments;
                }
                ViewBag.AllPosts = AllPosts;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        [HttpPost]
        [Route("posts")]
        public IActionResult Create(Post post)
        {
            if(ModelState.IsValid)
            {
                string AddPostQuery = $"INSERT INTO posts (UserId, Message, CreatedAt, UpdatedAt) VALUES ('{HttpContext.Session.GetString("UserId")}', '{post.Message}', NOW(), NOW())";
                _dbConnector.Execute(AddPostQuery);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["PostError"] = "Can't post a blank message!";
                return RedirectToAction("Index");
            }
        }

    }

}