namespace IPChecker
{
    partial class IPCheckerSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxSoundNotification = new System.Windows.Forms.CheckBox();
            this.checkBoxPopUpNotifications = new System.Windows.Forms.CheckBox();
            this.checkBoxIntervalChecking = new System.Windows.Forms.CheckBox();
            this.comboBoxMinutes = new System.Windows.Forms.ComboBox();
            this.labelMinutes = new System.Windows.Forms.Label();
            this.checkBoxRunSystemStart = new System.Windows.Forms.CheckBox();
            this.groupBoxTrackEvents = new System.Windows.Forms.GroupBox();
            this.checkBoxAds = new System.Windows.Forms.CheckBox();
            this.checkBoxPublications = new System.Windows.Forms.CheckBox();
            this.checkBoxNews = new System.Windows.Forms.CheckBox();
            this.checkBoxPosts = new System.Windows.Forms.CheckBox();
            this.checkBoxTopics = new System.Windows.Forms.CheckBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxTrackEvents.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxSoundNotification
            // 
            this.checkBoxSoundNotification.AutoSize = true;
            this.checkBoxSoundNotification.Location = new System.Drawing.Point(12, 43);
            this.checkBoxSoundNotification.Name = "checkBoxSoundNotification";
            this.checkBoxSoundNotification.Size = new System.Drawing.Size(144, 17);
            this.checkBoxSoundNotification.TabIndex = 0;
            this.checkBoxSoundNotification.Text = "Звуковое уведомление";
            this.checkBoxSoundNotification.UseVisualStyleBackColor = true;
            // 
            // checkBoxPopUpNotifications
            // 
            this.checkBoxPopUpNotifications.AutoSize = true;
            this.checkBoxPopUpNotifications.Enabled = false;
            this.checkBoxPopUpNotifications.Location = new System.Drawing.Point(12, 66);
            this.checkBoxPopUpNotifications.Name = "checkBoxPopUpNotifications";
            this.checkBoxPopUpNotifications.Size = new System.Drawing.Size(170, 17);
            this.checkBoxPopUpNotifications.TabIndex = 1;
            this.checkBoxPopUpNotifications.Text = "Всплывающие уведомления";
            this.checkBoxPopUpNotifications.UseVisualStyleBackColor = true;
            // 
            // checkBoxIntervalChecking
            // 
            this.checkBoxIntervalChecking.AutoSize = true;
            this.checkBoxIntervalChecking.Location = new System.Drawing.Point(12, 89);
            this.checkBoxIntervalChecking.Name = "checkBoxIntervalChecking";
            this.checkBoxIntervalChecking.Size = new System.Drawing.Size(149, 17);
            this.checkBoxIntervalChecking.TabIndex = 2;
            this.checkBoxIntervalChecking.Text = "Проверка с интервалом";
            this.checkBoxIntervalChecking.UseVisualStyleBackColor = true;
            this.checkBoxIntervalChecking.CheckedChanged += new System.EventHandler(this.checkBoxIntervalChecking_CheckedChanged);
            // 
            // comboBoxMinutes
            // 
            this.comboBoxMinutes.FormattingEnabled = true;
            this.comboBoxMinutes.Location = new System.Drawing.Point(164, 87);
            this.comboBoxMinutes.Name = "comboBoxMinutes";
            this.comboBoxMinutes.Size = new System.Drawing.Size(43, 21);
            this.comboBoxMinutes.TabIndex = 3;
            // 
            // labelMinutes
            // 
            this.labelMinutes.AutoSize = true;
            this.labelMinutes.Location = new System.Drawing.Point(213, 90);
            this.labelMinutes.Name = "labelMinutes";
            this.labelMinutes.Size = new System.Drawing.Size(37, 13);
            this.labelMinutes.TabIndex = 4;
            this.labelMinutes.Text = "минут";
            // 
            // checkBoxRunSystemStart
            // 
            this.checkBoxRunSystemStart.AutoSize = true;
            this.checkBoxRunSystemStart.Location = new System.Drawing.Point(12, 20);
            this.checkBoxRunSystemStart.Name = "checkBoxRunSystemStart";
            this.checkBoxRunSystemStart.Size = new System.Drawing.Size(185, 17);
            this.checkBoxRunSystemStart.TabIndex = 5;
            this.checkBoxRunSystemStart.Text = "Запускать при старте системы";
            this.checkBoxRunSystemStart.UseVisualStyleBackColor = true;
            // 
            // groupBoxTrackEvents
            // 
            this.groupBoxTrackEvents.Controls.Add(this.checkBoxAds);
            this.groupBoxTrackEvents.Controls.Add(this.checkBoxPublications);
            this.groupBoxTrackEvents.Controls.Add(this.checkBoxNews);
            this.groupBoxTrackEvents.Controls.Add(this.checkBoxPosts);
            this.groupBoxTrackEvents.Controls.Add(this.checkBoxTopics);
            this.groupBoxTrackEvents.Location = new System.Drawing.Point(12, 123);
            this.groupBoxTrackEvents.Name = "groupBoxTrackEvents";
            this.groupBoxTrackEvents.Size = new System.Drawing.Size(238, 146);
            this.groupBoxTrackEvents.TabIndex = 6;
            this.groupBoxTrackEvents.TabStop = false;
            this.groupBoxTrackEvents.Text = "Отслеживать события";
            // 
            // checkBoxAds
            // 
            this.checkBoxAds.AutoSize = true;
            this.checkBoxAds.Location = new System.Drawing.Point(6, 115);
            this.checkBoxAds.Name = "checkBoxAds";
            this.checkBoxAds.Size = new System.Drawing.Size(89, 17);
            this.checkBoxAds.TabIndex = 4;
            this.checkBoxAds.Text = "Объявления";
            this.checkBoxAds.UseVisualStyleBackColor = true;
            // 
            // checkBoxPublications
            // 
            this.checkBoxPublications.AutoSize = true;
            this.checkBoxPublications.Location = new System.Drawing.Point(6, 92);
            this.checkBoxPublications.Name = "checkBoxPublications";
            this.checkBoxPublications.Size = new System.Drawing.Size(87, 17);
            this.checkBoxPublications.TabIndex = 3;
            this.checkBoxPublications.Text = "Публикации";
            this.checkBoxPublications.UseVisualStyleBackColor = true;
            // 
            // checkBoxNews
            // 
            this.checkBoxNews.AutoSize = true;
            this.checkBoxNews.Location = new System.Drawing.Point(6, 69);
            this.checkBoxNews.Name = "checkBoxNews";
            this.checkBoxNews.Size = new System.Drawing.Size(69, 17);
            this.checkBoxNews.TabIndex = 2;
            this.checkBoxNews.Text = "Новости";
            this.checkBoxNews.UseVisualStyleBackColor = true;
            // 
            // checkBoxPosts
            // 
            this.checkBoxPosts.AutoSize = true;
            this.checkBoxPosts.Location = new System.Drawing.Point(6, 46);
            this.checkBoxPosts.Name = "checkBoxPosts";
            this.checkBoxPosts.Size = new System.Drawing.Size(78, 17);
            this.checkBoxPosts.TabIndex = 1;
            this.checkBoxPosts.Text = "Собщения";
            this.checkBoxPosts.UseVisualStyleBackColor = true;
            // 
            // checkBoxTopics
            // 
            this.checkBoxTopics.AutoSize = true;
            this.checkBoxTopics.Location = new System.Drawing.Point(6, 23);
            this.checkBoxTopics.Name = "checkBoxTopics";
            this.checkBoxTopics.Size = new System.Drawing.Size(55, 17);
            this.checkBoxTopics.TabIndex = 0;
            this.checkBoxTopics.Text = "Темы";
            this.checkBoxTopics.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(42, 286);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 7;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(141, 286);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // IPCheckerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(262, 325);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBoxTrackEvents);
            this.Controls.Add(this.checkBoxRunSystemStart);
            this.Controls.Add(this.labelMinutes);
            this.Controls.Add(this.comboBoxMinutes);
            this.Controls.Add(this.checkBoxIntervalChecking);
            this.Controls.Add(this.checkBoxPopUpNotifications);
            this.Controls.Add(this.checkBoxSoundNotification);
            this.Name = "IPCheckerSettings";
            this.Text = "Настройки";
            this.groupBoxTrackEvents.ResumeLayout(false);
            this.groupBoxTrackEvents.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxSoundNotification;
        private System.Windows.Forms.CheckBox checkBoxPopUpNotifications;
        private System.Windows.Forms.CheckBox checkBoxIntervalChecking;
        private System.Windows.Forms.ComboBox comboBoxMinutes;
        private System.Windows.Forms.Label labelMinutes;
        private System.Windows.Forms.CheckBox checkBoxRunSystemStart;
        private System.Windows.Forms.GroupBox groupBoxTrackEvents;
        private System.Windows.Forms.CheckBox checkBoxAds;
        private System.Windows.Forms.CheckBox checkBoxPublications;
        private System.Windows.Forms.CheckBox checkBoxNews;
        private System.Windows.Forms.CheckBox checkBoxPosts;
        private System.Windows.Forms.CheckBox checkBoxTopics;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}