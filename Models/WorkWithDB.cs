using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BookForEveryDay.Models
{
    public class WorkWithDB
    {
        static string connectionString = @"Data Source=BookForEveryDayDB.mssql.somee.com;Initial Catalog=BookForEveryDayDB;User ID=Qwertytrewq123_SQLLogin_1;Password=gglxs93hdw;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public bool AddUser(string fn, string ln, string dob, string r, string d, string s, string p)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string command = $@"insert into Users values('{fn}', '{ln}', '{dob}', '{r}', '{d}', '{s}', '{p}')";
                SqlCommand sc = new SqlCommand(command, connection);
                sc.ExecuteNonQuery();
                return true;
                
            }
        }

        public bool RemoveUser(int id)
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

        public User GetUsers(int Id)
        {
            string sqlExpression = "SELECT * FROM Users";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                        object id = reader.GetValue(0);
                        object FirstName= reader.GetValue(1);
                        object LastName = reader.GetValue(2);
                        object DayOfBirthsday = reader.GetValue(3);
                        object Role = reader.GetValue(4);
                        object Department = reader.GetValue(5);
                        object Status = reader.GetValue(6);
                        object Position = reader.GetValue(7);
                    User user = new User((int)id, FirstName.ToString(), LastName.ToString(), DayOfBirthsday.ToString(), Role.ToString(), Department.ToString(), Status.ToString(), Position.ToString());
                }
                reader.Close();
                    return user;

            }
        }
    }
}
