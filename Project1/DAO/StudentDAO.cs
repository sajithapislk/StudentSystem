using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Project1.DAO
{
    class StudentDAO
    {
        DBConnection db = new DBConnection();

        public bool insert(string firstName, string lsatName, string dob, string gender, string address, string tp)
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO students(first_name,last_name,date_of_birth,gender,address,home_tp) VALUES(@firstName,@lsatName,@dob,@gender,@address,@tp)";

                    SqlCommand command = new SqlCommand(query, connection);
                    
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lsatName", lsatName);
                    command.Parameters.AddWithValue("@dob", dob);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@tp", tp);

                    command.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool update(string id, string firstName, string lsatName, string dob, string gender, string address, string tp)
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                try
                {
                    connection.Open();
                    
                    string query = "UPDATE students SET first_name=@firstName,last_name=@lsatName,date_of_birth=@dob,gender=@gender,address=@address,home_tp=@tp WHERE id=@id";


                    SqlCommand command = new SqlCommand(query, connection);
                    
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lsatName", lsatName);
                    command.Parameters.AddWithValue("@dob", dob);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@tp", tp);

                    command.ExecuteNonQuery();


                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public SqlDataReader studentInfo(string id)
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                try
                {
                    connection.Open();
                    
                    string query = "SELECT * FROM students WHERE id=@id";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    return reader;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public bool deleteStudent(string id)
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                try
                {
                    connection.Open();
                    
                    string query = "DELETE FROM students WHERE id=@id";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public DataTable allStudent()
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM students";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                }
                    catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public bool deleteAll(string id)
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                try
                {
                    connection.Open();
                    
                    string query = "DELETE FROM students";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}