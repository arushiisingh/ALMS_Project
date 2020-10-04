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

namespace ALMSPL
{
    /// <summary>
    /// Interaction logic for AdminSideViewPendingAttendence.xaml
    /// </summary>
    public partial class AdminSideViewPendingAttendence : Window
    {
        AttendanceBLL attendanceBLL = new AttendanceBLL();
        public AdminSideViewPendingAttendence()
        {
            InitializeComponent();
            dgAttendance.DataContext = attendanceBLL.LoadGridAttendanceBLL();
        }
    }
}
