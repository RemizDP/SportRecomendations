namespace Приложение_консультант_по_подбору_спортивных_секций
{
    partial class EditUserInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditUserInfo));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            HeightBox = new MaskedTextBox();
            WeightBox = new MaskedTextBox();
            AgeBox = new MaskedTextBox();
            SexBox = new MaskedTextBox();
            LocationBox = new TextBox();
            label7 = new Label();
            label8 = new Label();
            SaveButton = new Button();
            AchieveButton = new Button();
            AchievesBox = new ListBox();
            label9 = new Label();
            label10 = new Label();
            NameBox = new TextBox();
            BMILabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(45, 170);
            label1.Name = "label1";
            label1.Size = new Size(56, 30);
            label1.TabIndex = 0;
            label1.Text = "Рост";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(45, 221);
            label2.Name = "label2";
            label2.Size = new Size(46, 30);
            label2.TabIndex = 1;
            label2.Text = "Вес";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(45, 272);
            label3.Name = "label3";
            label3.Size = new Size(88, 30);
            label3.TabIndex = 3;
            label3.Text = "Возраст";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(45, 327);
            label4.Name = "label4";
            label4.Size = new Size(114, 30);
            label4.TabIndex = 2;
            label4.Text = "Пол (M/Ж)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(45, 372);
            label5.Name = "label5";
            label5.Size = new Size(183, 30);
            label5.TabIndex = 5;
            label5.Text = "Местоположение";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(127, 34);
            label6.Name = "label6";
            label6.Size = new Size(412, 32);
            label6.TabIndex = 11;
            label6.Text = "Информация о пользователе";
            // 
            // HeightBox
            // 
            HeightBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            HeightBox.Location = new Point(151, 177);
            HeightBox.Mask = "000";
            HeightBox.Name = "HeightBox";
            HeightBox.Size = new Size(51, 23);
            HeightBox.TabIndex = 2;
            HeightBox.TextAlign = HorizontalAlignment.Center;
            // 
            // WeightBox
            // 
            WeightBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            WeightBox.Location = new Point(151, 228);
            WeightBox.Mask = "900";
            WeightBox.Name = "WeightBox";
            WeightBox.Size = new Size(51, 23);
            WeightBox.TabIndex = 3;
            WeightBox.TextAlign = HorizontalAlignment.Center;
            // 
            // AgeBox
            // 
            AgeBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AgeBox.Location = new Point(151, 279);
            AgeBox.Mask = "90";
            AgeBox.Name = "AgeBox";
            AgeBox.Size = new Size(51, 23);
            AgeBox.TabIndex = 4;
            AgeBox.Text = "0";
            AgeBox.TextAlign = HorizontalAlignment.Center;
            // 
            // SexBox
            // 
            SexBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            SexBox.Location = new Point(151, 334);
            SexBox.Mask = "L";
            SexBox.Name = "SexBox";
            SexBox.Size = new Size(51, 23);
            SexBox.TabIndex = 5;
            SexBox.Text = "M";
            SexBox.TextAlign = HorizontalAlignment.Center;
            // 
            // LocationBox
            // 
            LocationBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            LocationBox.Location = new Point(234, 379);
            LocationBox.Name = "LocationBox";
            LocationBox.Size = new Size(158, 23);
            LocationBox.TabIndex = 6;
            LocationBox.Text = "Неизвестно";
            LocationBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(208, 170);
            label7.Name = "label7";
            label7.Size = new Size(38, 30);
            label7.TabIndex = 17;
            label7.Text = "см";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(208, 221);
            label8.Name = "label8";
            label8.Size = new Size(31, 30);
            label8.TabIndex = 18;
            label8.Text = "кг";
            // 
            // SaveButton
            // 
            SaveButton.BackgroundImage = (Image)resources.GetObject("SaveButton.BackgroundImage");
            SaveButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            SaveButton.ForeColor = SystemColors.Window;
            SaveButton.Location = new Point(45, 432);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(321, 59);
            SaveButton.TabIndex = 7;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // AchieveButton
            // 
            AchieveButton.BackgroundImage = (Image)resources.GetObject("AchieveButton.BackgroundImage");
            AchieveButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            AchieveButton.ForeColor = SystemColors.Window;
            AchieveButton.Location = new Point(396, 432);
            AchieveButton.Name = "AchieveButton";
            AchieveButton.Size = new Size(254, 59);
            AchieveButton.TabIndex = 8;
            AchieveButton.Text = "Добавить достижение";
            AchieveButton.UseVisualStyleBackColor = true;
            AchieveButton.Click += AchieveButton_Click;
            // 
            // AchievesBox
            // 
            AchievesBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AchievesBox.FormattingEnabled = true;
            AchievesBox.ItemHeight = 15;
            AchievesBox.Location = new Point(396, 160);
            AchievesBox.Name = "AchievesBox";
            AchievesBox.Size = new Size(254, 184);
            AchievesBox.Sorted = true;
            AchievesBox.TabIndex = 21;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(454, 120);
            label9.Name = "label9";
            label9.Size = new Size(133, 30);
            label9.TabIndex = 22;
            label9.Text = "Достижения";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(45, 120);
            label10.Name = "label10";
            label10.Size = new Size(55, 30);
            label10.TabIndex = 24;
            label10.Text = "Имя";
            // 
            // NameBox
            // 
            NameBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            NameBox.Location = new Point(139, 117);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(253, 23);
            NameBox.TabIndex = 1;
            NameBox.Text = "Неизвестно";
            NameBox.TextAlign = HorizontalAlignment.Center;
            // 
            // BMILabel
            // 
            BMILabel.AutoSize = true;
            BMILabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            BMILabel.Location = new Point(245, 202);
            BMILabel.Name = "BMILabel";
            BMILabel.Size = new Size(70, 30);
            BMILabel.TabIndex = 26;
            BMILabel.Text = "ИМТ: ";
            // 
            // EditUserInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(662, 524);
            ControlBox = false;
            Controls.Add(BMILabel);
            Controls.Add(NameBox);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(AchievesBox);
            Controls.Add(AchieveButton);
            Controls.Add(SaveButton);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(LocationBox);
            Controls.Add(SexBox);
            Controls.Add(AgeBox);
            Controls.Add(WeightBox);
            Controls.Add(HeightBox);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditUserInfo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Информация о пользователе";
            FormClosing += EditUserInfo_FormClosing;
            Load += EditUserInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private MaskedTextBox HeightBox;
        private MaskedTextBox WeightBox;
        private MaskedTextBox AgeBox;
        private MaskedTextBox SexBox;
        private TextBox LocationBox;
        private Label label7;
        private Label label8;
        private Button SaveButton;
        private Label label9;
        private Label label10;
        private TextBox NameBox;
        private Label BMILabel;
        public ListBox AchievesBox;
        public Button AchieveButton;
    }
}