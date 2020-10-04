using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ALMSBLL;
using ALMSEntity;
using ALMSExceptions;

namespace ALMSPL
{
    /// <summary>
    /// Interaction logic for AdminSideAddEmployeePL.xaml
    /// </summary>
    public partial class AdminSideAddEmployeePL : Window
    {
        EmployeeBLL EmployeeBLL = new EmployeeBLL();
        EmployeeEntity employeeEntity = new EmployeeEntity();
        public AdminSideAddEmployeePL()
        {
            InitializeComponent();
            dgEmployees.DataContext = EmployeeBLL.LoadGridBLL();
        }

        private void SaveDetails(object sender, RoutedEventArgs e)
        {

            try
            {
                string employeeName = txtName.Text;
                string employeeEmail = txtEmail.Text;
                string employeePhone = txtPhone.Text;
                string employeeRole = empRole.Text;
                string employeeStatus = txtStatus.Text;
                string employeePassword = txtPassword.Text;
                int managerId = Convert.ToInt32(txtMId.Text);
                int projectId = Convert.ToInt32(txtPId.Text);



                EmployeeEntity.EmployeeName = employeeName;
                EmployeeEntity.EmployeeEmail = employeeEmail;
                EmployeeEntity.EmployeePhoneNumber = Convert.ToInt64(employeePhone);
                EmployeeEntity.EmployeeRole = employeeRole;
                EmployeeEntity.EmployeeStatus = employeeStatus;
                EmployeeEntity.EmployeePassword = employeePassword;
                EmployeeEntity.ManagerID = managerId;
                EmployeeEntity.ProjectID = projectId;

                //Console.WriteLine(EmployeeEntity);
                bool requestStatus = EmployeeBLL.EmployeeAddBLL(employeeEntity);

                if (requestStatus == true)
                {

                    MessageBox.Show("Employee Added Successfully");
                    dgEmployees.DataContext = EmployeeBLL.LoadGridBLL();
                }
                else
                {
                    MessageBox.Show("Something is wrong..check your details again..");
                }
            }
            catch (ALMSException exception)
            {
                MessageBox.Show("Something Went Wrong." + exception.Message);
            }
        }

        private void UpdateEmployee(object sender, RoutedEventArgs e)
        {
            try
            {


                int EmpId;
                EmpId = Convert.ToInt32(txtId.Text);

                string employeeRole = empRole.Text;
                string employeeName = txtName.Text;
                string employeeEmail = txtEmail.Text;
                string employeePhone = txtPhone.Text;
                string employeeStatus = txtStatus.Text;
                string employeePassword = txtPassword.Text;
                int managerId = Convert.ToInt32(txtMId.Text);
                int projectId = Convert.ToInt32(txtPId.Text);

                EmployeeEntity.EmployeeID = EmpId;
                EmployeeEntity.EmployeeName = employeeName;
                EmployeeEntity.EmployeeEmail = employeeEmail;
                EmployeeEntity.EmployeePhoneNumber = Convert.ToInt64(employeePhone);
                EmployeeEntity.EmployeeRole = employeeRole;
                EmployeeEntity.EmployeeStatus = employeeStatus;
                EmployeeEntity.EmployeePassword = employeePassword;
                EmployeeEntity.ManagerID = managerId;
                EmployeeEntity.ProjectID = projectId;



                bool updateStatus = EmployeeBLL.UpdateEmployeeBLL(employeeEntity);
                if (updateStatus == true)
                {

                    MessageBox.Show("Employee Updated Successfully");
                    dgEmployees.DataContext = EmployeeBLL.LoadGridBLL();
                }
                else
                {
                    MessageBox.Show("Something is wrong..check your details again..");
                }


            }
            catch (ALMSException exception)
            {
                MessageBox.Show("Something Went Wrong." + exception.Message);
            }
        }

        private void DeleteEmployee(object sender, RoutedEventArgs e)
        {
            int EmpId;
            EmpId = Convert.ToInt32(txtId.Text);

            EmployeeEntity.EmployeeID = EmpId;

            bool deleteEmployee = EmployeeBLL.DeleteEmployeeBLL(employeeEntity);

            if (deleteEmployee == true)
            {

                MessageBox.Show("Employee Deleted Successfully");
                dgEmployees.DataContext = EmployeeBLL.LoadGridBLL();
            }
            else
            {
                MessageBox.Show("Something is wrong..check your details again..");
            }
        }

        private void SearchEmployee(object sender, RoutedEventArgs e)
        {
           // EmployeeEntity searchedEmployeeEntity = null;

            try
            {
                int EmployeeID = int.Parse(txtId.Text);

                employeeEntity = EmployeeBLL.SearchEmployeeBLL(EmployeeID);

                txtName.Text = EmployeeEntity.EmployeeName;
                txtEmail.Text = EmployeeEntity.EmployeeEmail;
                txtPhone.Text = EmployeeEntity.EmployeePhoneNumber.ToString();
                empRole.Text = EmployeeEntity.EmployeeRole;
                txtStatus.Text = EmployeeEntity.EmployeeStatus;
                txtPassword.Text = EmployeeEntity.EmployeePassword;
                txtMId.Text = EmployeeEntity.ManagerID.ToString();
                txtPId.Text = EmployeeEntity.ProjectID.ToString();
            }
            catch (ALMSException execption)
            {

                MessageBox.Show("Something Went Wrong." + execption.Message);
            }
        }
    }
}
