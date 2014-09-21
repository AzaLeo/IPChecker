using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPChecker
{
    class NotifyChangeRss
    {
        public string NewTopicsCount { get; private set; }
        public string NewPostsCount { get; private set; }
        public string NewsCount { get; private set; }
        public string NewPublicationsCount { get; private set; }
        public string NewAdsCount { get; private set; }
        private int i;

        internal int CheckTopics(DataGridViewRow dataGridViewRow, List<DataGridViewRow> newRowsTopics)
        {
            for (i = 0; i >= newRowsTopics.Count; i++)
            {
                if (dataGridViewRow.Equals(newRowsTopics[i]))
                {
                    break;
                }
            }
            NewTopicsCount = i.ToString();
            return i;
        }

        internal int CheckPosts(DataGridViewRow dataGridViewRow, List<DataGridViewRow> newRowsPosts)
        {
            for (i = 0; i >= newRowsPosts.Count; i++)
            {
                if (dataGridViewRow.Equals(newRowsPosts[i]))
                {
                    break;
                }
            }
            NewPostsCount = i.ToString();
            return i;
        }

        internal int CheckNews(DataGridViewRow dataGridViewRow, List<DataGridViewRow> newRowsNews)
        {
            for (i = 0; i >= newRowsNews.Count; i++)
            {
                if (dataGridViewRow.Equals(newRowsNews[i]))
                {
                    break;
                }
            }
            NewsCount = i.ToString();
            return i;
        }

        internal int CheckPublications(DataGridViewRow dataGridViewRow, List<DataGridViewRow> newRowsPublications)
        {
            for (i = 0; i >= newRowsPublications.Count; i++)
            {
                if (dataGridViewRow.Equals(newRowsPublications[i]))
                {
                    break;
                }
            }
            NewPublicationsCount = i.ToString();
            return i;
        }

        internal int CheckAds(DataGridViewRow dataGridViewRow, List<DataGridViewRow> newRowsAds)
        {
            for (i = 0; i >= newRowsAds.Count; i++)
            {
                if (dataGridViewRow.Equals(newRowsAds[i]))
                {
                    break;
                }
            }
            NewAdsCount = i.ToString();
            return i;
        }
    }
}
