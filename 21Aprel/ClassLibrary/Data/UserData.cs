using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ClassLibrary.Metod;
namespace ClassLibrary.Data
{
    public class UserData
    {
        public void Add(User user)
        {

            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = $"INSERT INTO Users (FullName,Email) VALUES ('{user.FullName}','{user.Email}')";
                SqlCommand com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
            }

        }
        public List<User> ShowData()
        {
            List<User> stadiums = new List<User>();
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = "SELECT * FROM Users";
                SqlCommand com = new SqlCommand(query, con);
                using (var reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User stadiumForRead = new User
                        {
                            Id = reader.GetInt32(0),
                            FullName = reader.GetString(1),
                            Email = reader.GetString(2)
                        };
                        stadiums.Add(stadiumForRead);
                    }
                }

            }
            return stadiums;

        }
    }
}
