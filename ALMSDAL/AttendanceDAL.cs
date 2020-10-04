using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ALMSEntity;
using System.Data;
using System.Globalization;

namespace ALMSDAL
{
    public class AttendanceDAL
    {
        SqlConnection connection = new SqlConnection(DALStatic.connectionString);
        public bool AddAttendanceDAL(AttendanceEntity attendanceEntity)
        {
            bool isAttendanceAdded = false;
            try
            {
                int y = 1;
                int z = 1;

                connection.Open();
                string command = "spLeaveCheck";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                string x = attendanceEntity.AttendanceDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                sqlCommand.Parameters.AddWithValue("@ADate", x);
                sqlCommand.Parameters.AddWithValue("@eId", attendanceEntity.EmployeeID);
                SqlDataReader reader = sqlCommand.ExecuteReader();


                if (reader.Read())
                {
                    y = 0; 
                }
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                connection.Open();
                string command2 = "spAttendanceAlreadyAppliedCheck";
                SqlCommand sqlCommand2 = new SqlCommand(command2, connection);
                sqlCommand2.CommandType = CommandType.StoredProcedure;
                string date = attendanceEntity.AttendanceDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                sqlCommand2.Parameters.AddWithValue("@ADate", date);
                sqlCommand2.Parameters.AddWithValue("@eId", attendanceEntity.EmployeeID);
                SqlDataReader reader1 = sqlCommand2.ExecuteReader();

                if (reader1.Read())
                {
                    z = 0;
                }
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                if (y == 1 && z == 1)
                {
                    if (LoginEntity.ProjectID == attendanceEntity.ProjectID)
                    {
                        connection.Open();
                        string command1 = "spAddAttendance";
                        SqlCommand sqlCommand1 = new SqlCommand(command1, connection);
                        sqlCommand1.CommandType = CommandType.StoredProcedure;
                        sqlCommand1.Parameters.AddWithValue("@Attedance_Type", attendanceEntity.AttendanceType);
                        sqlCommand1.Parameters.AddWithValue("@Attedance_Date", attendanceEntity.AttendanceDate);
                        sqlCommand1.Parameters.AddWithValue("@In_Time", attendanceEntity.InTime);
                        sqlCommand1.Parameters.AddWithValue("@Out_Time", attendanceEntity.OutTime);
                        sqlCommand1.Parameters.AddWithValue("@Status_Of_Attendance", "Approved");
                        sqlCommand1.Parameters.AddWithValue("@Status_Update_Date", attendanceEntity.AttendanceDate);
                        sqlCommand1.Parameters.AddWithValue("@Status_Updated_By", LoginEntity.ManagerID);
                        sqlCommand1.Parameters.AddWithValue("@Employee_ID", attendanceEntity.EmployeeID);
                        sqlCommand1.Parameters.AddWithValue("@Manager_ID", LoginEntity.ManagerID);
                        sqlCommand1.Parameters.AddWithValue("@Project_ID", LoginEntity.ProjectID);
                        int RowsAffected = sqlCommand1.ExecuteNonQuery();
                        if (RowsAffected == 1)
                        {
                            Console.WriteLine("Attendance Added Successfully.");
                            isAttendanceAdded = true;
                        }
                        else
                        {
                            isAttendanceAdded = false;
                        }
                    }
                    else
                    {
                            connection.Open();
                            string command1 = "spAddAttendance";
                            SqlCommand sqlCommand1 = new SqlCommand(command1, connection);
                            sqlCommand1.CommandType = CommandType.StoredProcedure;
                            sqlCommand1.Parameters.AddWithValue("@Attedance_Type", attendanceEntity.AttendanceType);
                            sqlCommand1.Parameters.AddWithValue("@Attedance_Date", attendanceEntity.AttendanceDate);
                            sqlCommand1.Parameters.AddWithValue("@In_Time", attendanceEntity.InTime);
                            sqlCommand1.Parameters.AddWithValue("@Out_Time", attendanceEntity.OutTime);
                            sqlCommand1.Parameters.AddWithValue("@Employee_ID", attendanceEntity.EmployeeID);
                            sqlCommand1.Parameters.AddWithValue("@Manager_ID", LoginEntity.ManagerID);
                            sqlCommand1.Parameters.AddWithValue("@Project_ID", attendanceEntity.ProjectID);
                            int RowsAffected = sqlCommand1.ExecuteNonQuery();
                            if (RowsAffected == 1)
                            {
                                Console.WriteLine("Attendance Added Successfully.");
                                isAttendanceAdded = true;
                            }
                            else
                            {
                                isAttendanceAdded = false;
                            }
                    }
                }

                else if(y ==1 && z == 0)
                {
                    Console.WriteLine("Attendance is already applied");
                }
                else
                {
                    Console.WriteLine("Leave is applied already");
                    isAttendanceAdded = false;
                }

            }
            catch (Exception e)
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
            return isAttendanceAdded;
        }

        public bool UpdateAttendanceDAL(AttendanceEntity attendanceEntity)
        {
            bool isAttendanceUpdated = false;
            try
            {
                connection.Open();
                string command = "spModifyAttendance";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Attedance_Type", attendanceEntity.AttendanceType);
                sqlCommand.Parameters.AddWithValue("@Attedance_Date", attendanceEntity.AttendanceDate);
                sqlCommand.Parameters.AddWithValue("@In_Time", attendanceEntity.InTime);
                sqlCommand.Parameters.AddWithValue("@Out_Time", attendanceEntity.OutTime);
                sqlCommand.Parameters.AddWithValue("@aId", attendanceEntity.AttendanceID);
                sqlCommand.Parameters.AddWithValue("@Employee_ID", attendanceEntity.EmployeeID);
                int RowsAffected = sqlCommand.ExecuteNonQuery();
                if (RowsAffected == 1)
                {
                    Console.WriteLine("Attendance Added Successfully.");
                    isAttendanceUpdated = true;
                }
                else
                {
                    Console.WriteLine("Something went wrong.");
                    isAttendanceUpdated = false;
                }

            }
            catch (Exception e)
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
            return isAttendanceUpdated;
        }

        public AttendanceEntity SearchAttendaceDAL(int AttendanceID, int userId)
        {
            AttendanceEntity searchedAttendance = new AttendanceEntity ();

            try
            {
                connection.Open();
                //Step3. Create the command
                string command = "spSearchAttendance";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@aId", AttendanceID);
                sqlCommand.Parameters.AddWithValue("@eId", userId);
                //Step4. Run the command
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        searchedAttendance.EmployeeID = int.Parse(reader["Employee_ID"].ToString());
                        //string str = reader["Employee_ID"].ToString();
                        //searchedAttendance.EmployeeID = Convert.ToInt32(str);
                        string aType = reader["Attedance_Type"].ToString();
                        searchedAttendance.AttendanceType = aType;
                        searchedAttendance.AttendanceDate = (DateTime)reader["Attedance_Date"];
                        searchedAttendance.InTime = reader["In_Time"].ToString();
                        searchedAttendance.OutTime = reader["Out_Time"].ToString();

                    }
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
            catch(Exception ex)
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
            return searchedAttendance;
        }


        public bool DeleteAttendanceDAL(int AttendanceID, int userId)
        {
            bool isDeleted = false;
            try
            {
                connection.Open();
                //Step3. Create the command
                string command = "spDeleteAttendance";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@aId", AttendanceID);
                sqlCommand.Parameters.AddWithValue("@eId", userId);

                //Step4. Run the command
                int RowsAffected = sqlCommand.ExecuteNonQuery();
                if (RowsAffected == 1)
                {
                    isDeleted = true;

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
            return isDeleted;
        }



        public bool ApproveRejectAttendanceDAL(AttendanceEntity attendanceEntity)
        {
            bool isAttendanceUpdated = false;
            DateTime dateTime = DateTime.Now;
            try
            {
                connection.Open();
                string command = "spApproveRejectPendingAttendance";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@aId", attendanceEntity.AttendanceID);
                sqlCommand.Parameters.AddWithValue("@Status_Of_Attendance", attendanceEntity.StatusOfAttendance);
                sqlCommand.Parameters.AddWithValue("@Status_Update_Date", dateTime.Date);
                sqlCommand.Parameters.AddWithValue("@Status_Updated_By", LoginEntity.UserID);
                
                int RowsAffected = sqlCommand.ExecuteNonQuery();
                if (RowsAffected == 1)
                {
                    Console.WriteLine("Pending Attendance Updated Successfully.");
                    isAttendanceUpdated = true;
                }
                else
                {
                    Console.WriteLine("Pending Attendance Not Updated.");
                    isAttendanceUpdated = false;
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return isAttendanceUpdated;
        }

        public DataTable LoadGridDAL(int EmployeeID)
        {

            DataTable dataTable = new DataTable();
            //Step2. Open the connection.
            try
            {

                connection.Open();
                //Step3. Create the command
                string command = "spListAttendanceDetailsDisplay";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@eId", EmployeeID);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //Step4. Run the command
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


        public DataTable LoadGridARDAL(int EmployeeID)
        {

            DataTable dataTable = new DataTable();
            //Step2. Open the connection.
            try
            {
                connection.Open();
                //Step3. Create the command
                string command = "spListPendingAttendance";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@mId", EmployeeID);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //Step4. Run the command
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //dgAttendance.DataContext = dataTable;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong...." + exception.Message);
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




        public DataTable LoadGridPADAL(int ProjectID, int EmployeeID)
        {

            DataTable dataTable = new DataTable();
            //Step2. Open the connection.
            try
            {
                connection.Open();
                //Step3. Create the command
                string command = "spListProjectAttendance";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@pId", ProjectID);
                sqlCommand.Parameters.AddWithValue("@mId", EmployeeID);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //Step4. Run the command
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //dgAttendance.DataContext = dataTable;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong...." + exception.Message);
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


        public DataTable LoadGridPAMDAL(int ProjectID, int Month, int EmployeeID)
        {

            DataTable dataTable = new DataTable();
            //Step2. Open the connection.
            try
            {
                connection.Open();
                //Step3. Create the command
                string command = "spAttendanceSearchByMonth";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@pId", ProjectID);
                sqlCommand.Parameters.AddWithValue("@month", Month);
                sqlCommand.Parameters.AddWithValue("@mId", EmployeeID);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //Step4. Run the command
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //dgAttendance.DataContext = dataTable;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong...." + exception.Message);
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


        public DataTable LoadGridPADDAL(int ProjectID, DateTime Date, int EmployeeID)
        {

            DataTable dataTable = new DataTable();
            //Step2. Open the connection.
            try
            {
                connection.Open();
                //Step3. Create the command
                string command = "spAttendanceSearchByDay";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@pId", ProjectID);
                sqlCommand.Parameters.AddWithValue("@day", Date);
                sqlCommand.Parameters.AddWithValue("@mId", EmployeeID);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //Step4. Run the command
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //dgAttendance.DataContext = dataTable;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong...." + exception.Message);
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

        public DataTable LoadGridPABDDAL(int ProjectID, DateTime FromDate, DateTime ToDate, int EmployeeID)
        {

            DataTable dataTable = new DataTable();
            //Step2. Open the connection.
            try
            {
                connection.Open();
                //Step3. Create the command
                string command = "spAttendanceSearchBetweenDates";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@pId", ProjectID);
                sqlCommand.Parameters.AddWithValue("@startDate", FromDate);
                sqlCommand.Parameters.AddWithValue("@endDate", ToDate);
                sqlCommand.Parameters.AddWithValue("@mId", EmployeeID);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //Step4. Run the command
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //dgAttendance.DataContext = dataTable;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong...." + exception.Message);
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


        public DataTable LoadGridApprovedAttendanceDAL(int userID)
        {

            DataTable dataTable = new DataTable();
            //Step2. Open the connection.
            try
            {
                connection.Open();
                //Step3. Create the command
                string command = "spListApprovedAttendance";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@mId", userID);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //Step4. Run the command
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //dgAttendance.DataContext = dataTable;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong...." + exception.Message);
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




        public DataTable LoadGridRejectedAttendanceDAL(int userID)
        {

            DataTable dataTable = new DataTable();
            //Step2. Open the connection.
            try
            {
                connection.Open();
                //Step3. Create the command
                string command = "spListRejectedAttendance";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@mId", userID);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //Step4. Run the command
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //dgAttendance.DataContext = dataTable;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong...." + exception.Message);
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


    }
}
