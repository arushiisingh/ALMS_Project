using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ManagerApproveRejectLeavePage.xaml
    /// </summary>
    /// 
    public partial class ManagerApproveRejectLeavePage : Window
    {
        LeaveBLL leaveBLL = new LeaveBLL();
       
        public ManagerApproveRejectLeavePage()
        {
            InitializeComponent();
            dgLeaveAproveReject.DataContext = leaveBLL.ListOfAllLeavesForAproveRejectBLL(EmployeeEntity.EmployeeID);

            this.Loaded += new RoutedEventHandler(MyWindow_Loaded);
        }

        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
           
            Console.WriteLine("window loaded");
           
            Console.WriteLine(dgLeaveAproveReject.DataContext);
            Console.WriteLine("data..................");

        }

        private void SelectIdFromGrid(object sender, SelectionChangedEventArgs e)
        {

            // txtLeaveId.Text = dgLeaveAproveReject.;
            try
            {
                if (dgLeaveAproveReject.Items.Count > 0)
                {
                    txtLeaveId.Text = ((DataRowView)dgLeaveAproveReject.SelectedItem).Row["Leave_Request_ID"].ToString();
                }
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void btnApproveLeave_Click(object sender, RoutedEventArgs e)
        {
            LeaveEntity.LeaveRequestID = int.Parse(txtLeaveId.Text);
            try
            {
                bool isApproved = leaveBLL.ApproveLeaveBLL(LeaveEntity.LeaveRequestID);
                // txtLeaveId.Text = " ";
                if (isApproved)
                {
                    MessageBox.Show("Leave request for Id :  approved successfully");

                    dgLeaveAproveReject.DataContext = leaveBLL.ListOfAllLeavesForAproveRejectBLL(EmployeeEntity.EmployeeID);

                }
                else
                {
                    MessageBox.Show("Something went wrong with leave id : ");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("error"+ex);
            }
            
        }

        private void btnRejectLeave_Click(object sender, RoutedEventArgs e)
        {
            int leaveid = int.Parse(txtLeaveId.Text);
            bool isrejected = leaveBLL.RejectLeaveBLL(leaveid);
            txtLeaveId.Text = "";
            if (isrejected)
            {
                MessageBox.Show("Leave request for Id : " + leaveid + " Rejected successfully");
               
               // dgLeaveAproveReject.DataContext = leaveBLL.ListOfAllLeavesForAproveRejectBLL(EmployeeEntity.EmployeeID);

            }
            else
            {
                MessageBox.Show("Something went wrong with leave id : " + leaveid);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            dgLeaveAproveReject.DataContext = leaveBLL.ListOfAllLeavesForAproveRejectBLL(EmployeeEntity.EmployeeID);

        }

        private void btnLeaveHistory_Click(object sender, RoutedEventArgs e)
        {
            dgLeaveAproveReject.DataContext = leaveBLL.ManagerSideLeaveHistoryBLL(EmployeeEntity.EmployeeID);

        }

        private void btnApprovedLeaves_Click(object sender, RoutedEventArgs e)
        {
            dgLeaveAproveReject.DataContext = leaveBLL.ManagerSideApprovedLeaveListBLL(EmployeeEntity.EmployeeID);
        }

        private void btnRejectedLeaves_Click(object sender, RoutedEventArgs e)
        {
            dgLeaveAproveReject.DataContext = leaveBLL.ManagerSideRejectedLeaveListBLL(EmployeeEntity.EmployeeID);
        }

        private void btnSearchMonth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int month = int.Parse(txtSearch.Text);
                dgLeaveAproveReject.DataContext = leaveBLL.LeaveSearchByMonthBLL(month, EmployeeEntity.EmployeeID);
            }
            catch(Exception exe)
            {
                Console.WriteLine(exe);
            }
            }

        private void btnSearchByYear_Click(object sender, RoutedEventArgs e)
        {
            int year = int.Parse(txtSearch.Text);
            dgLeaveAproveReject.DataContext = leaveBLL.LeaveSearchByYearBLL(year, EmployeeEntity.EmployeeID);

        }

        private void btnSearchByDateLimit_Click(object sender, RoutedEventArgs e)
        {
            DateTime startdate = DateTime.Parse(SearchDateFrom.Text).Date;
            DateTime enddate = DateTime.Parse(SearchDateTo.Text).Date;

            dgLeaveAproveReject.DataContext = leaveBLL.LeaveSearchByDateLimitBLL(EmployeeEntity.EmployeeID,startdate,enddate);

        }
    }
}
