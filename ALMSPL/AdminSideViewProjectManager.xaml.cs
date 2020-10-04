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
    /// Interaction logic for AdminSideViewProjectManager.xaml
    /// </summary>
    public partial class AdminSideViewProjectManager : Window
    {
        EmployeeBLL employeeBLL = new EmployeeBLL();
        public AdminSideViewProjectManager()
        {
            InitializeComponent();
            dgManagerDetails.DataContext = employeeBLL.LoadGridManagerBLL();
        }
    }
}
