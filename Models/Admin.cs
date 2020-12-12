using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookForEveryDay.Models
{
    public class Admin : User
    {
        public Admin(int id, string FirstName, string LastName, string DayOfBirthsday, string Department, string Status, string Position)
            : base(id, FirstName, LastName, DayOfBirthsday, "Admin", Department, Status, Position) { }
    }
}
