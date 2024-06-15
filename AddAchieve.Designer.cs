namespace Приложение_консультант_по_подбору_спортивных_секций
{
    partial class AddAchieve
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAchieve));
            SportTypeBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            CategoryLabel = new Label();
            PlaceLabel = new Label();
            SportBox = new ComboBox();
            AchievementTypeBox = new ComboBox();
            CategoryBox = new ComboBox();
            DateBox = new DateTimePicker();
            label5 = new Label();
            PlaceBox = new ComboBox();
            SaveButton = new Button();
            CloseButton = new Button();
            NameBox = new TextBox();
            SuspendLayout();
            // 
            // SportTypeBox
            // 
            SportTypeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SportTypeBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SportTypeBox.FormattingEnabled = true;
            SportTypeBox.Location = new Point(400, 38);
            SportTypeBox.Name = "SportTypeBox";
            SportTypeBox.Size = new Size(278, 29);
            SportTypeBox.TabIndex = 0;
            SportTypeBox.SelectedIndexChanged += SportTypeBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 34);
            label1.Name = "label1";
            label1.Size = new Size(370, 30);
            label1.TabIndex = 1;
            label1.Text = "Тип спорта по олимпийской системе";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 85);
            label2.Name = "label2";
            label2.Size = new Size(120, 30);
            label2.TabIndex = 2;
            label2.Text = "Вид спорта";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 139);
            label3.Name = "label3";
            label3.Size = new Size(170, 30);
            label3.TabIndex = 3;
            label3.Text = "Тип достижения";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 186);
            label4.Name = "label4";
            label4.Size = new Size(105, 30);
            label4.TabIndex = 4;
            label4.Text = "Название";
            // 
            // CategoryLabel
            // 
            CategoryLabel.AutoSize = true;
            CategoryLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            CategoryLabel.Location = new Point(12, 230);
            CategoryLabel.Name = "CategoryLabel";
            CategoryLabel.Size = new Size(79, 30);
            CategoryLabel.TabIndex = 5;
            CategoryLabel.Text = "Разряд";
            // 
            // PlaceLabel
            // 
            PlaceLabel.AutoSize = true;
            PlaceLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            PlaceLabel.Location = new Point(12, 230);
            PlaceLabel.Name = "PlaceLabel";
            PlaceLabel.Size = new Size(153, 30);
            PlaceLabel.TabIndex = 6;
            PlaceLabel.Text = "Занятое место";
            // 
            // SportBox
            // 
            SportBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SportBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SportBox.FormattingEnabled = true;
            SportBox.Location = new Point(400, 89);
            SportBox.Name = "SportBox";
            SportBox.Size = new Size(278, 29);
            SportBox.TabIndex = 7;
            // 
            // AchievementTypeBox
            // 
            AchievementTypeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AchievementTypeBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AchievementTypeBox.FormattingEnabled = true;
            AchievementTypeBox.Items.AddRange(new object[] { "Разряд", "Соревнование" });
            AchievementTypeBox.Location = new Point(400, 143);
            AchievementTypeBox.Name = "AchievementTypeBox";
            AchievementTypeBox.Size = new Size(278, 29);
            AchievementTypeBox.TabIndex = 8;
            AchievementTypeBox.SelectedIndexChanged += AchievementTypeBox_SelectedIndexChanged;
            // 
            // CategoryBox
            // 
            CategoryBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CategoryBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CategoryBox.FormattingEnabled = true;
            CategoryBox.Items.AddRange(new object[] { "Мастер спорта (МС)", "Кандидат в мастера спорта (КМС)", "I разряд", "II разряд", "III разряд", "I юношеский разряд", "II юношеский разряд", "III юношеский разряд" });
            CategoryBox.Location = new Point(400, 234);
            CategoryBox.Name = "CategoryBox";
            CategoryBox.Size = new Size(278, 29);
            CategoryBox.TabIndex = 10;
            CategoryBox.SelectedIndexChanged += CategoryBox_SelectedIndexChanged;
            // 
            // DateBox
            // 
            DateBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DateBox.Location = new Point(400, 324);
            DateBox.Name = "DateBox";
            DateBox.Size = new Size(278, 29);
            DateBox.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 323);
            label5.Name = "label5";
            label5.Size = new Size(59, 30);
            label5.TabIndex = 13;
            label5.Text = "Дата";
            // 
            // PlaceBox
            // 
            PlaceBox.DropDownStyle = ComboBoxStyle.DropDownList;
            PlaceBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PlaceBox.FormattingEnabled = true;
            PlaceBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            PlaceBox.Location = new Point(400, 234);
            PlaceBox.Name = "PlaceBox";
            PlaceBox.Size = new Size(278, 29);
            PlaceBox.TabIndex = 14;
            PlaceBox.SelectedIndexChanged += PlaceBox_SelectedIndexChanged;
            // 
            // SaveButton
            // 
            SaveButton.BackColor = SystemColors.WindowFrame;
            SaveButton.BackgroundImage = (Image)resources.GetObject("SaveButton.BackgroundImage");
            SaveButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            SaveButton.ForeColor = SystemColors.Window;
            SaveButton.Location = new Point(12, 375);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(370, 63);
            SaveButton.TabIndex = 15;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click;
            // 
            // CloseButton
            // 
            CloseButton.BackColor = SystemColors.WindowFrame;
            CloseButton.BackgroundImage = (Image)resources.GetObject("CloseButton.BackgroundImage");
            CloseButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            CloseButton.ForeColor = SystemColors.Window;
            CloseButton.Location = new Point(400, 375);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(370, 63);
            CloseButton.TabIndex = 16;
            CloseButton.Text = "Закрыть";
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += CloseButton_Click;
            // 
            // NameBox
            // 
            NameBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            NameBox.Location = new Point(400, 183);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(278, 35);
            NameBox.TabIndex = 17;
            // 
            // AddAchieve
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(NameBox);
            Controls.Add(CloseButton);
            Controls.Add(SaveButton);
            Controls.Add(PlaceBox);
            Controls.Add(label5);
            Controls.Add(DateBox);
            Controls.Add(CategoryBox);
            Controls.Add(AchievementTypeBox);
            Controls.Add(SportBox);
            Controls.Add(PlaceLabel);
            Controls.Add(CategoryLabel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SportTypeBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddAchieve";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Новое достижение";
            FormClosing += AddAchieve_FormClosing;
            Load += AddAchieve_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox SportTypeBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label CategoryLabel;
        private Label PlaceLabel;
        private ComboBox SportBox;
        private ComboBox AchievementTypeBox;
        private ComboBox CategoryBox;
        private DateTimePicker DateBox;
        private Label label5;
        private ComboBox PlaceBox;
        private Button SaveButton;
        private Button CloseButton;
        private TextBox NameBox;
    }
}