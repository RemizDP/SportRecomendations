namespace Приложение_консультант_по_подбору_спортивных_секций
{
    partial class Analytics
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Analytics));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            AverageUserRatingChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            AverageSectionRatingChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tabPage2 = new TabPage();
            label4 = new Label();
            L1NormDG = new DataGridView();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            PearsonDG = new DataGridView();
            OchiaiDG = new DataGridView();
            JaccardDG = new DataGridView();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AverageUserRatingChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AverageSectionRatingChart).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)L1NormDG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PearsonDG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OchiaiDG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)JaccardDG).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1923, 990);
            tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(AverageUserRatingChart);
            tabPage1.Controls.Add(AverageSectionRatingChart);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1915, 962);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Средние оценки";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // AverageUserRatingChart
            // 
            chartArea1.Name = "ChartArea1";
            AverageUserRatingChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            AverageUserRatingChart.Legends.Add(legend1);
            AverageUserRatingChart.Location = new Point(55, 439);
            AverageUserRatingChart.Name = "AverageUserRatingChart";
            series1.ChartArea = "ChartArea1";
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Оценка";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            AverageUserRatingChart.Series.Add(series1);
            AverageUserRatingChart.Size = new Size(1805, 468);
            AverageUserRatingChart.TabIndex = 9;
            AverageUserRatingChart.Text = "chart2";
            title1.Name = "Title1";
            title1.Text = "Средняя оценка пользователя";
            AverageUserRatingChart.Titles.Add(title1);
            // 
            // AverageSectionRatingChart
            // 
            chartArea2.Name = "ChartArea1";
            AverageSectionRatingChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            AverageSectionRatingChart.Legends.Add(legend2);
            AverageSectionRatingChart.Location = new Point(55, 24);
            AverageSectionRatingChart.Name = "AverageSectionRatingChart";
            series2.ChartArea = "ChartArea1";
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Оценка";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            AverageSectionRatingChart.Series.Add(series2);
            AverageSectionRatingChart.Size = new Size(1805, 409);
            AverageSectionRatingChart.TabIndex = 8;
            AverageSectionRatingChart.Text = "chart1";
            title2.Name = "Title1";
            title2.Text = "Средняя оценка секций";
            AverageSectionRatingChart.Titles.Add(title2);
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(L1NormDG);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(PearsonDG);
            tabPage2.Controls.Add(OchiaiDG);
            tabPage2.Controls.Add(JaccardDG);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1915, 962);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Матрицы";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1407, 927);
            label4.Name = "label4";
            label4.Size = new Size(115, 15);
            label4.TabIndex = 7;
            label4.Text = "Матрица L1-нормы";
            // 
            // L1NormDG
            // 
            L1NormDG.AllowUserToAddRows = false;
            L1NormDG.AllowUserToDeleteRows = false;
            L1NormDG.AllowUserToOrderColumns = true;
            L1NormDG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            L1NormDG.Location = new Point(962, 474);
            L1NormDG.Name = "L1NormDG";
            L1NormDG.ReadOnly = true;
            L1NormDG.RowTemplate.Height = 25;
            L1NormDG.Size = new Size(950, 450);
            L1NormDG.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(384, 927);
            label3.Name = "label3";
            label3.Size = new Size(178, 15);
            label3.TabIndex = 5;
            label3.Text = "Матрица корреляции Пирсона";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1392, 453);
            label2.Name = "label2";
            label2.Size = new Size(144, 15);
            label2.TabIndex = 4;
            label2.Text = "Матрица сходства Отиаи";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(412, 453);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 3;
            label1.Text = "Матрица Жаккара";
            // 
            // PearsonDG
            // 
            PearsonDG.AllowUserToAddRows = false;
            PearsonDG.AllowUserToDeleteRows = false;
            PearsonDG.AllowUserToOrderColumns = true;
            PearsonDG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PearsonDG.Location = new Point(0, 474);
            PearsonDG.Name = "PearsonDG";
            PearsonDG.ReadOnly = true;
            PearsonDG.RowTemplate.Height = 25;
            PearsonDG.Size = new Size(950, 450);
            PearsonDG.TabIndex = 2;
            // 
            // OchiaiDG
            // 
            OchiaiDG.AllowUserToAddRows = false;
            OchiaiDG.AllowUserToDeleteRows = false;
            OchiaiDG.AllowUserToOrderColumns = true;
            OchiaiDG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OchiaiDG.Location = new Point(962, 0);
            OchiaiDG.Name = "OchiaiDG";
            OchiaiDG.ReadOnly = true;
            OchiaiDG.RowTemplate.Height = 25;
            OchiaiDG.Size = new Size(950, 450);
            OchiaiDG.TabIndex = 1;
            // 
            // JaccardDG
            // 
            JaccardDG.AllowUserToAddRows = false;
            JaccardDG.AllowUserToDeleteRows = false;
            JaccardDG.AllowUserToOrderColumns = true;
            JaccardDG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            JaccardDG.Location = new Point(0, 0);
            JaccardDG.Name = "JaccardDG";
            JaccardDG.ReadOnly = true;
            JaccardDG.RowTemplate.Height = 25;
            JaccardDG.Size = new Size(950, 450);
            JaccardDG.TabIndex = 0;
            // 
            // Analytics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1924, 999);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Analytics";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Аналитика";
            Load += Analytics_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AverageUserRatingChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)AverageSectionRatingChart).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)L1NormDG).EndInit();
            ((System.ComponentModel.ISupportInitialize)PearsonDG).EndInit();
            ((System.ComponentModel.ISupportInitialize)OchiaiDG).EndInit();
            ((System.ComponentModel.ISupportInitialize)JaccardDG).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart AverageUserRatingChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart AverageSectionRatingChart;
        private TabPage tabPage2;
        private DataGridView JaccardDG;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView PearsonDG;
        private DataGridView OchiaiDG;
        private Label label4;
        private DataGridView L1NormDG;
    }
}