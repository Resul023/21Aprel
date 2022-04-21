using ClassLibrary.Metod;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ClassLibrary.Data
{
    public class StadiumData
    {
        public void Add(Stadium stadiums) 
        {
            
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = $"INSERT INTO Stadiums (Name,HourlyPrice,Capacity) VALUES ('{stadiums.Name}',{stadiums.HourlyPrice},{stadiums.Capacity})";
                SqlCommand com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
            }
        
        }
        public void DeleteById(int id)
        {

            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = $"DELETE FROM Stadiums WHERE Id = @id";
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("@id",id);
                com.ExecuteNonQuery();
            }

        }

        public List<Stadium> ShowData() 
        {
            List<Stadium> stadiums = new List<Stadium>();
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString)) 
            {
                con.Open();
                string query = "SELECT * FROM Stadiums";
                SqlCommand com = new SqlCommand(query, con);
                using (var reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    { 
                        Stadium stadiumForRead = new Stadium
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            HourlyPrice = reader.GetDecimal(2),
                            Capacity = reader.GetInt32(3)
                        };
                        stadiums.Add(stadiumForRead);
                    }
                }
            
            }return stadiums;


        }
        public List<Stadium> ShowDataById(int id)
        {
            List<Stadium> stadiums = new List<Stadium>();
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = "SELECT * FROM Stadiums WHERE Id = @id";
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("@id", id);
                using (var reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Stadium stadiumForRead = new Stadium
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            HourlyPrice = reader.GetDecimal(2),
                            Capacity = reader.GetInt32(3)
                        };
                        stadiums.Add(stadiumForRead);
                    }
                }

            }
            return stadiums;
        }
    }
}
