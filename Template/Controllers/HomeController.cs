using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ****project-name****.Models;

namespace ****project-name****.Controllers
{

    public class ***model-name***sController : Controller
    {

        private ***model-name***Context _context;

        public ***model-name***sController(***model-name***Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

    }

}