using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookForEveryDay.Models;

namespace BookForEveryDay.ViewModel
{
    public class UsersViewModel
    {
        public IEnumerable<User> users { get; set; }
    }
}
