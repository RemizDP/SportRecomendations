namespace Приложение_консультант_по_подбору_спортивных_секций
{
    partial class Auth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auth));
            panel1 = new Panel();
            linkLabel1 = new LinkLabel();
            EnterButton = new Button();
            PasswordBox = new TextBox();
            EmailBox = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(EnterButton);
            panel1.Controls.Add(PasswordBox);
            panel1.Controls.Add(EmailBox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(148, 126);
            panel1.Name = "panel1";
            panel1.Size = new Size(447, 379);
            panel1.TabIndex = 0;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(163, 342);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(119, 15);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Зарегистрироваться";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // EnterButton
            // 
            EnterButton.BackColor = SystemColors.Window;
            EnterButton.BackgroundImage = (Image)resources.GetObject("EnterButton.BackgroundImage");
            EnterButton.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            EnterButton.ForeColor = SystemColors.ControlLightLight;
            EnterButton.Location = new Point(47, 292);
            EnterButton.Name = "EnterButton";
            EnterButton.Size = new Size(351, 37);
            EnterButton.TabIndex = 3;
            EnterButton.Text = "Войти";
            EnterButton.UseVisualStyleBackColor = false;
            EnterButton.Click += EnterButton_Click;
            EnterButton.KeyDown += EnterButton_KeyDown;
            // 
            // PasswordBox
            // 
            PasswordBox.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            PasswordBox.Location = new Point(46, 207);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.PasswordChar = '*';
            PasswordBox.Size = new Size(351, 26);
            PasswordBox.TabIndex = 2;
            PasswordBox.KeyDown += PasswordBox_KeyDown;
            // 
            // EmailBox
            // 
            EmailBox.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            EmailBox.Location = new Point(47, 126);
            EmailBox.Name = "EmailBox";
            EmailBox.Size = new Size(351, 26);
            EmailBox.TabIndex = 1;
            EmailBox.KeyDown += EmailBox_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(46, 189);
            label3.Name = "label3";
            label3.Size = new Size(70, 19);
            label3.TabIndex = 13;
            label3.Text = "Пароль";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(46, 108);
            label2.Name = "label2";
            label2.Size = new Size(51, 19);
            label2.TabIndex = 11;
            label2.Text = "Email";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.InfoText;
            label1.Location = new Point(173, 27);
            label1.Name = "label1";
            label1.Size = new Size(95, 37);
            label1.TabIndex = 10;
            label1.Text = "Вход";
            // 
            // Auth
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(749, 746);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Auth";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox EmailBox;
        private Label label3;
        private TextBox PasswordBox;
        private Button EnterButton;
        private LinkLabel linkLabel1;
    }
}