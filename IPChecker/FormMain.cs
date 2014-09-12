using System;
using System.ServiceModel.Syndication;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

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
            UpdateRssDataGrid();
            //timerUpdate.Interval = Properties.Settings.Default.IntervalUpdate;
            //timerUpdate.Tick += timerUpdate_Tick;
            //timerUpdate.Start();
        }

        void timerUpdate_Tick(object sender, EventArgs e)
        {
            UpdateRssDataGrid();
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
            IPCheckerSettings ipCheckerSettings = new IPCheckerSettings();
            ipCheckerSettings.Show();
        }

    }
}
