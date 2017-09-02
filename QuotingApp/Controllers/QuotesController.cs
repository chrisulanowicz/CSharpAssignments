using DbConnection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace QuotingApp.Controllers
{

    public class QuotesController : Controller
    {

        [HttpGet]
        [Route("")]
        public IActionResult New()
        {
            return View();
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Index()
        {
            string query = "SELECT * FROM quotes ORDER BY created_at DESC";
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query(query);
            ViewBag.Quotes = AllQuotes;
            return View();
        }

        [HttpPost]
        [Route("quotes")]
        public IActionResult Create(string name, string quote)
        {
            List<string> errors = new List<string>();
            if(name == null)
            {
                errors.Add("Name cannot be blank");
            }
            if(quote == null)
            {
                errors.Add("Quote cannot be blank");
            }
            if(errors.Count > 0)
            {
                ViewBag.Errors = errors;
                return View("New");
            }
            else
            {
                string query = $"INSERT INTO quotes (name, quote, created_at, updated_at) VALUES ('{name}', '{quote}', '{DateTime.Now}', '{DateTime.Now}')";
                DbConnector.Execute(query);
                return RedirectToAction("Index");
            }
        }

    }

}