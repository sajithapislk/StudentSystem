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

        public string Login(string UserName, string Password)
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                try
                {
                    // Open the connection to the database
                    connection.Open();

                    // Define the SQL query to execute
                    string query = "SELECT * FROM admins WHERE username = '" + UserName + "' AND password = '" + Password + "';";

                    // Create a new SqlCommand object

                    //  The using keyword is used in C# to define a block of code within which a SqlConnection object is created and then automatically disposed of when the block is exited. The purpose of the using keyword is to ensure that the resources used within the block are properly cleaned up, even if an exception is thrown.
                    //  In this specific case, SqlConnection is a managed resource that needs to be properly closed and disposed of when it is no longer needed. By using the using keyword, you ensure that the SqlConnection object will be automatically closed and disposed of when the block is exited, even if an exception occurs. This helps to avoid resource leaks and to ensure that the system remains in a consistent state.

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and retrieve the results
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Check if there are any results
                            if (reader.HasRows)
                            {
                                // Login succeeded
                                return "successful";
                            }
                            else
                            {
                                // Login failed
                                return "failed";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // An error occurred while trying to connect to the database
                    return "An error occurred: " + ex.Message;
                }
            }

            //  The using keyword is used in C# to define a block of code within which a SqlConnection object is created and then automatically disposed of when the block is exited. The purpose of the using keyword is to ensure that the resources used within the block are properly cleaned up, even if an exception is thrown.

            //  In this specific case, SqlConnection is a managed resource that needs to be properly closed and disposed of when it is no longer needed. By using the using keyword, you ensure that the SqlConnection object will be automatically closed and disposed of when the block is exited, even if an exception occurs. This helps to avoid resource leaks and to ensure that the system remains in a consistent state.
        }
    }
}
