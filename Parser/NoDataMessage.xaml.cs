using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Parser
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class NoDataMessage : Window
    {
        public NoDataMessage()
        {
            InitializeComponent();
        }

        private void LoadData_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void InitialCreate_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.createNewFile = true;
            this.DialogResult = false;
        }

    }
}
