using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{

    public class WeddingsController : Controller
    {

        private WeddingContext _context;

        public WeddingsController(WeddingContext context)
        {
            _context = context;

        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(IsLoggedIn() == false)
            {
                return RedirectToAction("Login", "Users");
            }
            else
            {
                ViewBag.Firstname = HttpContext.Session.GetString("FirstName");
                ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
                // List<Wedding> AllWeddings = _context.Weddings.Where(wedding => account.UserId == (int)HttpContext.Session.GetInt32("UserId")).ToList();
                List<Wedding> AllWeddings = _context.Weddings.Include(wedding => wedding.Attendees).ToList();
                ViewBag.Weddings = AllWeddings;
                return View();
            }
        }

        [HttpGet]
        [Route("weddings/new")]
        public IActionResult New()
        {
            if(IsLoggedIn() == false)
            {
                return RedirectToAction("Login", "Users");
            }
            return View();
        }

        [HttpPost]
        [Route("weddings")]
        public IActionResult Create(WeddingViewModel model)
        {
            if(ModelState.IsValid)
            {
                Wedding NewWedding = new Wedding
                {
                    UserId = (int)HttpContext.Session.GetInt32("UserId"),
                    Partner1 = model.Partner1,
                    Partner2 = model.Partner2,
                    WeddingDate = model.WeddingDate,
                    Address1 = model.Address1,
                    Address2 = model.Address2,
                    City = model.City,
                    State = model.State.ToString(),
                    Zip = model.Zip,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Weddings.Add(NewWedding);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New", model);
            }
        }

        [HttpGet]
        [Route("weddings/{weddingId}")]
        public IActionResult Show(int weddingId)
        {
            if(IsLoggedIn() == false)
            {
                return RedirectToAction("Login", "Users");
            }
            Wedding ThisWedding = _context.Weddings.Include(wedding => wedding.Attendees).ThenInclude(attendee => attendee.User).SingleOrDefault(wedding => wedding.Id == weddingId);
            ViewBag.Wedding = ThisWedding;
            // ViewBag.Firstname = HttpContext.Session.GetString("FirstName");
            // ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            return View();
        }

        [HttpPost]
        [Route("weddings/{weddingId}")]
        public IActionResult Update(int weddingId, WeddingViewModel model)
        {
            // Account UserAccount = _context.Accounts.SingleOrDefault(account => account.Id == accountId);
            // if(!ModelState.IsValid || model.TransactionType.ToString() == "Withdraw" && UserAccount.Balance < model.Amount)
            // {
            //     if(ModelState.IsValid)
            //     {
            //         ModelState.AddModelError("Amount", "Insufficient Funds");
            //     }
            //     List<Transaction> UserTransactions = _context.Transactions.Where(transaction => transaction.AccountId == accountId).OrderByDescending(transaction => transaction.UpdatedAt).ToList();
            //     ViewBag.Account = UserAccount;
            //     ViewBag.Username = HttpContext.Session.GetString("UserName");
            //     ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            //     ViewBag.Transactions = UserTransactions;
            //     return View("Show", model);
            // }

            // if(model.TransactionType.ToString() == "Deposit")
            // {
            //     UserAccount.Balance += model.Amount;
            // }
            // else
            // {
            //     UserAccount.Balance -= model.Amount;
            //     model.Amount = -model.Amount;
            // }

            // UserAccount.UpdatedAt = DateTime.Now;
            // Transaction NewTransaction = new Transaction
            // {
            //     UserId = (int)HttpContext.Session.GetInt32("UserId"),
            //     AccountId = accountId,
            //     Amount = model.Amount,
            //     CreatedAt = DateTime.Now,
            //     UpdatedAt = DateTime.Now
            // };
            // _context.Transactions.Add(NewTransaction);
            // _context.SaveChanges();
            // return RedirectToAction("Show", new { AccountId = accountId });
            return RedirectToAction("Index");
        }

        public bool IsLoggedIn()
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return false;
            }
            return true;
        }

    }

}