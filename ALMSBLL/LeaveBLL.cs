using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALMSDAL;
using ALMSEntity;
using ALMSExceptions;
namespace ALMSBLL
{
    public class LeaveBLL
    {
        LeaveDAL leaveDAL = new LeaveDAL();
        public bool LeaveRequestBLL(LeaveEntity leaveEntity)
        {
            Console.WriteLine("in Leave BLL layer");
            bool leaveRequest = leaveDAL.LeaveRequestDAL(leaveEntity);
            return leaveRequest;
        }

        public bool UpdateLeaveBLL(LeaveEntity leaveEntity)
        {
            bool updateRequest = leaveDAL.UpdateLeaveDAL(leaveEntity);
            return updateRequest;
        }

        public DataTable LoadGridBLL(int EmployeeID)
        {
            DataTable dataTable = leaveDAL.LoadGridDAL(EmployeeID);

            return dataTable;
        }

        public DataTable StatusOfAllLeavesBLL(int EmployeeID)
        {
            DataTable dataTable = leaveDAL.StatusOfAllLeavesDAL(EmployeeID);

            return dataTable;
        }

        public DataTable ListOfHolidaysBLL()
        {
            DataTable dataTable = leaveDAL.ListOfHolidaysDAL();

            return dataTable;
        }

        public DataTable LeaveCreditBLL()
        {
            DataTable dataTable = leaveDAL.LeaveCreditDAL();

            return dataTable;
        }

        public bool getOneLeaveDetailsBLL(int LeaveId)
        {
            Console.WriteLine("leave id " + LeaveId);
            Console.WriteLine("bll leave detail one");
            bool getLeaveDetails = leaveDAL.getOneLeaveDetailsDAL(LeaveId);
            Console.WriteLine(getLeaveDetails);
            return getLeaveDetails;

        }

        public bool DeleteLeaveBLL(int leaveId)
        {
            if (leaveId !=0)
            {
                bool Deleteleave = leaveDAL.DeleteLeaveDAL(leaveId);
                if(Deleteleave)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public DataTable RequestedLeavesBLL(int EmployeeID)
        {
            DataTable dataTable = leaveDAL.RequestedLeavesDAL(EmployeeID);

            return dataTable;
        }

        public DataTable ListOfAllLeavesForAproveRejectBLL(int EmployeeId)
        {

            DataTable dataTable = leaveDAL.ListOfAllLeavesForAproveRejectDAL(EmployeeId);

            return dataTable;
        }

        public int getAcceptedLeaveCountDAL(int EmployeeId)
        {
            try
            {
                int count = leaveDAL.getAcceptedLeaveCountDAL(EmployeeId);
                return count;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }

        public bool ApproveLeaveBLL(int leaveId)
        {
            bool isApproved = leaveDAL.ApproveLeaveDAL(leaveId);
            if(isApproved)
            {
                return true;
            }
            else
            {
                Console.WriteLine("something went wrong on approving request");
                return false;
            }
        }

        public bool RejectLeaveBLL(int leaveId)
        {
            bool isRejected = leaveDAL.RejectLeaveDAL(leaveId);
            if (isRejected)
            {
                return true;
            }
            else
            {
                Console.WriteLine("something went wrong on Rejecting request");
                return false;
            }
        }

        public DataTable ManagerSideLeaveHistoryBLL(int EmployeeId)
        {
            DataTable dataTable = leaveDAL.ManagerSideLeaveHistoryDAL(EmployeeId);

            return dataTable;
        }

        public DataTable ManagerSideApprovedLeaveListBLL(int EmployeeId)
        {
            DataTable dataTable = leaveDAL.ManagerSideApprovedLeaveListDAL(EmployeeId);

            return dataTable;
        }

        public DataTable ManagerSideRejectedLeaveListBLL(int EmployeeId)
        {
            DataTable dataTable = leaveDAL.ManagerSideRejectedLeaveListDAL(EmployeeId);

            return dataTable;
        }

        public DataTable LeaveSearchByMonthBLL(int month, int employeeId)
        {
            DataTable dataTable = leaveDAL.LeaveSearchByMonthDAL(month,employeeId);

            return dataTable;
        }

        public DataTable LeaveSearchByYearBLL(int year, int employeeId)
        {
            DataTable dataTable = leaveDAL.LeaveSearchByYearDAL(year, employeeId);

            return dataTable;
        }

        public DataTable LeaveSearchByDateLimitBLL(int employeeId, DateTime startDate, DateTime endDate)
        {
            DataTable dataTable = leaveDAL.LeaveSearchByDateLimitDAL(employeeId,startDate,endDate);

            return dataTable;
        }


        /////Admin part details leaves
        ///

        public DataTable LoadGridPendingLeavesBLL()
        {
            DataTable dataTable = leaveDAL.LoadGridPendingLeavesDAL();
            return dataTable;
        }

       /* public bool ckeckDateBLL(DateTime date)
        {
            bool checkdate = leaveDAL.ckeckDateDAL(date);
            return checkdate;
        }*/
    }
       
}
