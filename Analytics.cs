using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Приложение_консультант_по_подбору_спортивных_секций
{
    public partial class Analytics : Form
    {
        public MainWnd mainWnd;
        public Analytics()
        {
            InitializeComponent();
        }

        private void Analytics_Load(object sender, EventArgs e)

        {
            List<string> SectionsX = new List<string>();
            List<double> SectionsY = new List<double>();
            List<int> UsersX = new List<int>();
            List<double> UsersY = new List<double>();
            AverageSectionRatingChart.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep45;
            AverageSectionRatingChart.ChartAreas[0].AxisX.Interval = 1;
            AverageUserRatingChart.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep45;
            AverageUserRatingChart.ChartAreas[0].AxisX.Interval = 1;
            //Диаграммы 
            foreach (SportSection s in mainWnd.sections)
            {
                AverageSectionRatingChart.Series["Оценка"].Points.AddXY($"id = {s.id}, {s.name}", s.averageRating);
            }
            AverageSectionRatingChart.Invalidate();
            foreach (User u in mainWnd.users)
            {
                List<Rating> user1Ratings;
                List<SportSection> ratedSections1;
                mainWnd.PrepareDataForRecommendations(u.id,out user1Ratings,out ratedSections1, 2);
                AverageUserRatingChart.Series["Оценка"].Points.AddXY($"id = {u.id}, {u.name}", u.meanRating);
            }
            AverageUserRatingChart.Invalidate();
            //Таблицы
            JaccardDG.ColumnCount = mainWnd.sections.Count + 1;
            JaccardDG.RowCount = mainWnd.sections.Count + 1;
            int[,] UsersElementsMatrix = mainWnd.MatrixForJaccard();
            OchiaiDG.ColumnCount = mainWnd.sections.Count + 1;
            OchiaiDG.RowCount = mainWnd.sections.Count + 1;
            List<User> Users = new List<User>();
            Users.Add(mainWnd.users[mainWnd.GetUserIndex(1)]);
            Users.Add(mainWnd.users[mainWnd.GetUserIndex(1016)]);
            double[,] OchiaiMatrix = mainWnd.MatrixLikenessOfOchiai_Content(Users);
            JaccardDG.Rows[0].Cells[0].Value = "id cекции";
            OchiaiDG.Rows[0].Cells[0].Value = "id cекции";
            for (int i = 0; i < mainWnd.sections.Count; i++)
            {
                JaccardDG.Rows[i + 1].Cells[0].Value = JaccardDG.Rows[0].Cells[i + 1].Value = mainWnd.sections[i].id;
                OchiaiDG.Rows[i + 1].Cells[0].Value = OchiaiDG.Rows[0].Cells[i + 1].Value = mainWnd.sections[i].id;
                for (int j = 0; j < mainWnd.sections.Count; j++)
                {
                    JaccardDG.Rows[i + 1].Cells[j + 1].Value = mainWnd.JaccardSimilarity_Content(mainWnd.sections[i].id, mainWnd.sections[j].id, UsersElementsMatrix);
                    OchiaiDG.Rows[i + 1].Cells[j + 1].Value = OchiaiMatrix[i, j];
                }
            }


            PearsonDG.ColumnCount = mainWnd.users.Count + 1;
            PearsonDG.RowCount = mainWnd.users.Count + 1;
            double[,] PearsonMatrix = mainWnd.MatrixPearsonCorrelation_User(2);
            L1NormDG.ColumnCount = mainWnd.users.Count + 1;
            L1NormDG.RowCount = mainWnd.users.Count + 1;
            double[,] L1Matrix = mainWnd.MatrixL1Norm_User(2);
            PearsonDG.Rows[0].Cells[0].Value = "id пользователя";
            L1NormDG.Rows[0].Cells[0].Value = "id пользователя";
            for (int i = 0; i < mainWnd.users.Count; i++)
            {
                PearsonDG.Rows[i + 1].Cells[0].Value = PearsonDG.Rows[0].Cells[i + 1].Value = mainWnd.users[i].id;
                L1NormDG.Rows[i + 1].Cells[0].Value = L1NormDG.Rows[0].Cells[i + 1].Value = mainWnd.users[i].id;
                for (int j = 0; j < mainWnd.users.Count; j++)
                {
                    PearsonDG.Rows[i + 1].Cells[j + 1].Value = PearsonMatrix[i, j];
                    L1NormDG.Rows[i + 1].Cells[j + 1].Value = L1Matrix[i, j];
                }
            }
        }
    }
}
