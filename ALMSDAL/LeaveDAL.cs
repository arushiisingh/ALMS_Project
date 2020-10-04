using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALMSEntity;
using ALMSExceptions;
namespace ALMSDAL
{
    public class LeaveDAL
    {
        LeaveEntity leaveEntity = new LeaveEntity();
        SqlConnection connection = new SqlConnection(DALStatic.connectionString);
        public string LeaveStatusDAL(int userID)
        {
            try
            {
                connection.Open();
                
              /*  string command = "SpGetAllEmployees";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                
                SqlDataReader reader = sqlCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dgEmployees.DataContext = dataTable;*/
            }
            catch
            {

            }
            return " ";
        }

        

        public bool LeaveRequestDAL(LeaveEntity leaveEntity)
        {
            try
            {
                connection.Open();


                string command = "SpRequestLeave";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@LeaveType",LeaveEntity.LeaveType);
                sqlCommand.Parameters.AddWithValue("@NoOfDays",LeaveEntity.NoOfDays);
                sqlCommand.Parameters.AddWithValue("@LeaveBalance",LeaveEntity.LeaveBalance );
                sqlCommand.Parameters.AddWithValue("@LeaveDateFrom",LeaveEntity.Leave_Date_From );
                sqlCommand.Parameters.AddWithValue("@LeaveDateTo",LeaveEntity.LeaveDateTo );
                sqlCommand.Parameters.AddWithValue("@Status",LeaveEntity.LeaveStatus);
                sqlCommand.Parameters.AddWithValue("@eId",LeaveEntity.EmployeeID);
                sqlCommand.Parameters.AddWithValue("@mId",LeaveEntity.ManagerID);
                
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

        public bool UpdateLeaveDAL(LeaveEntity leaveEntity)
        {
            try
            {
                connection.Open();


                string command = "SpModifyLeaves";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@LeaveRequestId", LeaveEntity.LeaveRequestID);
                sqlCommand.Parameters.AddWithValue("@LeaveType", LeaveEntity.LeaveType);
                sqlCommand.Parameters.AddWithValue("@NoOfDays", LeaveEntity.NoOfDays);
                sqlCommand.Parameters.AddWithValue("@LeaveBalance", LeaveEntity.LeaveBalance);
                sqlCommand.Parameters.AddWithValue("@LeaveDateFrom", LeaveEntity.Leave_Date_From);
                sqlCommand.Parameters.AddWithValue("@LeaveDateTo", LeaveEntity.LeaveDateTo);
                sqlCommand.Parameters.AddWithValue("@Status", LeaveEntity.LeaveStatus);
                sqlCommand.Parameters.AddWithValue("@eId",LeaveEntity.EmployeeID);
                sqlCommand.Parameters.AddWithValue("@mId", LeaveEntity.ManagerID);

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

        public DataTable LoadGridDAL(int EmployeeID)
        {

            DataTable dataTable = new DataTable();
            
            try
            {
                connection.Open();
                Console.WriteLine("leave history fun");
                string command = "spLeaveHistory";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //dgAttendance.DataContext = dataTable;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong." + exception.Message);
            }
            //Step5. Close the connection
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return dataTable;
        }

        public DataTable StatusOfAllLeavesDAL(int EmployeeID)
        {

            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                Console.WriteLine("leave status all fun");
                string command = "spStatusOfAllLeave";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@eId", EmployeeID);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //dgAttendance.DataContext = dataTable;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong." + exception.Message);
            }
            //Step5. Close the connection
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return dataTable;
        }

        public DataTable ListOfHolidaysDAL()
        {

            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                Console.WriteLine("list of holidays all fun");
                string command = "spListOfHolidays";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
               // sqlCommand.Parameters.AddWithValue("@eId", EmployeeID);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //dgAttendance.DataContext = dataTable;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong." + exception.Message);
            }
            //Step5. Close the connection
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return dataTable;
        }

        public DataTable LeaveCreditDAL()
        {

            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                Console.WriteLine("list of leave credit fun");
                string command = "spLeaveCredit";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                // sqlCommand.Parameters.AddWithValue("@eId", EmployeeID);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //dgAttendance.DataContext = dataTable;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong." + exception.Message);
            }
            //Step5. Close the connection
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return dataTable;
        }

        public bool getOneLeaveDetailsDAL(int LeaveId)
        {
            Console.WriteLine(LeaveId);
            try
            {
                connection.Open();
                Console.WriteLine("leave one details fun DAL" + LeaveId);
                string command = "spOneLeaveDetails";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@lID", LeaveId);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();

                //Console.WriteLine(reader.Read());
                if (reader.Read())
                {
                    Console.WriteLine("read");
                   LeaveEntity.LeaveRequestID = int.Parse(reader["Leave_Request_ID"].ToString());
                    LeaveEntity.LeaveType = reader["LeaveType"].ToString();
                    LeaveEntity.NoOfDays = int.Parse(reader["NO_Of_Days"].ToString());
                    LeaveEntity.LeaveBalance = int.Parse(reader["Leave_Balance"].ToString());
                    LeaveEntity.Leave_Date_From = DateTime.Parse(reader["Leave_Date_From"].ToString());
                    LeaveEntity.LeaveDateTo = DateTime.Parse(reader["Leave_Date_To"].ToString());
                    LeaveEntity.LeaveStatus = reader["Leave_Status"].ToString();
                    LeaveEntity.EmployeeID = int.Parse(reader["Employee_ID"].ToString());
                    LeaveEntity.ManagerID = int.Parse(reader["Manager_ID"].ToString());
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
            //Step5. Close the connection
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return false;
    }


        public bool DeleteLeaveDAL(int leaveId)
        {
            try
            {
                connection.Open();


                string command = "spDeleteLeaveRequest";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
               
                sqlCommand.Parameters.AddWithValue("@lId",leaveId);

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


        public DataTable RequestedLeavesDAL(int EmployeeID)
        {

            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                Console.WriteLine("requested leaves func");
                string command = "spListOfRequestedLeaves";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@eId", EmployeeID);
                sqlCommand.CommandType = CommandType.StoredProcedure;
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
        
        public DataTable ListOfAllLeavesForAproveRejectDAL(int EmployeeId)
         {

            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                Console.WriteLine("leave request aprove/reject DAL fun");
                string command = "spListOfAllLeavesForAproveReject";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@mId", EmployeeId);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //dgAttendance.DataContext = dataTable;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong." + exception.Message);
            }
            //Step5. Close the connection
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return dataTable;
        }

        public int getAcceptedLeaveCountDAL(int EmployeeId)
        {
            Console.WriteLine(EmployeeId);
            try
            {
                connection.Open();
                Console.WriteLine("leave count details fun DAL" + EmployeeId);
                string command = "spListOfAcceptedLeaveCount";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@eId", EmployeeId);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                int count = 0;
                //Console.WriteLine(reader.Read());
                if (reader.Read())
                {
                    Console.WriteLine("read");
                    //  Console.WriteLine(int.Parse(reader["count(Leave_Status)"].ToString()));
                    /* if (int.Parse(reader["count(Leave_Status)"].ToString()) > 0)
                     {*/
                    Console.WriteLine("exception is here??");
                        Console.WriteLine("count > 1");
                        count = int.Parse(reader["countLeave"].ToString());

                        return count;
                   /* }
                    else
                    {
                        return count;
                    }*/
                }
                else
                {
                    return count;
                }

            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong not able to count leaves." + exception.Message);
            }
            //Step5. Close the connection
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return 0;
        }

        public bool ApproveLeaveDAL(int leaveId)
        {
            try
            {
                connection.Open();


                string command = "spApproveLeaveRequest";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@lId", leaveId);
                
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

        public bool RejectLeaveDAL(int leaveId)
        {
            try
            {
                connection.Open();


                string command = "spRejectLeaveRequest";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@lId", leaveId);

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

        public DataTable ManagerSideLeaveHistoryDAL(int EmployeeId)
        {

            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                Console.WriteLine("leave request aprove/reject DAL fun");
                string command = "spMLeaveHistory";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@mId", EmployeeId);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //dgAttendance.DataContext = dataTable;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong." + exception.Message);
            }
            //Step5. Close the connection
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return dataTable;
        }

        public DataTable ManagerSideApprovedLeaveListDAL(int EmployeeId)
        {

            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                Console.WriteLine("leave request aprove/reject DAL fun");
                string command = "spMAcceptedLeaveDetails";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@mId", EmployeeId);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //dgAttendance.DataContext = dataTable;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong." + exception.Message);
            }
            //Step5. Close the connection
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return dataTable;
        }

        public DataTable ManagerSideRejectedLeaveListDAL(int EmployeeId)
        {

            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                Console.WriteLine("leave request aprove/reject DAL fun");
                string command = "spMRejectedLeaveDetails";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@mId", EmployeeId);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //dgAttendance.DataContext = dataTable;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong." + exception.Message);
            }
            //Step5. Close the connection
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return dataTable;
        }

        public DataTable LeaveSearchByMonthDAL(int month,int employeeId)
        {

            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                Console.WriteLine("leave request aprove/reject DAL fun");
                string command = "spLeaveSearchByMonth";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@month", month);
                sqlCommand.Parameters.AddWithValue("@mId", employeeId);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //dgAttendance.DataContext = dataTable;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong." + exception.Message);
            }
            //Step5. Close the connection
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return dataTable;
        }

        public DataTable LeaveSearchByYearDAL(int year, int employeeId)
        {

            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                Console.WriteLine("leave request aprove/reject DAL fun");
                string command = "spLeaveSearchByYear";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@Year", year);
                sqlCommand.Parameters.AddWithValue("@mId", employeeId);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //dgAttendance.DataContext = dataTable;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong." + exception.Message);
            }
            //Step5. Close the connection
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return dataTable;
        }

        public DataTable LeaveSearchByDateLimitDAL(int employeeId,DateTime startDate,DateTime endDate )
        {

            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                Console.WriteLine("leave sreach by date DAL fun");
                string command = "spLeaveSearchByDateLimit";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@startDate", startDate);
                sqlCommand.Parameters.AddWithValue("@endDate", endDate);
                sqlCommand.Parameters.AddWithValue("@mId", employeeId);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //dgAttendance.DataContext = dataTable;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong." + exception.Message);
            }
            //Step5. Close the connection
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return dataTable;
        }

        /////admin part leave details,.......
        ///

        public DataTable LoadGridPendingLeavesDAL()
        {

            DataTable dataTable = new DataTable();

            try
            {

                connection.Open();

                string command = @"spPendingLeavesDetailsDisplay";
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
/*
        public bool ckeckDateDAL(DateTime date)
        {
            try
            {
                connection.Open();


                string command = "spDeleteLeaveRequest";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@date", date);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
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
    }
*/
    }
}
