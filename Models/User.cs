using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookForEveryDay.Models
{
    public class User
    {
        [Key]
        public int id;
        public string FirstName;
        public string LastName;
        public string DayOfBirthsday;
        public string Role;
        public string Department;
        public string Status;
        public string Position;
        public string Login;
        public string Password;
        public int Wage;
        public int WageForH;
        public string DateTime;

        public User(int id, string FirstName, string LastName, string DayOfBirthsday, string Role, string Department, string Status, string Position, string Login, string Password, int Wage, int WageForH, string DateTime)
        {
            this.id = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DayOfBirthsday = DayOfBirthsday;
            this.Role = Role;
            this.Department = Department;
            this.Status = Status;
            this.Position = Position;
            this.Login = Login;
            this.Password = Password;
            this.Wage = Wage;
            this.WageForH = WageForH;
            this.DateTime = DateTime;
    }
    }
}
