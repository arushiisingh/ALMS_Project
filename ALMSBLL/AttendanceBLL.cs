using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALMSDAL;
using ALMSEntity;
using System.Text.RegularExpressions;
using System.Data;

namespace ALMSBLL
{
    public class AttendanceBLL
    {
        AttendanceDAL attendanceDAL = new ALMSDAL.AttendanceDAL();

        public bool ValidateAttendanceBLL(AttendanceEntity attendanceEntity)
        {
            bool isAdded = false;
            try
            {
                if (ValidateAttendance(attendanceEntity))
                {
                    isAdded = attendanceDAL.AddAttendanceDAL(attendanceEntity);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return isAdded;
        }
        public bool ValidateAttendance(AttendanceEntity attendanceEntity)
        {
            bool ValidAttendance = true;
            Regex regex = new Regex("^[0-2][0-9]:[0-6][0-9]:[0-6][0-9]$");
            if (!(regex.IsMatch(attendanceEntity.InTime)))
            {
                Console.WriteLine("Time can be in HH:MM:SS Format only.");
                ValidAttendance = false;
            }
            return ValidAttendance;
        }

        public bool UpdateAttendanceBLL(AttendanceEntity attendanceEntity)
        {
            bool isUpdated = false;
            try
            {
                if (ValidateAttendance(attendanceEntity))
                {
                    isUpdated = attendanceDAL.UpdateAttendanceDAL(attendanceEntity);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return isUpdated;
        }

        public AttendanceEntity SearchAttendanceBLL(int AttendanceID, int userId)
        {
            AttendanceEntity serchedAttendanceEntity = null;
            try
            {
                serchedAttendanceEntity = attendanceDAL.SearchAttendaceDAL(AttendanceID, userId);
                if (serchedAttendanceEntity == null) {
                    Console.WriteLine("SomeError");
                };

            }
            catch (Exception e) { throw e; }
            return serchedAttendanceEntity;

        }

        public bool DeleteAttendanceBLL(int AttendanceID, int userId)
        {
            bool isDeleted = false;
            isDeleted = attendanceDAL.DeleteAttendanceDAL(AttendanceID, userId);
            return isDeleted;
        }



        public DataTable LoadGridBLL(int userId)
        {
            DataTable dataTable = attendanceDAL.LoadGridDAL(userId);
            return dataTable;
        }

    }
}
