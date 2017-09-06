using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TheWall.Models;

namespace TheWall.Controllers
{

    public class CommentsController : Controller
    {

        private readonly DbConnector _dbConnector;

        public CommentsController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        [HttpPost]
        [Route("comments")]
        public IActionResult Create(Comment comment)
        {
            string AddCommentQuery = $"INSERT INTO comments (UserId, PostId, Content, CreatedAt, UpdatedAt) VALUES ('{HttpContext.Session.GetString("UserId")}','{comment.PostId}','{comment.Content}', NOW(), NOW())";
            Console.WriteLine(AddCommentQuery);
            _dbConnector.Execute(AddCommentQuery);
            return RedirectToAction("Index", "Posts");
        }

    }

}