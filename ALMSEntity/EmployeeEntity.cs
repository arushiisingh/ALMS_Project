using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMSEntity
{
     public class EmployeeEntity
    {
        public static int EmployeeID { get; set; }
        public static string EmployeePassword { get; set; }
        public static string EmployeeName { get; set; }
        public static string EmployeeEmail { get; set; }
        public static long EmployeePhoneNumber { get; set; }
        public static string EmployeeRole { get; set; }
        public static string EmployeeStatus { get; set; }
        public static int ManagerID { get; set; }
        public static int ProjectID { get; set; }
    }
}
