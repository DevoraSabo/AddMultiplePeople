using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ListPplJsAddButton.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }

    }

    public class PersonManager
    {
        private string _connectionString;
        public PersonManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddPerson(Person p)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO Person 
                                VALUES(@FirstName, @LastName, @age)";
            cmd.Parameters.AddWithValue("@FirstName", p.FirstName);
            cmd.Parameters.AddWithValue("@LastName", p.LastName);
            cmd.Parameters.AddWithValue("@Age", p.Age);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        public IEnumerable<Person> GetPeople()
        {

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"select * from Person";
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Person> ppl = new List<Person>();
            while (reader.Read())
            {
                ppl.Add(new Person
                {
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }

            return ppl;
        }
    }
}