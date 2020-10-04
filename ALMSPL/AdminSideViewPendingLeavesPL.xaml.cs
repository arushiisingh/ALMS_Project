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
    /// Interaction logic for AdminSideViewPendingLeavesPL.xaml
    /// </summary>
    /// 
    public partial class AdminSideViewPendingLeavesPL : Window
    {
        LeaveBLL leaveBLL = new LeaveBLL();
        public AdminSideViewPendingLeavesPL()
        {
            InitializeComponent();
            dgleave.DataContext = leaveBLL.LoadGridPendingLeavesBLL();
        }
    }
}
