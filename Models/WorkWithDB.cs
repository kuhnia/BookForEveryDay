using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;//

namespace BookForEveryDay.Models
{
    public class WorkWithDB
    {
        static string connectionString = @"Data Source=BookForEveryDayDB.mssql.somee.com;Initial Catalog=BookForEveryDayDB;User ID=Qwertytrewq123_SQLLogin_1;Password=gglxs93hdw;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool AddUser(string fn, string ln, string dob, string r, string d, string s, string p, string l, string pas, int w, int wfh, string dt)
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) // Додавання нового юзера.
            {
                DateTime time = Convert.ToDateTime(dob);             // Use current time
                string format = "yyyy-MM-dd HH:mm:ss";    // modify the format depending upon input required in the column in database 
                connection.Open();
                string command = $@"insert into Users values('{fn}', '{ln}', '{time.ToString(format)} ', '{r}', '{d}', '{s}', '{p}', '{l}', '{pas}', '{w}', '{wfh}', '{dt}')";
                SqlCommand sc = new SqlCommand(command, connection);
                sc.ExecuteNonQuery();
                return true;

            }
        }

        public bool RemoveUser(int id) // Видалення певного юзера.
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string command = $@"delete from Users where id = '{id}'";
                SqlCommand sc = new SqlCommand(command, connection);
                sc.ExecuteNonQuery();
                return true;
            }
        }

        public List<User> GetUsers() // Отримання всіх юзерів
        {
            string sqlExpression = "SELECT * FROM Users";
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object id = reader.GetValue(0);
                        object FirstName = reader.GetValue(1);
                        object LastName = reader.GetValue(2);
                        object DayOfBirthsday = reader.GetValue(3);
                        object Role = reader.GetValue(4);
                        object Department = reader.GetValue(5);
                        object Status = reader.GetValue(6);
                        object Position = reader.GetValue(7);
                        object Login = reader.GetValue(8);
                        object Password = reader.GetValue(9);
                        object Wage = reader.GetValue(10);
                        object WageForH = reader.GetValue(11);
                        object DateTime = reader.GetValue(12);
                        User user = new User((int)id, FirstName.ToString(), LastName.ToString(), DayOfBirthsday.ToString(), Role.ToString(), Department.ToString(), Status.ToString(), Position.ToString(), Login.ToString(), Password.ToString(), Convert.ToInt32(Wage), Convert.ToInt32(WageForH), DateTime.ToString());
                        users.Add(user);
                    }
                }
                reader.Close();

            }
            return users;
        }

        public List<Task> GetTasks() // Отримання всіх завдань.
        {
            string sqlExpression = "SELECT * FROM Tasks";
            List<Task> users = new List<Task>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object User_Id = reader.GetValue(1);
                        object Caption = reader.GetValue(2);
                        object Comment = reader.GetValue(3);
                        object Status = reader.GetValue(4);
                        Task user = new Task((int)id, (int)User_Id, Caption.ToString(), Comment.ToString(), Status.ToString());
                        users.Add(user);
                    }
                }
                reader.Close();

            }
            return users;
        }

        public User GetUser(int Id) // Отримання конкретного юзера.
        {
            string sqlExpression = $"SELECT * FROM Users where id = {Id}";
            User user = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {

                    object id = reader.GetValue(0);
                    object FirstName = reader.GetValue(1);
                    object LastName = reader.GetValue(2);
                    object DayOfBirthsday = reader.GetValue(3);
                    object Role = reader.GetValue(4);
                    object Department = reader.GetValue(5);
                    object Status = reader.GetValue(6);
                    object Position = reader.GetValue(7);
                    object Login = reader.GetValue(8);
                    object Password = reader.GetValue(9);
                    object Wage = reader.GetValue(10);
                    object WageForH = reader.GetValue(11);
                    object DateTime = reader.GetValue(12);
                    user = new User((int)id, FirstName.ToString(), LastName.ToString(), DayOfBirthsday.ToString(), Role.ToString(), Department.ToString(), Status.ToString(), Position.ToString(), Login.ToString(), Password.ToString(), Convert.ToInt32(Wage), Convert.ToInt32(WageForH), DateTime.ToString());


                }
                reader.Close();
                return user;

            }
            return user;
        }

        public User GetUser(string Id) // Отримання конкретного юзера.
        {
            string sqlExpression = $"SELECT * FROM Users where FirstName = '{Id}'";
            User user = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {

                    object id = reader.GetValue(0);
                    object FirstName = reader.GetValue(1);
                    object LastName = reader.GetValue(2);
                    object DayOfBirthsday = reader.GetValue(3);
                    object Role = reader.GetValue(4);
                    object Department = reader.GetValue(5);
                    object Status = reader.GetValue(6);
                    object Position = reader.GetValue(7);
                    object Login = reader.GetValue(8);
                    object Password = reader.GetValue(9);
                    object Wage = reader.GetValue(10);
                    object WageForH = reader.GetValue(11);
                    object DateTime = reader.GetValue(12);
                    user = new User((int)id, FirstName.ToString(), LastName.ToString(), DayOfBirthsday.ToString(), Role.ToString(), Department.ToString(), Status.ToString(), Position.ToString(), Login.ToString(), Password.ToString(), Convert.ToInt32(Wage), Convert.ToInt32(WageForH), DateTime.ToString());


                }
                reader.Close();
                return user;

            }
            return user;
        }

        public void update(Task task) // Оновлення конкретного завдання в базі данних.
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string command = @$"UPDATE Tasks SET id = {task.Id}, User_Id = {task.User_Id}, Caption = '{task.Caption}', Comment = {task.Comment} ', Status = '{task.Status}' where id = {task.Id}";
                SqlCommand sc = new SqlCommand(command, connection);
                sc.ExecuteNonQuery();
            }



        }
        public void update(User user) // Оновлення конкретного юзера в базі данних.
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string command = @$"UPDATE table_name SET id = {user.id}, FirstName = '{user.FirstName}', LastName'{user.LastName}', DayOfBirthsday = '{user.DayOfBirthsday} ', Role = '{user.Role}', Department = '{user.Department}', Status = '{user.Status}', Position = '{user.Position}', Login = '{user.Login}', Password = '{user.Password}', Wage = '{user.Wage}', WageForH = '{user.WageForH}', DateTime = '{user.DateTime}' WHERE id = {user.id}";
                SqlCommand sc = new SqlCommand(command, connection);
                sc.ExecuteNonQuery();
            }
        }



        public User Info_Of_User()
        {
            string sqlExpression = $"SELECT * FROM Users";
            User employee = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader dataReader = command.ExecuteReader();

                //if()
            }
            return employee;
        }
    }
}
