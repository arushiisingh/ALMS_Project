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
using System.Data;

namespace ALMSPL
{
    /// <summary>
    /// Interaction logic for AttendancePendingList.xaml
    /// </summary>
    public partial class AttendancePendingList : Window
    {
        AttendanceEntity attendanceEntity = new AttendanceEntity();
        AttendanceBLL attendanceBLL = new AttendanceBLL();

        public AttendancePendingList()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void LoadGrid()
        {
            dgAttendance.DataContext = attendanceBLL.LoadGridARBLL(LoginEntity.UserID);
        }

        private void Attendance_Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                attendanceEntity.AttendanceID = int.Parse(txtAId.Text);
                attendanceEntity.EmployeeID = int.Parse(txtEmpId.Text);
                attendanceEntity.StatusOfAttendance = cmbSAType.Text;
                
                if (attendanceBLL.ApproveRejectAttendanceBLL(attendanceEntity) == true)
                {
                    MessageBox.Show("Pending Attendace Updated succesfully");
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Pending Attendace Not Updated.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            LoadGrid();
        }

        private void dgAttendance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dgAttendance.Items.Count > 0)
                {
                    txtEmpId.Text = ((DataRowView)dgAttendance.SelectedItem).Row["Employee_ID"].ToString();
                    txtAId.Text = ((DataRowView)dgAttendance.SelectedItem).Row["Attendance_ID"].ToString();
                    cmbSAType.Text = ((DataRowView)dgAttendance.SelectedItem).Row["Status_Of_Attendance"].ToString();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Approved_Attendance_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgAttendance.DataContext = attendanceBLL.LoadGridApprovedAttendanceBLL(LoginEntity.UserID);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private void Rejected_Attendance_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgAttendance.DataContext = attendanceBLL.LoadGridRejectedAttendanceBLL(LoginEntity.UserID);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
