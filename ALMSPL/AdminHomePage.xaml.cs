﻿using System;
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
    /// Interaction logic for AdminHomePage.xaml
    /// </summary>
    public partial class AdminHomePage : Window
    {
        public AdminHomePage()
        {
            InitializeComponent();
        }

        private void ProjectDetailsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            AdminSideEmployeeDetailsPL AdminSidemployeeDetailsPage = new AdminSideEmployeeDetailsPL();
            
            AdminSidemployeeDetailsPage.Show();
        }

        private void ProjectManagerButton_Click(object sender, RoutedEventArgs e)
        {
            AdminSideViewProjectManager adminSideViewProjectManager = new AdminSideViewProjectManager();
            adminSideViewProjectManager.Show();
        }

    }
}
