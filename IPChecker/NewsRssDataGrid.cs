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
    class NewsRssDataGrid
    {
        public List<DataGridViewRow> GetNews()
        {
            var _reader = XmlReader.Create("http://feeds.feedburner.com/infoport/news");
            var _feed = SyndicationFeed.Load(_reader);
            return GetRssData(_feed);
        }

        private List<DataGridViewRow> GetRssData(SyndicationFeed _feed)
        {
            var _rowCollections = new List<DataGridViewRow>();

            foreach (SyndicationItem i in _feed.Items)
            {
                var newRow = new DataGridViewRow();
                newRow.Cells.Add(new DataGridViewLinkCell() { Value = i.Title.Text, Tag = i.Id });
                newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = i.PublishDate.DateTime.ToString() });
                _rowCollections.Add(newRow);
            }
            return _rowCollections;
        }
    }
}
