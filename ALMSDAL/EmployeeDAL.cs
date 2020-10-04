using ALMSEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMSDAL
{
    public class EmployeeDAL
    {
       
            SqlConnection connection = new SqlConnection(DALStatic.connectionString);

            public bool AddEmployeeDAL(EmployeeEntity employeeEntity)
            {
                try
                {
                    connection.Open();


                    string command = "spAddEmployee";
                    SqlCommand sqlCommand = new SqlCommand(command, connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Employee_Name", EmployeeEntity.EmployeeName);
                    sqlCommand.Parameters.AddWithValue("@Employee_Email", EmployeeEntity.EmployeeEmail);
                    sqlCommand.Parameters.AddWithValue("@Employee_Phone_Number", EmployeeEntity.EmployeePhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Employee_Role", EmployeeEntity.EmployeeRole);
                    sqlCommand.Parameters.AddWithValue("@Employee_Status", EmployeeEntity.EmployeeStatus);
                    sqlCommand.Parameters.AddWithValue("@Employee_Password", EmployeeEntity.EmployeePassword);
                    sqlCommand.Parameters.AddWithValue("@mId", EmployeeEntity.ManagerID);
                    sqlCommand.Parameters.AddWithValue("@pId", EmployeeEntity.ProjectID);

                    int RowsAffected = sqlCommand.ExecuteNonQuery();
                    if (RowsAffected == 1)
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }

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
                return false;
            }

            public bool UpdateEmployeeDAL(EmployeeEntity employeeEntity)
            {
                try
                {
                    connection.Open();


                    string command = "spModifyEmployeeDetails";
                    SqlCommand sqlCommand = new SqlCommand(command, connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@eId", EmployeeEntity.EmployeeID);
                    sqlCommand.Parameters.AddWithValue("@Employee_Name", EmployeeEntity.EmployeeName);
                    sqlCommand.Parameters.AddWithValue("@Employee_Email", EmployeeEntity.EmployeeEmail);
                    sqlCommand.Parameters.AddWithValue("@Employee_Phone_Number", EmployeeEntity.EmployeePhoneNumber);
                    sqlCommand.Parameters.AddWithValue("Employee_Role", EmployeeEntity.EmployeeRole);
                    sqlCommand.Parameters.AddWithValue("@Employee_Status", EmployeeEntity.EmployeeStatus);
                    sqlCommand.Parameters.AddWithValue("@Employee_Password", EmployeeEntity.EmployeePassword);
                    sqlCommand.Parameters.AddWithValue("@Manager_ID", EmployeeEntity.ManagerID);
                    sqlCommand.Parameters.AddWithValue("@Project_ID", EmployeeEntity.ProjectID);

                    int RowsAffected = sqlCommand.ExecuteNonQuery();
                    if (RowsAffected == 1)
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }

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
                return false;
            }

            public bool DeleteEmployeeDAL(EmployeeEntity employeeEntity)
            {
                try
                {
                    connection.Open();


                    string command = "spDeleteEmployee";
                    SqlCommand sqlCommand = new SqlCommand(command, connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@eId", EmployeeEntity.EmployeeID);
                    int RowsAffected = sqlCommand.ExecuteNonQuery();
                    if (RowsAffected == 1)
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }
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
                return false;
            }

            public EmployeeEntity SearchEmployeeDAL(int EmployeeID)
            {
               EmployeeEntity searchedEmployee = new EmployeeEntity();

                try
                {
                    connection.Open();
                    //Step3. Create the command
                    string command = "spSearchEmployee";
                    SqlCommand sqlCommand = new SqlCommand(command, connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@eId", EmployeeID);
                    //Step4. Run the command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {


                        string ename = reader["Employee_Name"].ToString();
                        EmployeeEntity.EmployeeName = ename;

                        string email = reader["Employee_Email"].ToString();
                        EmployeeEntity.EmployeeEmail = email;

                        string ephone = reader["Employee_Phone_Number"].ToString();
                        EmployeeEntity.EmployeePhoneNumber =Convert.ToInt64(ephone);

                        string erole = reader["Employee_Role"].ToString();
                        EmployeeEntity.EmployeeRole = erole;

                        string estatus = reader["Employee_Status"].ToString();
                        EmployeeEntity.EmployeeStatus = estatus;

                        string epass = reader["Employee_Password"].ToString();
                        EmployeeEntity.EmployeePassword = epass;

                        int mid = int.Parse(reader["Manager_Id"].ToString());
                        EmployeeEntity.ManagerID = mid;

                        int pid = int.Parse(reader["Project_Id"].ToString());
                        EmployeeEntity.ProjectID = pid;
                    }
                    else
                    {
                        Console.WriteLine("Record is not present in the DataBase");
                    }
                }
                catch (SqlException exception)
                {

                    Console.WriteLine("Something Went Wrong." + exception.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //Step5. Close the connection
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {

                        connection.Close();
                    }
                }
                return searchedEmployee;
            }

            public DataTable LoadGridDAL()
            {

                DataTable dataTable = new DataTable();

                try
                {

                    connection.Open();

                    string command = "spGetAllEmployee";
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

            public DataTable LoadGridManagerDAL()
            {

                DataTable dataTable = new DataTable();

                try
                {

                    connection.Open();

                    string command = "spProjectManager";
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
