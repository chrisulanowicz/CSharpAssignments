using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AjaxNotes.Controllers
{
    public class NotesController : Controller
    {
        
        private readonly DbConnector _dbConnector;

        public NotesController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dictionary<string, object>> AllNotes = _dbConnector.Query("SELECT * FROM notes");
            ViewBag.Notes = AllNotes;
            return View();
        }

        [HttpPost]
        [Route("notes")]
        public IActionResult Create(string title)
        {
            string query = $"INSERT INTO notes (title,created_at,updated_at) VALUES ('{title}','{DateTime.Now}','{DateTime.Now}')";
            _dbConnector.Execute(query);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("notes/{id}/edit")]
        public IActionResult Edit(int id, string note)
        {
            string query = $"UPDATE notes SET note='{note}' WHERE id={id}";
            _dbConnector.Execute(query);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("notes/{id}/destroy")]
        public IActionResult Delete(int id)
        {
            string query = $"DELETE FROM notes WHERE id={id}";
            _dbConnector.Execute(query);
            return RedirectToAction("Index");
        }
    }
}