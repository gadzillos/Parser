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
using DocumentFormat.OpenXml.Drawing;

namespace Parser
{
    /// <summary>
    /// Downloading logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow
    {
        string thrlistPath = @"..\..\..\Data\thrlist.xlsx";
        public static bool isUpdate = false;
        private void DownloadFile()
        {
            LoadProgress.Visibility = Visibility.Visible;
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                try
                {
                    wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://bdu.fstec.ru/files/documents/thrlist.xlsx"),
                    // Param2 = Path to save
                    thrlistPath
                    );
                }
                catch (Exception)
                {
                    LoadProgress.Visibility = Visibility.Collapsed;
                    MessageBox.Show("Downloading error, please try again");
                    RefreshFile.IsEnabled = true;
                }
            }

            void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {
                LoadProgress.Value = e.ProgressPercentage;
            }

            void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
            {
                ParseXlsx();
                if (!isUpdate)
                {
                    MessageBox.Show("Download successfull");
                }
                LoadProgress.Visibility = Visibility.Collapsed;
            }
        }

        void CreateNewFile()
        {
            try
            {
                File.Copy(@"../../../Resources/thrlistEmpty.xlsx", thrlistPath);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Couldn't create a new file: program doesn't contain 'Resources' folder or path was corrupted");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Couldn't create a new file: program doesn't contain 'thrlistEmpty.xlsx' in 'Resources' folder");
            }
            catch (UnauthorizedAccessException error)
            {
                MessageBox.Show("Couldn't create a new file: secuity error \n\n" + error);
            }
            catch (Exception error)
            {
                MessageBox.Show("Couldn't create a new file: something went wrong... \n\n" + error);
            }
            finally
            {
                PreviousPage.Visibility = Visibility.Collapsed;
                NextPage.Visibility = Visibility.Collapsed;
            }
        }
    }
}
