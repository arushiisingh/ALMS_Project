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

namespace ALMSPL
{
    /// <summary>
    /// Interaction logic for ManagerHomePage.xaml
    /// </summary>
    public partial class ManagerHomePage : Window
    {
        EmployeeEntity employeeEntity = new EmployeeEntity();
        public ManagerHomePage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window_Loaded);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Manager_Name.Content = EmployeeEntity.EmployeeName.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void LeaveButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeLeaveDetailsPL leaveDetailsPL = new EmployeeLeaveDetailsPL();
            
            this.Close();
          //  leaveDetailsPL.LeaveAproveRejectBtn.Visibility = Visibility.Hidden;
            leaveDetailsPL.Show();
        }
    }
}
