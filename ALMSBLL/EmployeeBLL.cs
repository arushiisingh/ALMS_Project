using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ALMSDAL;
using ALMSEntity;
using ALMSExceptions;

namespace ALMSBLL
{
    public class EmployeeBLL
    {
        EmployeeDAL employeeDAL = new EmployeeDAL();
        public bool EmployeeAddBLL(EmployeeEntity employeeEntity)
        {

            bool isAdded = false;
            try
            {

                if (ValidateEmployee(employeeEntity))
                {
                    isAdded = employeeDAL.AddEmployeeDAL(employeeEntity);
                }
            }
            catch (ALMSException e)
            {
                throw e;
            }
            return isAdded;
        }

        public bool UpdateEmployeeBLL(EmployeeEntity employeeEntity)
        {
            bool updateRequest = employeeDAL.UpdateEmployeeDAL(employeeEntity);
            return updateRequest;
        }

        public EmployeeEntity SearchEmployeeBLL(int EmployeeID)
        {
            EmployeeEntity serchedEmployeeEntity = null;
            try
            {
                serchedEmployeeEntity = employeeDAL.SearchEmployeeDAL(EmployeeID);
                if (serchedEmployeeEntity == null)
                {
                    Console.WriteLine("SomeError");
                };

            }
            catch (ALMSException e) { throw e; }
            return serchedEmployeeEntity;

        }

        public DataTable LoadGridBLL()
        {
            DataTable dataTable = employeeDAL.LoadGridDAL();
            return dataTable;
        }
        public DataTable LoadGridManagerBLL()
        {
            DataTable dataTable = employeeDAL.LoadGridManagerDAL();
            return dataTable;

        }

        public bool DeleteEmployeeBLL(EmployeeEntity employeeEntity)
        {
            bool IsDeleted = false;
            if (employeeDAL.DeleteEmployeeDAL(employeeEntity))
            {
                IsDeleted = true;
            }
            return IsDeleted;
        }

        private bool ValidateEmployee(EmployeeEntity employeeEntity)
        {
            bool ValidEmployee = true;
            StringBuilder message = new StringBuilder();
            if (EmployeeEntity.ManagerID <= 1000 || EmployeeEntity.ManagerID > 9999)
            {
                message.Append(Environment.NewLine + "Invalid Manager Id");
                ValidEmployee = false;
            }
            if (EmployeeEntity.EmployeeName == null || EmployeeEntity.EmployeeName == string.Empty)
            {

                message.Append(Environment.NewLine + "Employee Name can not be blank");
                ValidEmployee = false;
            }


            //verification of phone number
            Regex regex = new Regex("^[6-9]{1}[0-9]{9}$");
            String mobile = EmployeeEntity.EmployeePhoneNumber.ToString();
            if (!regex.IsMatch(mobile))
            {
                message.Append(Environment.NewLine + "Mobile Number Should be in proper format!!");
                ValidEmployee = false;
            }
            //verification of email
            Regex regex1 = new Regex("^[A-Za-z0-9*.]{1,50}@(gmail|yahoo|outlook|).(com|org|in|us|au|uk|co.in)$");
            String email = EmployeeEntity.EmployeeEmail;
            if (!regex1.IsMatch(email))
            {
                message.Append(Environment.NewLine + "Email should follow standards!!");
                ValidEmployee = false;
            }

            if (ValidEmployee == false)
            {
                throw new ALMSException(message.ToString());
            }
            return ValidEmployee;
        }
    }
}
