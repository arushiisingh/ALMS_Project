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
namespace ALMSPL
{
    /// <summary>
    /// Interaction logic for ProjectAttendance.xaml
    /// </summary>
    public partial class ProjectAttendance : Window
    {
        AttendanceEntity attendanceEntity = new AttendanceEntity();
        AttendanceBLL attendanceBLL = new AttendanceBLL();
        public ProjectAttendance()
        {
            InitializeComponent();
        }

        private void LoadGrid()
        {
            dgProjectAttendance.DataContext = attendanceBLL.LoadGridBLL(LoginEntity.UserID);
        }

        private void Attendance_Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ProjectID = int.Parse(txtPId.Text);
                dgProjectAttendance.DataContext = attendanceBLL.LoadGridPABLL(ProjectID,LoginEntity.UserID);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private void AttendanceByMonth_Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ProjectID = int.Parse(txtPId.Text);
                int Month = int.Parse(txtMonth.Text);
                dgProjectAttendance.DataContext = attendanceBLL.LoadGridPAMBLL(ProjectID, Month, LoginEntity.UserID);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private void AttendanceByDay_Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ProjectID = int.Parse(txtPId.Text);
                DateTime date = txtDateFrom.SelectedDate.Value;
                dgProjectAttendance.DataContext = attendanceBLL.LoadGridPADBLL(ProjectID, date, LoginEntity.UserID);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private void AttendanceBetweenDates_Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ProjectID = int.Parse(txtPId.Text);
                DateTime FromDate = txtDateFrom.SelectedDate.Value;
                DateTime ToDate = txtDateTo.SelectedDate.Value;
                dgProjectAttendance.DataContext = attendanceBLL.LoadGridPABDBLL(ProjectID, FromDate, ToDate, LoginEntity.UserID);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message
                    );
            }
        }
    }
}
