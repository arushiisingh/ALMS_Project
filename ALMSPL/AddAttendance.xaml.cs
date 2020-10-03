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
using ALMSEntity;
using ALMSBLL;
using ALMSDAL;

namespace ALMSPL
{
    /// <summary>
    /// Interaction logic for AddAttendance.xaml
    /// </summary>
    public partial class AddAttendance : Window
    {
        AttendanceEntity attendanceEntity = new AttendanceEntity();
        AttendanceBLL attendanceBLL = new AttendanceBLL();
        LoginEntity loginEntity = new LoginEntity();
        

        public AddAttendance()
        {
            InitializeComponent();
            txtEmpId.Text = LoginEntity.UserID.ToString();
            txtPId.Text = LoginEntity.ProjectID.ToString();
            LoadGrid();
        }

        private void LoadGrid()
        {
            dgAttendance.DataContext = attendanceBLL.LoadGridBLL(LoginEntity.UserID);
        }

        private void Add_Attendance_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                attendanceEntity.EmployeeID = int.Parse(txtEmpId.Text);
                attendanceEntity.ProjectID = int.Parse(txtPId.Text);
                attendanceEntity.AttendanceType = cmbAType.Text;
                attendanceEntity.AttendanceDate = txtDate.SelectedDate.Value;
                attendanceEntity.InTime = txtInTime.Text;
                attendanceEntity.OutTime = txtOutTime.Text;
                

                if (attendanceBLL.ValidateAttendanceBLL(attendanceEntity) == true)
                {
                    MessageBox.Show("Attendace Addedd Succesfully!!");
                    //dgAttendance.DataContext = attendanceDAL.LoadGridDAL();
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Leave Is Already Applied For This Date!!!");
                    LoadGrid();
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
               
            }
        }

        private void Attendance_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                attendanceEntity.AttendanceID = int.Parse(txtAId.Text);
                attendanceEntity.EmployeeID = int.Parse(txtEmpId.Text);
                attendanceEntity.AttendanceType = cmbAType.Text;
                attendanceEntity.AttendanceDate = txtDate.SelectedDate.Value;
                attendanceEntity.InTime = txtInTime.Text;
                attendanceEntity.OutTime = txtOutTime.Text;

                if (attendanceBLL.UpdateAttendanceBLL(attendanceEntity) == true)
                {
                    MessageBox.Show("Attendace Updated Succesfully!!");
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Attendance Is Already Approved or Rejected. Cannot Update!!!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            LoadGrid();
        }

        private void Attendance_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int AttendaceId = int.Parse(txtAId.Text);
                if (attendanceBLL.DeleteAttendanceBLL(AttendaceId, LoginEntity.UserID))
                {
                    MessageBox.Show("Attendance Deleted Successfully!!");
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Attendance Is Already Approved or Rejected. Cannot Delete!!!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Attendance not deleted. Error is: " +ex);
            }
        }

        private void Attendance_Search_Click(object sender, RoutedEventArgs e)
        {
            AttendanceEntity searchedAttendanceEntity = null;

            try
            {
                int AttendanceID = int.Parse(txtAId.Text);
                string x = "01 - 01 - 0001";
                searchedAttendanceEntity = attendanceBLL.SearchAttendanceBLL(AttendanceID, LoginEntity.UserID);
                if(searchedAttendanceEntity.AttendanceDate != Convert.ToDateTime(x))
                {
                    MessageBox.Show("Attendance Found!!");
                    txtEmpId.Text = searchedAttendanceEntity.EmployeeID.ToString();
                    cmbAType.Text = searchedAttendanceEntity.AttendanceType;
                    txtDate.Text = Convert.ToDateTime(searchedAttendanceEntity.AttendanceDate).ToString();
                    txtInTime.Text = searchedAttendanceEntity.InTime;
                    txtOutTime.Text = searchedAttendanceEntity.OutTime;
                }
                else
                {
                    MessageBox.Show("Attendance Not Found!!!");
                }    
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private void Attendance_Pending_Request_click(object sender, RoutedEventArgs e)
        {
            AttendancePendingList attendancePendingList = new AttendancePendingList();
            attendancePendingList.Show();
        }
    }
}
