using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ALMSEntity;
using System.Data;

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
                connection.Open();
                string command = "spAddAttendance";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Attedance_Type", attendanceEntity.AttendanceType);
                sqlCommand.Parameters.AddWithValue("@Attedance_Date", attendanceEntity.AttendanceDate);
                sqlCommand.Parameters.AddWithValue("@In_Time", attendanceEntity.InTime);
                sqlCommand.Parameters.AddWithValue("@Out_Time", attendanceEntity.OutTime);
                sqlCommand.Parameters.AddWithValue("@Employee_ID", attendanceEntity.EmployeeID);
                sqlCommand.Parameters.AddWithValue("@Manager_ID", LoginEntity.ManagerID);
                int RowsAffected = sqlCommand.ExecuteNonQuery();
                if (RowsAffected == 1)
                {
                    Console.WriteLine("Attendance Added Successfully.");
                    isAttendanceAdded = true;
                }
                else
                {
                    Console.WriteLine("Something went wrong.");
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
    }
}
