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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name)
        {
            return View("AllUserInfo");
        }
       
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}
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

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IOU (string user01)
        {
            
            UsersViewModel usrs = new UsersViewModel { users = db.GetUsers() };
            ViewBag.User = db.Info_Of_User(user01);
            return View("AllUserInfo", usrs);
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

        [HttpGet]
        public IActionResult UpdateUser()
        {
            return View("Update_User");
        }

    }
}
