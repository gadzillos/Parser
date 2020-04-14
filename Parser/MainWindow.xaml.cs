using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace Parser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool createNewFile = false;
        public static bool isViewSimplified = false;
        public ObservableCollection<ThreatModel> threats = new ObservableCollection<ThreatModel>();
        public ObservableCollection<ThreatModel> updateThreats = new ObservableCollection<ThreatModel>();
        public ObservableCollection<ThreatModel> Threats
        {
            get { return this.threats; }
        }
        public ObservableCollection<ThreatModel> oldThreats = new ObservableCollection<ThreatModel>();
        public ObservableCollection<ThreatModel> OldThreats
        {
            get { return this.oldThreats; }
        }
        public MainWindow()
        {
            InitializeComponent();
            Table.Columns[2].Visibility = Visibility.Visible;
            bool? dialogResult = false;
            if (! File.Exists(thrlistPath))
            {
                NoDataMessage initialMessage = new NoDataMessage();
                dialogResult = initialMessage.ShowDialog();
            }
            else
            {
                ParseXlsx();
            }
            if ((bool) dialogResult)
            {
                DownloadFile();
            }
            else if (createNewFile)
            {
                Thread fileCopy = new Thread(CreateNewFile);
                fileCopy.Start();
            }
        }

        private void ViewData_Click(object sender, RoutedEventArgs e)
        {
            if (!Table.IsVisible)
            {
                Table.Visibility = Visibility.Visible;
            }
            else
            {
                Table.Visibility = Visibility.Collapsed;
            }
        }

        private void RefreshFile_Click(object sender, RoutedEventArgs e)
        {
            isUpdate = true;
            RefreshFile.Visibility = Visibility.Collapsed;
            oldThreats = Threats;
            threats = new ObservableCollection<ThreatModel>();
            DownloadFile();
            Table.ItemsSource = null;
            Table.ItemsSource = Threats;
            MessageBox.Show("Downloaded");
            UpdateMessage update = new UpdateMessage();
            update.Show();
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            Table.ItemsSource = null;
            currentPage--;
            if (currentPage == 0)
            {
                PreviousPage.Visibility = Visibility.Collapsed;
            }
            else
            {
                PreviousPage.Visibility = Visibility.Visible;
            }
            NextPage.Visibility = Visibility.Visible;
            Table.ItemsSource = Pages[currentPage];
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            Table.ItemsSource = null;
            currentPage++;
            if (currentPage == Pages.Count - 1)
            {
                NextPage.Visibility = Visibility.Collapsed;
            }
            else
            {
                NextPage.Visibility = Visibility.Visible;
            }
            PreviousPage.Visibility = Visibility.Visible;
            Table.ItemsSource = Pages[currentPage];
        }

        private void ViewMode_Click(object sender, RoutedEventArgs e)
        {
            isViewSimplified = !isViewSimplified;
            if (isViewSimplified)
            {
                for (int i = 2; i < Table.Columns.Count; i++)
                {
                    Table.Columns[i].Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                for (int i = 2; i < Table.Columns.Count; i++)
                {
                    Table.Columns[i].Visibility = Visibility.Visible;
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog save = new Microsoft.Win32.SaveFileDialog();
            save.FileName = "Thrlist"; // Default file name
            save.DefaultExt = ".xlsx"; // Default file extension
            save.Filter = "Text documents (.xlsx)|*.txt"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = save.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = save.FileName;
            }
        }
    }
}
