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
    /// Interaction logic for EmployeeLeaveRequestPage.xaml
    /// </summary>
    public partial class EmployeeLeaveRequestPage : Window
    {
        LeaveEntity leaveEntity = new LeaveEntity();
        LeaveBLL leaveBLL = new LeaveBLL();
        LoginEntity loginEntity = new LoginEntity();
        public EmployeeLeaveRequestPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MyWindow_Loaded);
        }

        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //txtEmployeeId.Text = LoginEntity.UserID.ToString();
            txtEmployeeId.Text = EmployeeEntity.EmployeeID.ToString();
            // txtLeaveId.Text = "10";
            EmployeeLeaveDetailsPL employeeLeaveDetailsPL = new EmployeeLeaveDetailsPL();
            txtLeaveBalance.Text = employeeLeaveDetailsPL.checkBalance().ToString();
            txtManagerId.Text = EmployeeEntity.ManagerID.ToString();
            // txtNoOfDays.Text = NoOfDays().ToString();


            Console.WriteLine("window loaded");
        }


        private void LeaveRequestbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Console.WriteLine("in leave btn click");
                /* int leaveRequestId;
                 leaveRequestId = Convert.ToInt32(txtLeaveId.Text);*/

                string leaveType = txtLeaveType.Text;
                int noOfDays = Convert.ToInt32(txtNoOfDays.Text);
                int leaveBalance = Convert.ToInt32(txtLeaveBalance.Text);
                DateTime leaveDateFrom = LeaveDateFrom.SelectedDate.Value;
                //DateTime leaveDateFrom = new DateTime(2020, 09, 10);
                DateTime leaveDateTo = LeaveDateTo.SelectedDate.Value;
                string leaveStatus = "Pending";
                int employeeId = Convert.ToInt32(txtEmployeeId.Text);
                int managerId = Convert.ToInt32(txtManagerId.Text);
                // asign value to leave class
                // leaveEntity.LeaveRequestID = leaveRequestId;
                LeaveEntity.LeaveType = leaveType;
                LeaveEntity.NoOfDays = noOfDays;
                LeaveEntity.LeaveBalance = leaveBalance;
                LeaveEntity.Leave_Date_From = leaveDateFrom;
                LeaveEntity.LeaveDateTo = leaveDateTo;
                LeaveEntity.LeaveStatus = leaveStatus;
                LeaveEntity.EmployeeID = employeeId;
                LeaveEntity.ManagerID = EmployeeEntity.ManagerID;

                Console.WriteLine(leaveEntity);

                bool requestStatus = leaveBLL.LeaveRequestBLL(leaveEntity);

                if (requestStatus == true)
                {
                    this.Close();
                    MessageBox.Show("Leave Requested Successfully");
                }
                else
                {
                    MessageBox.Show("Something is wrong..check your details again..");
                }
                Console.WriteLine(leaveDateFrom);

            }
            catch (Exception exception)
            {
                Console.WriteLine("Something Went Wrong." + exception.Message);
            }
        }

        private void UpdateLeavebtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Console.WriteLine("in leave update btn click");
                int leaveRequestId;
                leaveRequestId = Convert.ToInt32(txtLeaveId.Text);
                string leaveType = txtLeaveType.Text;
                int noOfDays = Convert.ToInt32(txtNoOfDays.Text);
                int leaveBalance = Convert.ToInt32(txtLeaveBalance.Text);
                DateTime leaveDateFrom = LeaveDateFrom.SelectedDate.Value;
                DateTime leaveDateTo = LeaveDateTo.SelectedDate.Value;
                string leaveStatus = "Pending";
                int employeeId = Convert.ToInt32(txtEmployeeId.Text);
                int managerId = Convert.ToInt32(txtManagerId.Text);

                // assign value to leaveEntity class
                LeaveEntity.LeaveRequestID = leaveRequestId;
                LeaveEntity.LeaveType = leaveType;
                LeaveEntity.NoOfDays = noOfDays;
                LeaveEntity.LeaveBalance = leaveBalance;
                LeaveEntity.Leave_Date_From = leaveDateFrom;
                LeaveEntity.LeaveDateTo = leaveDateTo;
                LeaveEntity.LeaveStatus = leaveStatus;
                LeaveEntity.EmployeeID = employeeId;
                LeaveEntity.ManagerID = managerId;

                Console.WriteLine(leaveEntity);

                bool updateStatus = leaveBLL.UpdateLeaveBLL(leaveEntity);

                if (updateStatus == true)
                {
                    this.Close();
                    MessageBox.Show("Leave Request updated Successfully");
                }
                else
                {
                    MessageBox.Show("Something is wrong..check your details again..");
                }
                Console.WriteLine(leaveDateFrom);

            }
            catch (Exception exception)
            {
                Console.WriteLine("Something Went Wrong." + exception.Message);
            }
        }

        private void txtLeaveId_TextChanged(object sender, TextChangedEventArgs e)
        {
            //txtLeaveId.Text = "10";



        }



        private void txtEmployeeId_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtEmployeeId.Text = EmployeeEntity.EmployeeID.ToString();
        }

        private void txtLeaveBalance_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtManagerId_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtManagerId.Text = EmployeeEntity.ManagerID.ToString();
        }

        private void txtNoOfDays_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*DateTime startdate = DateTime.Parse(LeaveDateFrom.Text).Date;
            DateTime enddate = DateTime.Parse(LeaveDateTo.Text).Date;
            TimeSpan remaindate = enddate - startdate;*/

            txtNoOfDays.Text = NoOfDays();
        }

        public string NoOfDays()
        {
            DateTime startdate = DateTime.Parse(LeaveDateFrom.Text.ToString());
            DateTime enddate = DateTime.Parse(LeaveDateTo.Text.ToString());
            Console.WriteLine("no of days called");
            if(startdate<enddate)
            {
                Console.WriteLine("inif condition");
                TimeSpan remaindate = enddate - startdate;
                string days = remaindate.TotalDays.ToString();
                ///this is total no of leavs without weekends
                /// remove weekends from total leave days
                int count = Convert.ToInt32(days);
                Console.WriteLine( "count"+ count);
                int intDay = count;
                DateTime date = startdate;
                for(int i=0;i<=count;i++)
                {
                    
                    if((date.DayOfWeek.ToString() == "Saturday") || (date.DayOfWeek.ToString() == "Sunday"))
                    {
                        intDay--;
                        Console.WriteLine("Int Days"+ intDay);
                    }
                   date =  date.AddDays(1);
                }
                days = (Convert.ToInt32(intDay) + 1).ToString();

                return days;
            }
            else if(startdate == enddate)
            {
                return "1";
            }
            else
            {
                MessageBox.Show("check your start date and end date ==> startdate<enddate ?");
                return "";
            }
           
        }

        private void DeleteLeavebtn_Click(object sender, RoutedEventArgs e)
        {
            bool deleteLeave = leaveBLL.DeleteLeaveBLL(LeaveEntity.LeaveRequestID);
            if(deleteLeave)
            {
                MessageBox.Show("Deleted successfully");
            }
            else
            {
                MessageBox.Show("Something went wrong..");
            }
        }

        private void SearchLeavebtn_Click(object sender, RoutedEventArgs e)
        {
            getleaveDetails();
        }

        public bool getleaveDetails()
        {
            int id = int.Parse(txtLeaveId_Search.Text);
            // LeaveEntity.LeaveRequestID = id;
            //here i ger all the leave details in text box as per ID
            bool getLeaveDetails = leaveBLL.getOneLeaveDetailsBLL(id);
            if (getLeaveDetails)
            {
                txtLeaveType.Text = LeaveEntity.LeaveType;
                txtLeaveId.Text = LeaveEntity.LeaveRequestID.ToString();
                LeaveDateFrom.SelectedDate = LeaveEntity.Leave_Date_From;
                LeaveDateTo.SelectedDate = LeaveEntity.LeaveDateTo;
                txtNoOfDays.Text = NoOfDays();
                return true;
            }
            else
            {
                MessageBox.Show("Leave Id  does not found or it's not in panding state");
                return false;
            }
        }


        private void LeaveDateTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("S D C ", LeaveDateTo.Text.ToString());
     //       CheckLeaveDates();
            NoOfDays();
        }

      /*  public bool CheckLeaveDates()
        {
            DateTime startdate = DateTime.Parse(LeaveDateFrom.Text.ToString());
            DateTime enddate = DateTime.Parse(LeaveDateTo.Text.ToString());

            bool checkDate = 
        }*/
        private void txtLeaveId_Search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
