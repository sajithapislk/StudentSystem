using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Project1.DAO
{
    class ClassTeacherDAO
    {
        DBConnection db = new DBConnection();

        public bool insert(string t_id, string class_id)
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                //try
                //{
                connection.Open();

                string query = "INSERT INTO t_class(t_id,c_id) VALUES(@t_id,@c_id)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@c_id", class_id);
                command.Parameters.AddWithValue("@t_id", t_id);

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
