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
    /// Interaction logic for EmployeeHomePage.xaml
    /// </summary>
    public partial class EmployeeHomePage : Window
    {
        LoginEntity loginEntity = new LoginEntity();
        LoginBLL loginBLL = new LoginBLL();
        public EmployeeHomePage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window_Loaded);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeNameLabel.Content = EmployeeEntity.EmployeeName.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

       

        private void ProjectButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AttendanceButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LeaveButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeLeaveDetailsPL leaveDetailsPL = new EmployeeLeaveDetailsPL();
            this.Close();
            leaveDetailsPL.LeaveAproveRejectBtn.Visibility = Visibility.Hidden;
            leaveDetailsPL.Show();
        }
    }
}
