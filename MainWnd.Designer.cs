namespace Приложение_консультант_по_подбору_спортивных_секций
{
    partial class MainWnd
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWnd));
            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            закрытьПрограммуToolStripMenuItem = new ToolStripMenuItem();
            helpMenu = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolTip = new ToolTip(components);
            WelcomeLabel = new Label();
            ProfileButton = new Button();
            UpdateRecommendationsButton = new Button();
            PersonalLabel = new Label();
            TrainModelButton = new Button();
            UserFilterBox = new GroupBox();
            L1NormButton = new RadioButton();
            PearsonButton = new RadioButton();
            SectionFilterBox = new GroupBox();
            RegressionButton = new RadioButton();
            ContentFilterButton = new RadioButton();
            OnlineFilterBox = new CheckBox();
            MLRecommendationsBox = new CheckBox();
            ChangePasswordButton = new Button();
            button2 = new Button();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            UserFilterBox.SuspendLayout();
            SectionFilterBox.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu, helpMenu });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 2, 0, 2);
            menuStrip.Size = new Size(1823, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem, закрытьПрограммуToolStripMenuItem });
            fileMenu.ImageTransparentColor = SystemColors.ActiveBorder;
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(37, 20);
            fileMenu.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(186, 22);
            exitToolStripMenuItem.Text = "Выйти из системы";
            exitToolStripMenuItem.Click += ExitToolsStripMenuItem_Click;
            // 
            // закрытьПрограммуToolStripMenuItem
            // 
            закрытьПрограммуToolStripMenuItem.Name = "закрытьПрограммуToolStripMenuItem";
            закрытьПрограммуToolStripMenuItem.Size = new Size(186, 22);
            закрытьПрограммуToolStripMenuItem.Text = "Закрыть программу";
            закрытьПрограммуToolStripMenuItem.Click += закрытьПрограммуToolStripMenuItem_Click;
            // 
            // helpMenu
            // 
            helpMenu.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpMenu.Name = "helpMenu";
            helpMenu.Size = new Size(44, 20);
            helpMenu.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(131, 22);
            aboutToolStripMenuItem.Text = "&About ... ...";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 834);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(1823, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(39, 17);
            toolStripStatusLabel.Text = "Status";
            // 
            // WelcomeLabel
            // 
            WelcomeLabel.AutoSize = true;
            WelcomeLabel.Font = new Font("Arial", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            WelcomeLabel.Location = new Point(700, 38);
            WelcomeLabel.Name = "WelcomeLabel";
            WelcomeLabel.Size = new Size(0, 32);
            WelcomeLabel.TabIndex = 4;
            WelcomeLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // ProfileButton
            // 
            ProfileButton.BackgroundImage = (Image)resources.GetObject("ProfileButton.BackgroundImage");
            ProfileButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ProfileButton.Location = new Point(0, 25);
            ProfileButton.Name = "ProfileButton";
            ProfileButton.Size = new Size(270, 70);
            ProfileButton.TabIndex = 6;
            ProfileButton.Text = "Профиль пользователя";
            ProfileButton.TextAlign = ContentAlignment.MiddleRight;
            ProfileButton.UseVisualStyleBackColor = true;
            ProfileButton.Click += ProfileButton_Click;
            // 
            // UpdateRecommendationsButton
            // 
            UpdateRecommendationsButton.BackgroundImage = (Image)resources.GetObject("UpdateRecommendationsButton.BackgroundImage");
            UpdateRecommendationsButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            UpdateRecommendationsButton.Location = new Point(0, 100);
            UpdateRecommendationsButton.Name = "UpdateRecommendationsButton";
            UpdateRecommendationsButton.Size = new Size(270, 70);
            UpdateRecommendationsButton.TabIndex = 7;
            UpdateRecommendationsButton.Text = "Обновить рекомендации";
            UpdateRecommendationsButton.TextAlign = ContentAlignment.MiddleRight;
            UpdateRecommendationsButton.UseVisualStyleBackColor = true;
            UpdateRecommendationsButton.Click += UpdateRecommendationsButton_Click;
            // 
            // PersonalLabel
            // 
            PersonalLabel.AutoSize = true;
            PersonalLabel.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point);
            PersonalLabel.ForeColor = SystemColors.InfoText;
            PersonalLabel.Location = new Point(276, 68);
            PersonalLabel.Name = "PersonalLabel";
            PersonalLabel.Size = new Size(189, 29);
            PersonalLabel.TabIndex = 11;
            PersonalLabel.Text = "Подходит вам:";
            // 
            // TrainModelButton
            // 
            TrainModelButton.BackgroundImage = (Image)resources.GetObject("TrainModelButton.BackgroundImage");
            TrainModelButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TrainModelButton.Location = new Point(0, 176);
            TrainModelButton.Name = "TrainModelButton";
            TrainModelButton.Size = new Size(270, 70);
            TrainModelButton.TabIndex = 12;
            TrainModelButton.Text = "Обучить модель МО";
            TrainModelButton.TextAlign = ContentAlignment.MiddleRight;
            TrainModelButton.UseVisualStyleBackColor = true;
            TrainModelButton.Click += TrainModelButton_Click;
            // 
            // UserFilterBox
            // 
            UserFilterBox.Controls.Add(L1NormButton);
            UserFilterBox.Controls.Add(PearsonButton);
            UserFilterBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            UserFilterBox.Location = new Point(0, 252);
            UserFilterBox.Name = "UserFilterBox";
            UserFilterBox.Size = new Size(270, 105);
            UserFilterBox.TabIndex = 13;
            UserFilterBox.TabStop = false;
            UserFilterBox.Text = "Режим фильтрации пользователей";
            // 
            // L1NormButton
            // 
            L1NormButton.AutoSize = true;
            L1NormButton.Location = new Point(12, 26);
            L1NormButton.Name = "L1NormButton";
            L1NormButton.Size = new Size(94, 24);
            L1NormButton.TabIndex = 17;
            L1NormButton.TabStop = true;
            L1NormButton.Text = "L1-норма";
            L1NormButton.UseVisualStyleBackColor = true;
            // 
            // PearsonButton
            // 
            PearsonButton.AutoSize = true;
            PearsonButton.Checked = true;
            PearsonButton.Location = new Point(12, 56);
            PearsonButton.Name = "PearsonButton";
            PearsonButton.Size = new Size(179, 24);
            PearsonButton.TabIndex = 18;
            PearsonButton.TabStop = true;
            PearsonButton.Text = "Корреляция Пирсона";
            PearsonButton.UseVisualStyleBackColor = true;
            // 
            // SectionFilterBox
            // 
            SectionFilterBox.Controls.Add(RegressionButton);
            SectionFilterBox.Controls.Add(ContentFilterButton);
            SectionFilterBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SectionFilterBox.Location = new Point(0, 419);
            SectionFilterBox.Name = "SectionFilterBox";
            SectionFilterBox.Size = new Size(270, 86);
            SectionFilterBox.TabIndex = 14;
            SectionFilterBox.TabStop = false;
            SectionFilterBox.Text = "Режим фильтрации секций";
            // 
            // RegressionButton
            // 
            RegressionButton.AutoSize = true;
            RegressionButton.Checked = true;
            RegressionButton.Location = new Point(12, 56);
            RegressionButton.Name = "RegressionButton";
            RegressionButton.Size = new Size(97, 24);
            RegressionButton.TabIndex = 20;
            RegressionButton.TabStop = true;
            RegressionButton.Text = "Регрессия";
            RegressionButton.UseVisualStyleBackColor = true;
            // 
            // ContentFilterButton
            // 
            ContentFilterButton.AutoSize = true;
            ContentFilterButton.Location = new Point(12, 26);
            ContentFilterButton.Name = "ContentFilterButton";
            ContentFilterButton.Size = new Size(196, 24);
            ContentFilterButton.TabIndex = 19;
            ContentFilterButton.TabStop = true;
            ContentFilterButton.Text = "Контентная фильтрация";
            ContentFilterButton.UseVisualStyleBackColor = true;
            // 
            // OnlineFilterBox
            // 
            OnlineFilterBox.AutoSize = true;
            OnlineFilterBox.Checked = true;
            OnlineFilterBox.CheckState = CheckState.Checked;
            OnlineFilterBox.Location = new Point(17, 394);
            OnlineFilterBox.Name = "OnlineFilterBox";
            OnlineFilterBox.Size = new Size(253, 19);
            OnlineFilterBox.TabIndex = 15;
            OnlineFilterBox.Text = "Фильтрация секций в реальном времени";
            OnlineFilterBox.UseVisualStyleBackColor = true;
            OnlineFilterBox.CheckedChanged += OnlineFilterBox_CheckedChanged;
            // 
            // MLRecommendationsBox
            // 
            MLRecommendationsBox.AutoSize = true;
            MLRecommendationsBox.Checked = true;
            MLRecommendationsBox.CheckState = CheckState.Checked;
            MLRecommendationsBox.Location = new Point(48, 511);
            MLRecommendationsBox.Name = "MLRecommendationsBox";
            MLRecommendationsBox.Size = new Size(222, 19);
            MLRecommendationsBox.TabIndex = 16;
            MLRecommendationsBox.Text = "Использовать машинное обучение";
            MLRecommendationsBox.UseVisualStyleBackColor = true;
            // 
            // ChangePasswordButton
            // 
            ChangePasswordButton.BackgroundImage = (Image)resources.GetObject("ChangePasswordButton.BackgroundImage");
            ChangePasswordButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ChangePasswordButton.Location = new Point(0, 547);
            ChangePasswordButton.Name = "ChangePasswordButton";
            ChangePasswordButton.Size = new Size(270, 70);
            ChangePasswordButton.TabIndex = 17;
            ChangePasswordButton.Text = "Сменить пароль";
            ChangePasswordButton.TextAlign = ContentAlignment.MiddleRight;
            ChangePasswordButton.UseVisualStyleBackColor = true;
            ChangePasswordButton.Click += ChangePasswordButton_Click;
            // 
            // button2
            // 
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(0, 623);
            button2.Name = "button2";
            button2.Size = new Size(270, 70);
            button2.TabIndex = 18;
            button2.Text = "Панель аналитики";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = true;
            // 
            // MainWnd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1823, 856);
            Controls.Add(button2);
            Controls.Add(ChangePasswordButton);
            Controls.Add(MLRecommendationsBox);
            Controls.Add(OnlineFilterBox);
            Controls.Add(SectionFilterBox);
            Controls.Add(UserFilterBox);
            Controls.Add(TrainModelButton);
            Controls.Add(PersonalLabel);
            Controls.Add(UpdateRecommendationsButton);
            Controls.Add(ProfileButton);
            Controls.Add(WelcomeLabel);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainWnd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Рекомендации";
            FormClosing += MainWnd_FormClosing;
            Load += MainWnd_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            UserFilterBox.ResumeLayout(false);
            UserFilterBox.PerformLayout();
            SectionFilterBox.ResumeLayout(false);
            SectionFilterBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion


        private MenuStrip menuStrip;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpMenu;
        private ToolTip toolTip;
        private ToolStripMenuItem закрытьПрограммуToolStripMenuItem;
        public Label WelcomeLabel;
        public Button ProfileButton;
        public Button UpdateRecommendationsButton;
        private Label PersonalLabel;
        public Button TrainModelButton;
        private GroupBox UserFilterBox;
        private GroupBox SectionFilterBox;
        private RadioButton L1NormButton;
        private RadioButton PearsonButton;
        private RadioButton RegressionButton;
        private RadioButton ContentFilterButton;
        private CheckBox OnlineFilterBox;
        private CheckBox MLRecommendationsBox;
        public Button ChangePasswordButton;
        public Button button2;
    }
}



