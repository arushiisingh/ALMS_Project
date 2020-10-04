using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMSDAL
{
    public class AttedanceDAL
    {

        SqlConnection connection = new SqlConnection(DALStatic.connectionString);
        public DataTable LoadGridAttedanceDAL()
        {

            DataTable dataTable = new DataTable();

            try
            {

                connection.Open();

                string command = @"spPendingAttendanceDetailsDisplay";
                SqlCommand sqlCommand = new SqlCommand(command, connection);



                SqlDataReader reader = sqlCommand.ExecuteReader();

                dataTable.Load(reader);


            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong." + exception.Message);
            }

            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return dataTable;
        }
    }
}
