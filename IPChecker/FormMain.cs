﻿using System;
using System.ServiceModel.Syndication;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace IPChecker
{
    public partial class FormMain : Form
    {
        private ForumRssDataGrid _forumRssDataGrid;
        private NewsRssDataGrid _newsRssDataGrid;

        public FormMain()
        {
            InitializeComponent();
            _forumRssDataGrid = new ForumRssDataGrid();
            _newsRssDataGrid = new NewsRssDataGrid();
            dataGridViewTopics.Rows.AddRange(_forumRssDataGrid.GetTopics().ToArray());
            dataGridViewMessages.Rows.AddRange(_forumRssDataGrid.GetMessages().ToArray());
            dataGridViewNews.Rows.AddRange(_newsRssDataGrid.GetNews().ToArray());
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

    }
}