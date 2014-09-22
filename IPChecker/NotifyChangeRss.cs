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
        public int NewTopicsCount { get; private set; }
        public int NewPostsCount { get; private set; }
        public int NewsCount { get; private set; }
        public int NewPublicationsCount { get; private set; }
        public int NewAdsCount { get; private set; }
        private int _i;
        private const int _forumDateCell = 3, _contentDateCell = 1, _adsDateCell = 2;

        internal int CheckTopics(DataGridViewRow dataGridViewRow, List<DataGridViewRow> newRowsTopics)
        {
            for (_i = 0; _i <= newRowsTopics.Count; _i++)
            {
                if (dataGridViewRow.Cells[_forumDateCell].Value.Equals(newRowsTopics[_i].Cells[_forumDateCell].Value))
                {
                    break;
                }
            }
            return NewTopicsCount += _i;
        }

        internal int CheckPosts(DataGridViewRow dataGridViewRow, List<DataGridViewRow> newRowsPosts)
        {
            for (_i = 0; _i <= newRowsPosts.Count; _i++)
            {
                if (dataGridViewRow.Cells[_forumDateCell].Value.Equals(newRowsPosts[_i].Cells[_forumDateCell].Value))
                {
                    break;
                }
            }
            return NewPostsCount += _i;
        }

        internal int CheckNews(DataGridViewRow dataGridViewRow, List<DataGridViewRow> newRowsNews)
        {
            for (_i = 0; _i <= newRowsNews.Count; _i++)
            {
                if (dataGridViewRow.Cells[_contentDateCell].Value.Equals(newRowsNews[_i].Cells[_contentDateCell].Value))
                {
                    break;
                }
            }
            return NewsCount += _i;
        }

        internal int CheckPublications(DataGridViewRow dataGridViewRow, List<DataGridViewRow> newRowsPublications)
        {
            for (_i = 0; _i <= newRowsPublications.Count; _i++)
            {
                if (dataGridViewRow.Cells[_contentDateCell].Value.Equals(newRowsPublications[_i].Cells[_contentDateCell].Value))
                {
                    break;
                }
            }
            return NewPublicationsCount += _i;
        }

        internal int CheckAds(DataGridViewRow dataGridViewRow, List<DataGridViewRow> newRowsAds)
        {
            for (_i = 0; _i <= newRowsAds.Count; _i++)
            {
                if (dataGridViewRow.Cells[_adsDateCell].Value.Equals(newRowsAds[_i].Cells[_adsDateCell].Value))
                {
                    break;
                }
            }
            return NewAdsCount += _i;
        }
    }
}
