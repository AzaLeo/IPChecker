using System;
using System.ServiceModel.Syndication;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace IPChecker
{
    public partial class FormMain : Form
    {
        private ForumRssDataGrid _forumThemesRssDataGrid;
        private ForumRssDataGrid _forumMessagesRssDataGrid;

        public FormMain()
        {
            InitializeComponent();
            _forumThemesRssDataGrid = new ForumRssDataGrid();
            _forumMessagesRssDataGrid = new ForumRssDataGrid();
            dataGridViewTopics.Rows.AddRange(_forumThemesRssDataGrid.GetTopics().ToArray());
            dataGridViewMessages.Rows.AddRange(_forumMessagesRssDataGrid.GetMessages().ToArray());
        }

        private void dataGridViewThemes_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
