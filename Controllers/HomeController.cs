using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookForEveryDay.Models;

namespace BookForEveryDay.Controllers
{
    public class HomeController : Controller
    {
        WorkWithDB db = new WorkWithDB();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name)
        {
            return View("AllUserInfo");
        }
       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string fn, string ln, string dob, string r, string d, string s, string p)
        {
            db.AddUser(fn, ln, dob, r, d, s, p);
            
            return View("index");
        }

        [HttpGet]
        public IActionResult Remove()
        {
            return View("index");
        }
        [HttpPost]
        public IActionResult Remove(int id)
        {
            db.RemoveUser(id);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
