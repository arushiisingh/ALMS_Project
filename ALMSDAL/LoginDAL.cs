using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALMSEntity;

namespace ALMSDAL
{
    public class LoginDAL
    {
        SqlConnection connection = new SqlConnection(DALStatic.connectionString);
        EmployeeEntity employeeEntity = new EmployeeEntity();

        public bool ValidateLoginDAL(int userId, string password, string userType)
        {
            try
            {
                if (userType == "Employee")
                {
                    connection.Open();
                    Console.WriteLine("User type is employee verified");

                    string command = "Select Employee_ID, Employee_Password, Manager_ID, Project_ID from Employee where Employee_ID = @eId";

                    SqlCommand sqlCommand = new SqlCommand(command, connection);
                    sqlCommand.Parameters.AddWithValue("@eId", userId);

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        Console.WriteLine("In Reader");
                        if (reader["Employee_ID"].ToString().Equals(userId.ToString()))
                        {
                            if (reader["Employee_Password"].ToString().Equals(password.ToString()))
                            {
                                LoginEntity.ManagerID = reader["Manager_ID"].ToString();
                                LoginEntity.ProjectID = int.Parse(reader["Project_ID"].ToString());
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        { return false; }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (userType == "Admin")
                {
                    Console.WriteLine("User type is Admin verified");
                    connection.Open();
                    Console.WriteLine("admin connection is open");
                    string command = "Select Admin_ID, Admin_Password from Admin where Admin_ID = @aId";
                    SqlCommand sqlCommand = new SqlCommand(command, connection);
                    sqlCommand.Parameters.AddWithValue("@aId", userId);
                    Console.WriteLine("sql command success");
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        Console.WriteLine("In Reader");
                        if (reader["Admin_ID"].ToString().Equals(userId.ToString()))
                        {
                            if (reader["Admin_Password"].ToString().Equals(password.ToString()))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        { return false; }
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
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

        public bool IsManagerDAL(int userId)
        {
            try
            {
                connection.Open();
                string command = "Select Manager_ID from Employee where Manager_ID = @mId";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@mId", userId);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Manager_ID"].ToString().Equals(userId.ToString()))
                    {
                        Console.WriteLine("is manager");
                        return true;
                    }
                    else
                    { return false; }
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
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

        public bool AddEmployeeEntityDAL(int employeeID)
        {
            try
            {
                connection.Open();

                Console.WriteLine("Fetch Employee");
                string command = "spViewEmployeeDetail";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@eId", employeeID);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine("Fetch Success");
                    EmployeeEntity.EmployeeName = reader["Employee_Name"].ToString();
                    EmployeeEntity.EmployeeEmail = reader["Employee_Email"].ToString();
                    EmployeeEntity.EmployeePhoneNumber = Convert.ToInt64(reader["Employee_Phone_Number"].ToString());
                    EmployeeEntity.EmployeeRole = reader["Employee_Role"].ToString();
                    EmployeeEntity.EmployeeStatus = reader["Employee_Status"].ToString();
                    EmployeeEntity.EmployeePassword = reader["Employee_Password"].ToString();
                    string mid = reader["Manager_ID"].ToString();
                    Console.WriteLine("Manager Id",mid, "not to toString", reader["Manager_ID"]);
                    if (reader["Manager_ID"].ToString() != "")
                    {
                    Console.WriteLine("Manager 3b Not NULL");
                        EmployeeEntity.ManagerID = int.Parse(reader["Manager_ID"].ToString());
                    }
                    else
                    {
                        EmployeeEntity.ManagerID = 0;
                    }

                    if (reader["Project_Id"].ToString() != null)
                    {
                        EmployeeEntity.ProjectID = Convert.ToInt32(reader["Project_Id"].ToString());
                    }
                    else
                    {
                        EmployeeEntity.ProjectID = 0;
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("Fetch Failed");
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


        public bool AddAdminEntityDAL(int userID)
        {
            try
            {
                connection.Open();

                Console.WriteLine("Fetch admin details");
                string command = "spViewAdminDetailsById";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@aId", userID);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine("Fetch Success");
                   
                    AdminEntity.AdminName = reader["Admin_Name"].ToString();
                     return true;
                }
                else
                {
                    Console.WriteLine("Fetch Failed");
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
    }
}

