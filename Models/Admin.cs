using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookForEveryDay.Models
{
    public class Admin : User
    {
        public Admin(int id, string FirstName, string LastName, string DayOfBirthsday, string Department, string Status, string Position, string Login, string Password, int Wage, int WageForH, string DateTime)
            : base(id, FirstName, LastName, DayOfBirthsday, "Admin", Department, Status, Position, Login, Password, Wage, WageForH, DateTime) { }
    }
}
