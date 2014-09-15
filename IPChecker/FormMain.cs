using System;
using System.ServiceModel.Syndication;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using IPChecker.Properties;

namespace IPChecker
{
    public partial class FormMain : Form
    {
        private ForumRssDataGrid _forumRssDataGrid;
        private ContentRssDataGrid _contentRssDataGrid;
        private AdsRssDataGrid _adsRssDataGrid;

        public FormMain()
        {
            InitializeComponent();
            _forumRssDataGrid = new ForumRssDataGrid();
            _contentRssDataGrid = new ContentRssDataGrid();
            _adsRssDataGrid = new AdsRssDataGrid();
            timerUpdate.Tick += timerUpdate_Tick;
            //UpdateRssDataGrid();
            SetSettings();
        }

        private void SetSettings()
        {
            if (Settings.Default.IntervalUpdate)
            {
                timerUpdate.Interval = (int)new TimeSpan(0, new IPCheckerSettings().minutesUpdate[Settings.Default.IntervalUpdateValue], 0).TotalMilliseconds;
                timerUpdate.Start();
            }
        }

        void timerUpdate_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dataGridViewTopics_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var clickCell = dataGridViewTopics.Rows[e.RowIndex].Cells[e.ColumnIndex];
                System.Diagnostics.Process.Start((string)clickCell.Tag);
            }
        }

        private void dataGridViewMessages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var clickCell = dataGridViewMessages.Rows[e.RowIndex].Cells[e.ColumnIndex];
                System.Diagnostics.Process.Start((string)clickCell.Tag);
            }
        }

        private void dataGridViewNews_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var clickCell = dataGridViewNews.Rows[e.RowIndex].Cells[e.ColumnIndex];
                System.Diagnostics.Process.Start((string)clickCell.Tag);
            }
        }

        private void dataGridViewPublications_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var clickCell = dataGridViewPublications.Rows[e.RowIndex].Cells[e.ColumnIndex];
                System.Diagnostics.Process.Start((string)clickCell.Tag);
            }
        }

        private void dataGridViewAds_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var clickCell = dataGridViewAds.Rows[e.RowIndex].Cells[e.ColumnIndex];
                System.Diagnostics.Process.Start((string)clickCell.Tag);
            }
        }

        private void UpdateRssDataGrid()
        {
            labelTimeUpdate.Text = DateTime.Now.ToString("HH:mm:ss");
            dataGridViewTopics.Rows.Clear();
            dataGridViewTopics.Rows.AddRange(_forumRssDataGrid.GetTopics().ToArray());
            dataGridViewMessages.Rows.Clear();
            dataGridViewMessages.Rows.AddRange(_forumRssDataGrid.GetMessages().ToArray());
            dataGridViewNews.Rows.Clear();
            dataGridViewNews.Rows.AddRange(_contentRssDataGrid.GetNews().ToArray());
            dataGridViewPublications.Rows.Clear();
            dataGridViewPublications.Rows.AddRange(_contentRssDataGrid.GetPublications().ToArray());
            dataGridViewAds.Rows.Clear();
            dataGridViewAds.Rows.AddRange(_adsRssDataGrid.GetAds().ToArray());
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateRssDataGrid();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ipCheckerSettings = new IPCheckerSettings();
            ipCheckerSettings.UpdateSettings += _ipCheckerSettings_UpdateSettings;
            ipCheckerSettings.Show();
        }

        void _ipCheckerSettings_UpdateSettings(object sender, EventArgs e)
        {
            SetSettings();
        }

    }
}
