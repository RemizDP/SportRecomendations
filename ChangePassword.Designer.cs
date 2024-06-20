namespace Приложение_консультант_по_подбору_спортивных_секций
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            panel1 = new Panel();
            PasswordBox2 = new TextBox();
            label4 = new Label();
            EnterButton = new Button();
            PasswordBox1 = new TextBox();
            OldPasswordBox = new TextBox();
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
            panel1.Controls.Add(PasswordBox2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(EnterButton);
            panel1.Controls.Add(PasswordBox1);
            panel1.Controls.Add(OldPasswordBox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(109, 145);
            panel1.Name = "panel1";
            panel1.Size = new Size(447, 379);
            panel1.TabIndex = 2;
            // 
            // PasswordBox2
            // 
            PasswordBox2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            PasswordBox2.Location = new Point(46, 239);
            PasswordBox2.Name = "PasswordBox2";
            PasswordBox2.PasswordChar = '*';
            PasswordBox2.Size = new Size(351, 26);
            PasswordBox2.TabIndex = 3;
            PasswordBox2.KeyDown += PasswordBox2_KeyDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(46, 221);
            label4.Name = "label4";
            label4.Size = new Size(217, 19);
            label4.TabIndex = 16;
            label4.Text = "Повторите новый пароль";
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
            EnterButton.TabIndex = 4;
            EnterButton.Text = "Сохранить";
            EnterButton.UseVisualStyleBackColor = false;
            EnterButton.Click += EnterButton_Click;
            // 
            // PasswordBox1
            // 
            PasswordBox1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            PasswordBox1.Location = new Point(47, 183);
            PasswordBox1.Name = "PasswordBox1";
            PasswordBox1.PasswordChar = '*';
            PasswordBox1.Size = new Size(351, 26);
            PasswordBox1.TabIndex = 2;
            PasswordBox1.KeyDown += PasswordBox1_KeyDown;
            // 
            // OldPasswordBox
            // 
            OldPasswordBox.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            OldPasswordBox.Location = new Point(47, 126);
            OldPasswordBox.Name = "OldPasswordBox";
            OldPasswordBox.PasswordChar = '*';
            OldPasswordBox.Size = new Size(351, 26);
            OldPasswordBox.TabIndex = 1;
            OldPasswordBox.KeyDown += OldPasswordBox_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(47, 165);
            label3.Name = "label3";
            label3.Size = new Size(128, 19);
            label3.TabIndex = 12;
            label3.Text = "Новый пароль";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(46, 108);
            label2.Name = "label2";
            label2.Size = new Size(135, 19);
            label2.TabIndex = 11;
            label2.Text = "Старый пароль";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.InfoText;
            label1.Location = new Point(103, 29);
            label1.Name = "label1";
            label1.Size = new Size(240, 37);
            label1.TabIndex = 10;
            label1.Text = "Смена пароля";
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(670, 712);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ChangePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Смена пароля";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox PasswordBox2;
        private Label label4;
        private Button EnterButton;
        private TextBox PasswordBox1;
        private Label label3;
        private Label label1;
        private TextBox OldPasswordBox;
        private Label label2;
    }
}