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
using System.Collections.ObjectModel;

namespace Parser
{
    /// <summary>
    /// Interaction logic for UpdateMessage.xaml
    /// </summary>
    public partial class UpdateMessage : Window
    {
        public ObservableCollection<ThreatModel> changedThreats = ((MainWindow)Application.Current.MainWindow).updateThreats;
        public ObservableCollection<ThreatModel> previousThreats = ((MainWindow)Application.Current.MainWindow).oldThreats;
        public ObservableCollection<DifferenceModel> changes = new ObservableCollection<DifferenceModel>();
        public ObservableCollection<DifferenceModel> Changes
        {
            get { return this.changes; }
        }
        public UpdateMessage()
        {
            InitializeComponent();
            MessageBox.Show("changedThreats:  " + changedThreats.Count
                + "\n" + "previousThreats" + previousThreats.Count);
            int totalThreatsChanged = 0;
            bool isChanged = false;
            int i = 0;
            int j = 0;
            int k = (changedThreats.Count > 0) ? changedThreats.Count - 1 : -1;
            MessageBox.Show(changedThreats.Count + "  changedThreats.count");
            if (k > -1)
            {
                MessageBox.Show("changedThreats.Count > 0");
                foreach (var item in previousThreats)
                {
                    if (item.ThreatId == changedThreats[i].ThreatId)
                    {
                        if (item.ThreatName != changedThreats[i].ThreatName)
                        {
                            MessageBox.Show("Works!");
                            changes.Add(new DifferenceModel());
                            changes[j].ThreatId = item.ThreatId;
                            changes[j].OldData = item.ThreatName;
                            changes[j].NewData = changedThreats[i].ThreatName;
                            isChanged = true;
                            j++;
                        }
                        if (item.Description != changedThreats[i].Description)
                        {
                            changes.Add(new DifferenceModel());
                            changes[j].ThreatId = item.ThreatId;
                            changes[j].OldData = item.Description;
                            changes[j].NewData = changedThreats[i].Description;
                            isChanged = true;
                            j++;
                        }
                        if (item.Source != changedThreats[i].Source)
                        {
                            changes.Add(new DifferenceModel());
                            changes[j].ThreatId = item.ThreatId;
                            changes[j].OldData = item.Source;
                            changes[j].NewData = changedThreats[i].Source;
                            isChanged = true;
                            j++;
                        }
                        if (item.Target != changedThreats[i].Target)
                        {
                            changes.Add(new DifferenceModel());
                            changes[j].ThreatId = item.ThreatId;
                            changes[j].OldData = item.Target;
                            changes[j].NewData = changedThreats[i].Target;
                            isChanged = true;
                            j++;
                        }
                        if (item.ConfidentialityBreach != changedThreats[i].ConfidentialityBreach)
                        {
                            changes.Add(new DifferenceModel());
                            changes[j].ThreatId = item.ThreatId;
                            changes[j].OldData = item.ConfidentialityBreach.ToString();
                            changes[j].NewData = changedThreats[i].ConfidentialityBreach.ToString();
                            isChanged = true;
                            j++;
                        }
                        if (item.IntegrityViolation != changedThreats[i].IntegrityViolation)
                        {
                            changes.Add(new DifferenceModel());
                            changes[j].ThreatId = item.ThreatId;
                            changes[j].OldData = item.IntegrityViolation.ToString();
                            changes[j].NewData = changedThreats[i].IntegrityViolation.ToString();
                            isChanged = true;
                            j++;
                        }
                        if (item.AccessViolation != changedThreats[i].AccessViolation)
                        {
                            changes.Add(new DifferenceModel());
                            changes[j].ThreatId = item.ThreatId;
                            changes[j].OldData = item.AccessViolation.ToString();
                            changes[j].NewData = changedThreats[i].AccessViolation.ToString();
                            isChanged = true;
                            j++;
                        }
                        totalThreatsChanged = (isChanged) ? (totalThreatsChanged + 1) : totalThreatsChanged;
                        isChanged = false;
                        if (i < (changedThreats.Count - 1))
                        {
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            if (changedThreats.Count > previousThreats.Count)
            {
                j = previousThreats.Count;
                k = changedThreats.Count;
                for (int l = j; l < k; l++)
                {
                    changes.Add(new DifferenceModel());
                    j++;
                    changes[j].ThreatId = changedThreats[l].ThreatId;
                    changes[j].OldData = "";
                    changes[j].NewData = "This threat was added";
                }
            }
            ChangesGrid.ItemsSource = null;
            ChangesGrid.ItemsSource = Changes;
            MessageBox.Show("totalThreatsChanged  " + totalThreatsChanged);
        }
    }
}
