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

namespace ALMSPL
{
    /// <summary>
    /// Interaction logic for AdminSideEmployeeDetailsPL.xaml
    /// </summary>
    public partial class AdminSideEmployeeDetailsPL : Window
    {
        public AdminSideEmployeeDetailsPL()
        {
            InitializeComponent();
        }

        private void EmployeeDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            AdminSideAddEmployeePL addEmployeePage = new AdminSideAddEmployeePL();
            //this.Close();
            addEmployeePage.Show();
        }

        private void AttendenceButton_Click(object sender, RoutedEventArgs e)
        {
            AdminSideViewPendingAttendence adminSideViewPendingAttendence = new AdminSideViewPendingAttendence();
            adminSideViewPendingAttendence.Show();
        }

        private void LeavesButton_Click(object sender, RoutedEventArgs e)
        {
            AdminSideViewPendingLeavesPL adminSideViewPendingLeavesPL = new AdminSideViewPendingLeavesPL();
            adminSideViewPendingLeavesPL.Show();
        }
    }
}
