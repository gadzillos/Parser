using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using DocumentFormat.OpenXml.Bibliography;
using System.Linq;
using System.Windows;

namespace Parser
{
    public partial class MainWindow
    {
        public int currentPage = 0;
        public int pageThreats = 15;
        public ObservableCollection<ObservableCollection<ThreatModel>> pages = new ObservableCollection<ObservableCollection<ThreatModel>>();
        public ObservableCollection<ObservableCollection<ThreatModel>> Pages
        {
            get { return pages; }
        }

        public void Paginate (ObservableCollection<ThreatModel> threatList)
        {
            pages.Clear();
            int totalThreats = threatList.Count;
            int pointer = pageThreats;
            if (totalThreats < pageThreats)
            {
                pointer = totalThreats;
            }
            totalThreats = (totalThreats == 0) ? 1 : totalThreats; 
            for (int i = 0; i < totalThreats; i += pageThreats)
            {
                pages.Add(new ObservableCollection<ThreatModel>());
            }
            int j = 0;
            foreach (var item in pages)
            {
                for (int i = j; i < pointer; i++)
                {
                    try
                    {
                        item.Add(threatList[i]);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(i + "\n" + e);
                    }
                }
                j = pointer;
                totalThreats -= pageThreats;
                pointer = (totalThreats - pageThreats >= 0) ? pointer + pageThreats : pointer + totalThreats % 15;
            }
            RefreshFile.Visibility = Visibility.Visible;
        }
    }
}
