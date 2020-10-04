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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ALMSBLL;
using ALMSEntity;
using ALMSExceptions;

namespace ALMSPL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginBLL loginBLL = new LoginBLL();
        LoginEntity loginEntity = new LoginEntity();
        ALMSException ALMSexception = new ALMSException();
        EmployeeEntity employeeEntity = new EmployeeEntity();
        AdminEntity adminEntity = new AdminEntity();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtUserId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rbtnAdmin_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbtnEmployee_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Loginbtn_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("aaaaa");
            try
            {
                Console.WriteLine("validation start");
                string user = null;
                if ((bool)rbtnEmployee.IsChecked)
                {
                    user = "Employee";
                    Console.WriteLine("Is Employee");
                }
                else if ((bool)rbtnAdmin.IsChecked)
                {
                    user = "Admin";
                    Console.WriteLine("Is Admin");
                }

                int userId = Convert.ToInt32(txtUserId.Text);
                string password = txtPassword.Password.ToString();

                bool validateLogin = loginBLL.ValidateLoginBLL(userId, password, user);
                
                if (validateLogin)
                {
                    LoginEntity.UserID = userId;

                    loginEntity.UserPassword = password;


                    if (user == "Employee")
                    {
                        bool isManager = loginBLL.IsManagerBLL(userId);

                        bool addEmployeeDetails = AddEmployeeDetails(userId);
                            /*  // this is only for checking purpose that employee details added on class
                        if(addEmployeeDetails)
                        {
                            ///MessageBox.Show("Employee details added success");
                            Console.WriteLine("emp add details");
                            Console.WriteLine(EmployeeEntity.ProjectID);
                            Console.WriteLine(EmployeeEntity.EmployeeStatus);
                            Console.WriteLine(EmployeeEntity.EmployeeName);
                            Console.WriteLine(EmployeeEntity.EmployeeEmail);
                        }
                        else
                        {
                            MessageBox.Show("employee details not fatched");
                        }*/

                        if (isManager)
                        {
                            ManagerHomePage managerHomePage = new ManagerHomePage();
                            this.Close();
                            managerHomePage.Show();
                        }
                        else
                        {
                            EmployeeHomePage employeeHomePage = new EmployeeHomePage();
                            this.Close();
                            employeeHomePage.Show();
                        }
                    }
                    else if (user == "Admin")
                    {
                        bool addAdminDetails = AddAdminDetails(userId);
                        AdminHomePage adminHomePage = new AdminHomePage();
                        this.Close();
                        adminHomePage.Show();
                    }
                    else
                    {
                        MessageBox.Show("something went wrong");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter valid values...");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Something went wrong....please try again ");
            }
        }

        public bool AddEmployeeDetails(int UserId)
        {
            EmployeeEntity.EmployeeID = UserId;
            bool addEmployeeEntity =loginBLL.AddEmployeeEntityBLL(EmployeeEntity.EmployeeID);
            if (addEmployeeEntity)
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        public bool AddAdminDetails(int userId)
        {
            AdminEntity.AdminId = userId;
            bool addAdminEntity = loginBLL.AddAdminEntityBLL(userId);
            if (addAdminEntity)
            {
               // MessageBox.Show("Admin added succes");
                return true;
            }
            else
            {
                return true;
            }
        }
    }
}
