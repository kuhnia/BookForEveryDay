using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookForEveryDay.Models
{
    public class Task
    {
        public int Id;
        public int User_Id;
        public string Caption;
        public string Comment;
        public string Status;

        public Task(int id, int User_Id, string Caption, string Comment, string Status)
        {
            this.Id = id;
            this.User_Id = User_Id;
            this.Caption = Caption;
            this.Comment = Comment;
            this.Status = Status;
        }

    }
}
