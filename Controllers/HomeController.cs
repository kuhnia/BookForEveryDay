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

        [HttpGet]
        public IActionResult Update_User(string FirstName)
        {
            User us = db.GetUser(FirstName);
            return View(us);
        }

        [HttpPost]
        public IActionResult Update_User(User user, string fn, string ln, string dob, string r, string d, string s, string p, string l, string pas, int w, int wfh, string dt)
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

        [HttpPost]
        public IActionResult IOU (string user01)
        {
            
            UsersViewModel usrs = new UsersViewModel { users = db.GetUsers() };
            //ViewBag.User = db.GetUser(user01);
            //ViewBag.User = db.Info_Of_User(user01);
            foreach(var item in usrs.users)
            {
                if(item.FirstName.Equals(user01))
                {
                    ViewBag.User = item;break;
                }
            }
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
