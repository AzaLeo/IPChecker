using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace IPChecker
{
    class ForumRssDataGrid
    {
        private XmlReader _reader;
        private SyndicationFeed _feed;
        public List<DataGridViewRow> ForumRowCollections { get; private set; }

        public ForumRssDataGrid()
        {
            _reader = XmlReader.Create("http://feeds.feedburner.com/infoport/newtopics");
            _feed = SyndicationFeed.Load(_reader);
            ForumRowCollections = new List<DataGridViewRow>();
            Updade();
        }

        public void Updade()
        {
            foreach (SyndicationItem i in _feed.Items)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = i.Title.Text });
                newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = i.Categories[0].Name });
                newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = i.Authors[0].Name });
                newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = i.PublishDate.DateTime.ToString() });
                newRow.Cells.Add(new DataGridViewLinkCell() { Value = "Перейти", Tag = i.Id });
                ForumRowCollections.Add(newRow);
            }
        }
    }
}
