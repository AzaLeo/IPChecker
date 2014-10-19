using System;
using System.Collections.Generic;
using System.Globalization;
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
        internal List<DataGridViewRow> GetTopics()
        {
            var _reader = XmlReader.Create("http://feeds.feedburner.com/infoport/newtopics");
            var _feed = SyndicationFeed.Load(_reader);
            return GetRssData(_feed);
        }

        internal List<DataGridViewRow> GetPosts()
        {
            var _reader = XmlReader.Create("http://feeds.feedburner.com/infoport/newposts");
            var _feed = SyndicationFeed.Load(_reader);
            return GetRssData(_feed);
        }

        private List<DataGridViewRow> GetRssData(SyndicationFeed _feed)
        {
            var _rowCollections = new List<DataGridViewRow>();

            foreach (SyndicationItem i in _feed.Items)
            {
                var newRow = new DataGridViewRow();
                newRow.Cells.Add(new DataGridViewLinkCell() { Value = TitleWithoutSection(i.Title.Text), Tag = i.Id });
                newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = i.Categories[0].Name });
                newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = i.Authors[0].Name });
                newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = ModifedTime(i.PublishDate.LocalDateTime) });
                _rowCollections.Add(newRow);
            }
            return _rowCollections;
        }

        private string TitleWithoutSection(string title)
        {
            return title.Substring(title.IndexOf((char)8226) + 2);
        }

        private string ModifedTime(DateTime dt)
        {
            if (dt.DayOfYear == DateTime.Now.DayOfYear && dt.Year == DateTime.Now.Year)
            {
                return String.Format("Сегодня, {0}", dt.ToString("HH:mm"));
            }
            else if (dt.DayOfYear == DateTime.Now.AddDays(-1).DayOfYear && dt.Year == DateTime.Now.Year)
            {
                return String.Format("Вчера, {0}", dt.ToString("HH:mm"));
            }
            else
            {
                return dt.ToString("dd MMMM yyyy", new CultureInfo("ru"));
            }
        }
    }
}
