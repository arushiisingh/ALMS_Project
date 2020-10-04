using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMSEntity
{
    public class LeaveEntity
    {
        public static int LeaveRequestID { get; set; }
        public static string LeaveType { get; set; }
        public static int NoOfDays { get; set; }
        public static int LeaveBalance { get; set; }
        public static DateTime Leave_Date_From { get; set; }
        public static DateTime LeaveDateTo { get; set; }
        public static string LeaveStatus { get; set; }
        public static int EmployeeID { get; set; }
        public static int ManagerID { get; set; }
    }
}
