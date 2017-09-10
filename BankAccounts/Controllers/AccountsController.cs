using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using BankAccounts.Models;

namespace BankAccounts.Controllers
{

    public class AccountsController : Controller
    {

        private BankContext _context;

        public AccountsController(BankContext context)
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
                ViewBag.Username = HttpContext.Session.GetString("UserName");
                ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
                List<Account> UserAccounts = _context.Accounts.Where(account => account.UserId == (int)HttpContext.Session.GetInt32("UserId")).ToList();
                ViewBag.Accounts = UserAccounts;
                return View();
            }
        }

        [HttpGet]
        [Route("accounts/new")]
        public IActionResult New()
        {
            if(IsLoggedIn() == false)
            {
                return RedirectToAction("Login", "Users");
            }
            return View();
        }

        [HttpPost]
        [Route("accounts")]
        public IActionResult Create(AccountViewModel model)
        {
            if(ModelState.IsValid)
            {
                Account NewAccount = new Account
                {
                    UserId = (int)HttpContext.Session.GetInt32("UserId"),
                    AccountType = model.AccountType.ToString(),
                    Balance = model.Balance,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Accounts.Add(NewAccount);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New", model);
            }
        }

        [HttpGet]
        [Route("accounts/{AccountId}")]
        public IActionResult Show(int AccountId)
        {
            if(IsLoggedIn() == false)
            {
                return RedirectToAction("Login", "Users");
            }
            Account UserAccount = _context.Accounts.SingleOrDefault(account => account.Id == AccountId);
            List<Transaction> UserTransactions = _context.Transactions.Where(transaction => transaction.AccountId == AccountId).OrderByDescending(transaction => transaction.UpdatedAt).ToList();
            ViewBag.Account = UserAccount;
            ViewBag.Transactions = UserTransactions;
            ViewBag.Username = HttpContext.Session.GetString("UserName");
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            return View();
        }

        [HttpPost]
        [Route("accounts/{accountId}")]
        public IActionResult Update(int accountId, TransactionViewModel model)
        {
            Account UserAccount = _context.Accounts.SingleOrDefault(account => account.Id == accountId);
            if(!ModelState.IsValid || model.TransactionType.ToString() == "Withdraw" && UserAccount.Balance < model.Amount)
            {
                if(ModelState.IsValid)
                {
                    ModelState.AddModelError("Amount", "Insufficient Funds");
                }
                List<Transaction> UserTransactions = _context.Transactions.Where(transaction => transaction.AccountId == accountId).OrderByDescending(transaction => transaction.UpdatedAt).ToList();
                ViewBag.Account = UserAccount;
                ViewBag.Username = HttpContext.Session.GetString("UserName");
                ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
                ViewBag.Transactions = UserTransactions;
                return View("Show", model);
            }

            if(model.TransactionType.ToString() == "Deposit")
            {
                UserAccount.Balance += model.Amount;
            }
            else
            {
                UserAccount.Balance -= model.Amount;
                model.Amount = -model.Amount;
            }

            UserAccount.UpdatedAt = DateTime.Now;
            Transaction NewTransaction = new Transaction
            {
                UserId = (int)HttpContext.Session.GetInt32("UserId"),
                AccountId = accountId,
                Amount = model.Amount,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _context.Transactions.Add(NewTransaction);
            _context.SaveChanges();
            return RedirectToAction("Show", new { AccountId = accountId });
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