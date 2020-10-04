using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALMSDAL;
namespace ALMSBLL
{
    public class AttendanceBLL
    {
        AttedanceDAL attendanceDAL = new AttedanceDAL();
        public DataTable LoadGridAttendanceBLL()
        {
            DataTable dataTable = attendanceDAL.LoadGridAttedanceDAL();
            return dataTable;
        }
    }
}
