using System;
using System.ServiceModel.Syndication;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using IPChecker.Properties;
using System.Collections.Generic;
using System.Media;
using Microsoft.Win32;
using System.Drawing;

namespace IPChecker
{
    public partial class FormMain : Form
    {
        private ForumRssDataGrid _forumRssDataGrid;
        private ContentRssDataGrid _contentRssDataGrid;
        private AdsRssDataGrid _adsRssDataGrid;
        private SoundPlayer _notifySound;
        private NotifyChangeRss _notifyChangeRss;
        private FormWindowState _OldFormState;

        public FormMain()
        {
            InitializeComponent();
            _forumRssDataGrid = new ForumRssDataGrid();
            _contentRssDataGrid = new ContentRssDataGrid();
            _adsRssDataGrid = new AdsRssDataGrid();
            _notifySound = new SoundPlayer(Resources.DefaultSound);
            _notifyChangeRss = new NotifyChangeRss();
            SetSettings();
            InitializeRssDataGrid();
        }

        // Установка настроек.
        private void SetSettings()
        {
            var settings = new IPCheckerSettings();

            if (Settings.Default.IntervalUpdate)
            {
                timerUpdate.Tick += timerUpdate_Tick;
                timerUpdate.Interval = (int)new TimeSpan(0, settings.minutesUpdate[Settings.Default.IntervalUpdateValue], 0).TotalMilliseconds;
                timerUpdate.Start();
            }
            if (Settings.Default.RunSystemStart)
            {
                var key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
                key.SetValue("IPChecker", Application.ExecutablePath);
                key.Close();
            }
            else
            {
                try
                {
                    var key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
                    key.DeleteValue("IPChecker");
                    key.Close();
                }
                catch (ArgumentException)
                {
                    return;
                }
            }
        }

        // Обновление по таймеру.
        void timerUpdate_Tick(object sender, EventArgs e)
        {
            UpdateRssDataGrid();
        }


        // Кнопка "обновить".
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateRssDataGrid();
        }

        // Обработчики перехода по ссылкам.
        //
        private void dataGridViewTopics_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var clickCell = dataGridViewTopics.Rows[e.RowIndex].Cells[e.ColumnIndex];
                System.Diagnostics.Process.Start((string)clickCell.Tag);
            }
        }

        private void dataGridViewPosts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var clickCell = dataGridViewPosts.Rows[e.RowIndex].Cells[e.ColumnIndex];
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

        // Заполнение всех DataGrid при старте приложения.
        private void InitializeRssDataGrid()
        {
            AddNewRowsTopics(_forumRssDataGrid.GetTopics());
            AddNewRowsPosts(_forumRssDataGrid.GetPosts());
            AddNewRowsNews(_contentRssDataGrid.GetNews());
            AddNewRowsPublications(_contentRssDataGrid.GetPublications());
            AddNewRowsAds(_adsRssDataGrid.GetAds());
            labelTimeUpdate.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        // Обновление данных и определение количества новых записей.
        private void UpdateRssDataGrid()
        {
            var newRowsTopics = _forumRssDataGrid.GetTopics();
            var newRowsPosts = _forumRssDataGrid.GetPosts();
            var newRowsNews = _contentRssDataGrid.GetNews();
            var newRowsPublications = _contentRssDataGrid.GetPublications();
            var newRowsAds = _adsRssDataGrid.GetAds();
            var haveUpdate = 0;

            if (Settings.Default.TrackEventTopics && _notifyChangeRss.CheckTopics(dataGridViewTopics.Rows[0], newRowsTopics) > 0)
            {
                haveUpdate++;
                labelNewTopicsCount.Text = _notifyChangeRss.NewTopicsCount.ToString();
                labelNewTopicsCount.ForeColor = Color.Red;
                AddNewRowsTopics(newRowsTopics);
            }

            if (Settings.Default.TrackEventPosts && _notifyChangeRss.CheckPosts(dataGridViewPosts.Rows[0], newRowsPosts) > 0)
            {
                haveUpdate++;
                labelNewPostsCount.Text = _notifyChangeRss.NewPostsCount.ToString();
                labelNewPostsCount.ForeColor = Color.Red;
                AddNewRowsPosts(newRowsPosts);
            }

            if (Settings.Default.TrackEventNews && _notifyChangeRss.CheckNews(dataGridViewNews.Rows[0], newRowsNews) > 0)
            {
                haveUpdate++;
                labelNewsCount.Text = _notifyChangeRss.NewsCount.ToString();
                labelNewsCount.ForeColor = Color.Red;
                AddNewRowsNews(newRowsNews);
            }

            if (Settings.Default.TrackEventPublications && _notifyChangeRss.CheckPublications(dataGridViewPublications.Rows[0], newRowsPublications) > 0)
            {
                haveUpdate++;
                labelNewPublicationsCount.Text = _notifyChangeRss.NewPublicationsCount.ToString();
                labelNewPublicationsCount.ForeColor = Color.Red;
                AddNewRowsPublications(newRowsPublications);
            }

            if (Settings.Default.TrackEventAds && _notifyChangeRss.CheckAds(dataGridViewAds.Rows[0], newRowsAds) > 0)
            {
                haveUpdate++;
                labelNewAdsCount.Text = _notifyChangeRss.NewAdsCount.ToString();
                labelNewAdsCount.ForeColor = Color.Red;
                AddNewRowsAds(newRowsAds);
            }

            labelTimeUpdate.Text = DateTime.Now.ToString("HH:mm:ss");

            if (Settings.Default.SoundNotification && haveUpdate > 0)
            {
                _notifySound.Play();
            }
        }

        // Добавление новых строк в DataGridView.
        //
        private void AddNewRowsTopics(List<DataGridViewRow> newRows)
        {
            dataGridViewTopics.Rows.Clear();
            dataGridViewTopics.Rows.AddRange(newRows.ToArray());
        }

        private void AddNewRowsPosts(List<DataGridViewRow> newRows)
        {
            dataGridViewPosts.Rows.Clear();
            dataGridViewPosts.Rows.AddRange(newRows.ToArray());
        }

        private void AddNewRowsNews(List<DataGridViewRow> newRows)
        {
            dataGridViewNews.Rows.Clear();
            dataGridViewNews.Rows.AddRange(newRows.ToArray());
        }

        private void AddNewRowsPublications(List<DataGridViewRow> newRows)
        {
            dataGridViewPublications.Rows.Clear();
            dataGridViewPublications.Rows.AddRange(newRows.ToArray());
        }

        private void AddNewRowsAds(List<DataGridViewRow> newRows)
        {
            dataGridViewAds.Rows.Clear();
            dataGridViewAds.Rows.AddRange(newRows.ToArray());
        }

        // Пункт меню "настройки".
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ipCheckerSettings = new IPCheckerSettings();
            ipCheckerSettings.UpdateSettings += _ipCheckerSettings_UpdateSettings;
            ipCheckerSettings.Show();
        }

        // Обработчик события настроек.
        void _ipCheckerSettings_UpdateSettings(object sender, EventArgs e)
        {
            SetSettings();
        }

        // Сворачивание программы кликом по иконке в трее.
        private void notifyIconIP_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
                {
                    _OldFormState = WindowState;
                    WindowState = FormWindowState.Minimized;
                }
                else
                {
                    Show();
                    WindowState = _OldFormState;
                }
            }
        }

    }
}
