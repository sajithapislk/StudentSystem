using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Project1.DAO
{
    class ClassDAO
    {
        DBConnection db = new DBConnection();

        public bool insert(string name, string grade)
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection())) 
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO classes(name,grade) VALUES(@name,@grade)";

                    SqlCommand command = new SqlCommand(query, connection);
                    
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@grade", grade);

                    command.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool update(string id,string name, string grade)
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                try
                {
                    connection.Open();
                    
                    string query = "UPDATE classes SET name=@name,grade=@grade WHERE id=@id";


                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@grade", grade);

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
                    
                    string query = "SELECT * FROM classes WHERE id=@id";

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
                    
                    string query = "DELETE FROM classes WHERE id=@id";

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

                    string query = "SELECT * FROM classes";
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
                    
                    string query = "DELETE FROM classes";

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