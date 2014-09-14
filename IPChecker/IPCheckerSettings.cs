using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IPChecker.Properties;

namespace IPChecker
{
    public partial class IPCheckerSettings : Form
    {
        public readonly List<int> minutesUpdate = new List<int>() { 5, 10, 15, 20, 30, 60 };

        public IPCheckerSettings()
        {
            InitializeComponent();
            
            checkBoxRunSystemStart.Checked = Settings.Default.RunSystemStart;
            checkBoxSoundNotification.Checked = Settings.Default.SoundNotification;
            checkBoxPopUpNotifications.Checked = Settings.Default.PopUpNotification;
            checkBoxIntervalChecking.Checked = Settings.Default.IntervalUpdate;
            comboBoxMinutes.DataSource = minutesUpdate;
            comboBoxMinutes.SelectedIndex = Settings.Default.IntervalUpdateValue;
            checkBoxTopics.Checked = Settings.Default.TrackEventTopics;
            checkBoxMessages.Checked = Settings.Default.TrackEventMessages;
            checkBoxNews.Checked = Settings.Default.TrackEventNews;
            checkBoxPublications.Checked = Settings.Default.TrackEventPublications;
            checkBoxAds.Checked = Settings.Default.TrackEventAds;
            CheckIntervalCheckBox();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Settings.Default.RunSystemStart = checkBoxRunSystemStart.Checked;
            Settings.Default.SoundNotification = checkBoxSoundNotification.Checked;
            Settings.Default.PopUpNotification = checkBoxPopUpNotifications.Checked;
            Settings.Default.IntervalUpdate = checkBoxIntervalChecking.Checked;
            Settings.Default.IntervalUpdateValue = comboBoxMinutes.SelectedIndex;
            Settings.Default.TrackEventTopics = checkBoxTopics.Checked;
            Settings.Default.TrackEventMessages = checkBoxMessages.Checked;
            Settings.Default.TrackEventNews = checkBoxNews.Checked;
            Settings.Default.TrackEventPublications = checkBoxPublications.Checked;
            Settings.Default.TrackEventAds = checkBoxAds.Checked;
            Settings.Default.Save();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxIntervalChecking_CheckedChanged(object sender, EventArgs e)
        {
            CheckIntervalCheckBox();
        }

        private void CheckIntervalCheckBox()
        {
            if (checkBoxIntervalChecking.Checked)
            {
                comboBoxMinutes.Enabled = true;
            }
            else
            {
                comboBoxMinutes.Enabled = false;
            }
        }
    }
}
