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
            }
            return false;
        }
    }
}
