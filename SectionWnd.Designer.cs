namespace Приложение_консультант_по_подбору_спортивных_секций
{
    partial class SectionWnd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SectionWnd));
            RequestButton = new Button();
            WishListBox = new CheckBox();
            RequestBox = new TextBox();
            label1 = new Label();
            RateBox = new ComboBox();
            StarLabel = new Label();
            SuspendLayout();
            // 
            // RequestButton
            // 
            RequestButton.BackgroundImage = (Image)resources.GetObject("RequestButton.BackgroundImage");
            RequestButton.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            RequestButton.ForeColor = SystemColors.Window;
            RequestButton.Location = new Point(12, 620);
            RequestButton.Name = "RequestButton";
            RequestButton.Size = new Size(530, 42);
            RequestButton.TabIndex = 0;
            RequestButton.Text = "Оставить заявку";
            RequestButton.UseVisualStyleBackColor = true;
            RequestButton.Click += RequestButton_Click;
            // 
            // WishListBox
            // 
            WishListBox.AutoSize = true;
            WishListBox.Checked = true;
            WishListBox.CheckState = CheckState.Checked;
            WishListBox.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            WishListBox.Location = new Point(394, 480);
            WishListBox.Name = "WishListBox";
            WishListBox.Size = new Size(115, 22);
            WishListBox.TabIndex = 1;
            WishListBox.Text = "В желаемое";
            WishListBox.UseVisualStyleBackColor = true;
            WishListBox.CheckedChanged += WishListBox_CheckedChanged;
            // 
            // RequestBox
            // 
            RequestBox.Location = new Point(12, 526);
            RequestBox.Multiline = true;
            RequestBox.Name = "RequestBox";
            RequestBox.Size = new Size(530, 88);
            RequestBox.TabIndex = 2;
            RequestBox.Text = "Напишите здесь текст заявки";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 481);
            label1.Name = "label1";
            label1.Size = new Size(191, 18);
            label1.TabIndex = 3;
            label1.Text = "Поставьте оценку секции";
            // 
            // RateBox
            // 
            RateBox.FormattingEnabled = true;
            RateBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            RateBox.Location = new Point(209, 481);
            RateBox.Name = "RateBox";
            RateBox.Size = new Size(55, 23);
            RateBox.TabIndex = 4;
            // 
            // StarLabel
            // 
            StarLabel.AutoSize = true;
            StarLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            StarLabel.Location = new Point(504, 9);
            StarLabel.Name = "StarLabel";
            StarLabel.Size = new Size(0, 30);
            StarLabel.TabIndex = 5;
            // 
            // SectionWnd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(554, 685);
            Controls.Add(StarLabel);
            Controls.Add(RateBox);
            Controls.Add(label1);
            Controls.Add(RequestBox);
            Controls.Add(WishListBox);
            Controls.Add(RequestButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SectionWnd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "О секции";
            FormClosing += SectionWnd_FormClosing;
            Load += SectionWnd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RequestButton;
        private CheckBox WishListBox;
        private TextBox RequestBox;
        private Label label1;
        private ComboBox RateBox;
        public Label StarLabel;
    }
}