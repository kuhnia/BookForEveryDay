using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookForEveryDay.Models;
using BookForEveryDay.ViewModel;

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
        public IActionResult AllUser()
        {
            UsersViewModel usrs = new UsersViewModel{users = db.GetUsers()};
            return View("AllUserInfo", usrs);
        }

        [HttpGet]
        public IActionResult GetUser(int id)
        {;
            return View("AllUserInfo", db.GetUser(id));
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
        public IActionResult Create(string fn, string ln, string dob, string r, string d, string s, string p, string l, string pas, int w, int wfh, string dt)
        {
            db.AddUser(fn, ln, dob, r, d, s, p, l, pas, w, wfh, dt);
            
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

        [HttpGet]
        public IActionResult UpdateUser(string FirstName)
        {
            User us = db.GetUser(FirstName);
            return View(us);
        }

        [HttpPost]
        public IActionResult UpdateUser(User user, string fn, string ln, string dob, string r, string d, string s, string p, string l, string pas, int w, int wfh, string dt)
        {
            user.FirstName = fn;
            user.LastName = ln;
            user.DayOfBirthsday = dob;
            user.Role = r;
            user.Department = d;
            user.Status = s;
            user.Position = p;
            user.Login = l;
            user.Password = pas;
            user.Wage = w;
            user.WageForH = wfh;
            user.DateTime = dt;
            user.Update();
            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //public IActionResult View_info()
        //{           
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
