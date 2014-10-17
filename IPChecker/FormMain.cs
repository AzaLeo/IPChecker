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

        private void FormMain_Load(object sender, EventArgs e)
        {
            toolTipMain.SetToolTip(buttonCleanCount, "Сбросить счетчики");
            toolTipMain.SetToolTip(buttonUpdate, "Обновить данные");
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
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView d = sender as DataGridView;

            if (e.ColumnIndex == 0 && d != null)
            {
                DataGridViewCell clickCell = new DataGridViewLinkCell();

                switch (d.Name)
                {
                    case "dataGridViewTopics":
                        clickCell = dataGridViewTopics.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        labelNewTopicsCount.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                        labelNewTopicsCount.Text = "0";
                        break;
                    case "dataGridViewPosts":
                        clickCell = dataGridViewPosts.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        labelNewPostsCount.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                        labelNewPostsCount.Text = "0";
                        break;
                    case "dataGridViewNews":
                        clickCell = dataGridViewNews.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        labelNewsCount.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                        labelNewsCount.Text = "0";
                        break;
                    case "dataGridViewPublications":
                        clickCell = dataGridViewPublications.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        labelNewPublicationsCount.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                        labelNewPublicationsCount.Text = "0";
                        break;
                    case "dataGridViewPoliceNews":
                        clickCell = dataGridViewPoliceNews.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        labelPoliceNewsCount.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                        labelPoliceNewsCount.Text = "0";
                        break;
                    case "dataGridViewTaxNews":
                        clickCell = dataGridViewTaxNews.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        labelTaxNewsCount.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                        labelTaxNewsCount.Text = "0";
                        break;
                    case "dataGridViewAds":
                        clickCell = dataGridViewAds.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        labelNewAdsCount.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                        labelNewAdsCount.Text = "0";
                        break;
                }
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
            AddNewRowsPoliceNews(_contentRssDataGrid.GetPoliceNews());
            AddNewRowsTaxNews(_contentRssDataGrid.GetTaxNews());
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
            var newRowsPoliceNews = _contentRssDataGrid.GetPoliceNews();
            var newRowsTaxNews = _contentRssDataGrid.GetTaxNews();
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
                labelNewPostsCount.Text = haveUpdate.ToString();
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

            if (Settings.Default.TrackEventPoliceNews && _notifyChangeRss.CheckPoliceNews(dataGridViewPoliceNews.Rows[0], newRowsPoliceNews) > 0)
            {
                haveUpdate++;
                labelPoliceNewsCount.Text = _notifyChangeRss.NewPoliceCount.ToString();
                labelPoliceNewsCount.ForeColor = Color.Red;
                AddNewRowsPoliceNews(newRowsPoliceNews);
            }

            if (Settings.Default.TrackEventTaxNews && _notifyChangeRss.CheckTaxNews(dataGridViewTaxNews.Rows[0], newRowsTaxNews) > 0)
            {
                haveUpdate++;
                labelTaxNewsCount.Text = _notifyChangeRss.NewTaxCount.ToString();
                labelTaxNewsCount.ForeColor = Color.Red;
                AddNewRowsTaxNews(newRowsTaxNews);
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

        private void AddNewRowsPoliceNews(List<DataGridViewRow> newRows)
        {
            dataGridViewPoliceNews.Rows.Clear();
            dataGridViewPoliceNews.Rows.AddRange(newRows.ToArray());
        }

        private void AddNewRowsTaxNews(List<DataGridViewRow> newRows)
        {
            dataGridViewTaxNews.Rows.Clear();
            dataGridViewTaxNews.Rows.AddRange(newRows.ToArray());
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

        // Обнуление счетчиков событий.
        private void buttonCleanCount_Click(object sender, EventArgs e)
        {
            // Возвращение цвета.
            labelNewTopicsCount.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            labelNewPostsCount.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            labelNewsCount.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            labelNewPublicationsCount.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            labelPoliceNewsCount.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            labelTaxNewsCount.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            labelNewAdsCount.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            // Обнуление.
            labelNewTopicsCount.Text = "0";
            labelNewPostsCount.Text = "0";
            labelNewsCount.Text = "0";
            labelNewPublicationsCount.Text = "0";
            labelPoliceNewsCount.Text = "0";
            labelTaxNewsCount.Text = "0";
            labelNewAdsCount.Text = "0";
        }
    }
}