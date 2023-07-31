using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Project1.DAO
{
    class ClassStudentDAO
    {
        DBConnection db = new DBConnection();

        public bool insert(string st_id, string class_id)
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                //try
                //{
                    connection.Open();

                    string query = "INSERT INTO st_class(st_id,class_id) VALUES(@st_id,@class_id)";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@class_id", class_id);
                    command.Parameters.AddWithValue("@st_id", st_id);

                    command.ExecuteNonQuery();
                    return true;

                //}
                //catch (Exception ex)
                //{
                //    return false;
                //}
            }
        }

    }
}
