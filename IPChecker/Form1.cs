using System;
using System.ServiceModel.Syndication;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace IPChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridViewForum_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var clickCell = dataGridViewMain.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //System.Diagnostics.Process.Start((string)clickCell.Tag);
        }

        private void tabControlDataGrid_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    dataGridViewForum.Rows.AddRange(new ForumRssDataGrid().ForumRowCollections.ToArray());
                    break;
            }
        }
    }
}
