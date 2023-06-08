using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project1.DAO
{
    class AdminDAO
    {
        DBConnection db = new DBConnection();

        public string login(string UserName, string Password)
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                try
                {
                    connection.Open();
                    
                    string query = "SELECT * FROM admins WHERE username = '" + UserName + "' AND password = '" + Password + "';";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                return "successful";
                            }
                            else
                            {
                                return "password is wrong";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "An error occurred: " + ex.Message;
                }
            }
        }
    }
}
