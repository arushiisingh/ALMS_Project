using ALMSBLL;
using ALMSEntity;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ALMSPL
{
    /// <summary>
    /// Interaction logic for EmployeeLeaveDetailsPL.xaml
    /// </summary>
    public partial class EmployeeLeaveDetailsPL : Window
    {
        LeaveBLL leaveBLL = new LeaveBLL();

        LoginEntity loginEntity = new LoginEntity();
        public EmployeeLeaveDetailsPL()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            // DataGridForLeaves.DataContext = leaveBLL.LoadGridBLL(EmployeeEntity.EmployeeID);
            

                txtLeaveBalance.Text = checkBalance().ToString();
            
        }
        int defaultBalance = 2;
        public int checkBalance()
        {
            DateTime dt = DateTime.Now;
            int month = dt.Month;
            int balance = defaultBalance + (month * 2);
            int acceptedLeaves = leaveBLL.getAcceptedLeaveCountDAL(EmployeeEntity.EmployeeID);
            Console.WriteLine("accepted leave " + acceptedLeaves);
            Console.WriteLine("balance leave " + balance);
            if (balance > acceptedLeaves)
            {
                balance = balance - acceptedLeaves;
                return balance;
            }
            else
            {
                MessageBox.Show("balance is very low..... ");
                balance = balance - acceptedLeaves;
                return balance;
            }
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
           DataGridForLeaves.DataContext = leaveBLL.LoadGridBLL(EmployeeEntity.EmployeeID);
            EmployeeNameLabel.Content = EmployeeEntity.EmployeeName.ToString();
        }


        private void LeaveRequestButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeLeaveRequestPage employeeLeaveRequestPage = new EmployeeLeaveRequestPage();
            employeeLeaveRequestPage.Show();
            employeeLeaveRequestPage.txtLeaveId.Visibility = Visibility.Hidden;
            employeeLeaveRequestPage.lblLeaveId.Visibility = Visibility.Hidden;
            employeeLeaveRequestPage.LeaveUpdate.Visibility = Visibility.Hidden;
            employeeLeaveRequestPage.txtLeaveId_Search.Visibility = Visibility.Hidden;
            employeeLeaveRequestPage.Search_Leave.Visibility = Visibility.Hidden;
            employeeLeaveRequestPage.Delete_Leave.Visibility = Visibility.Hidden;
        }

        private void LeaveStatusButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("in leave status btn");
            Console.WriteLine(EmployeeEntity.EmployeeID);
            DataGridForLeaves.DataContext = leaveBLL.StatusOfAllLeavesBLL(EmployeeEntity.EmployeeID);
                
        }

        private void LeaveModifyButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeLeaveRequestPage employeeLeaveRequestPage = new EmployeeLeaveRequestPage();
            employeeLeaveRequestPage.Show();
            employeeLeaveRequestPage.Delete_Leave.Visibility = Visibility.Hidden;
            employeeLeaveRequestPage.LeaveRequestbtn.Visibility = Visibility.Hidden;
        }

        private void AproveRejectLeaveButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerApproveRejectLeavePage managerApproveRejectLeavePage = new ManagerApproveRejectLeavePage();
            managerApproveRejectLeavePage.Show(); 

            
        }

        private void ListOfHolidaysButton_Click(object sender, RoutedEventArgs e)
        {
            DataGridForLeaves.DataContext = leaveBLL.ListOfHolidaysBLL();
        }

        private void LeaveHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            DataGridForLeaves.DataContext = leaveBLL.LoadGridBLL(EmployeeEntity.EmployeeID);
        }

        private void LeaveCreditButton_Click(object sender, RoutedEventArgs e)
        {
            DataGridForLeaves.DataContext = leaveBLL.LeaveCreditBLL();
        }

        private void LeaveDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeLeaveRequestPage employeeLeaveRequestPage = new EmployeeLeaveRequestPage();
            employeeLeaveRequestPage.LeaveRequestbtn.Visibility = Visibility.Hidden;
            employeeLeaveRequestPage.LeaveUpdate.Visibility = Visibility.Hidden;
            employeeLeaveRequestPage.Show();

        }

        private void RequestedLeavesButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(EmployeeEntity.EmployeeID);
            DataGridForLeaves.DataContext = leaveBLL.RequestedLeavesBLL(EmployeeEntity.EmployeeID);
        }

        private void DataGridForLeaves_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtLeaveBalance_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
