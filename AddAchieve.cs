using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Azure.Core.HttpHeader;

namespace Приложение_консультант_по_подбору_спортивных_секций
{
    public partial class AddAchieve : Form
    {
        public MainWnd mainWnd;
        public EditUserInfo editInfoWnd;
        public AddAchieve()
        {
            InitializeComponent();
        }
        void SetCombo(string column, string sourceTable, ComboBox combo)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"select distinct {column} from {sourceTable}; ";
            SqlCommand command = new SqlCommand(queryString, mainWnd.authWnd.dataBase.GetConnection());
            mainWnd.authWnd.dataBase.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                combo.Items.Add(reader.GetString(0));
            }
            mainWnd.authWnd.dataBase.CloseConnection();

        }
        void SetCombo(string column, string sourceTable, string where, ComboBox combo)
        {
            string w = "where " + where;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"select distinct {column} from {sourceTable} {w}; ";
            SqlCommand command = new SqlCommand(queryString, mainWnd.authWnd.dataBase.GetConnection());
            mainWnd.authWnd.dataBase.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                combo.Items.Add(reader.GetString(0));
            }
            mainWnd.authWnd.dataBase.CloseConnection();

        }
        private void AddAchieve_Load(object sender, EventArgs e)
        {
            SetCombo("olympic_type", "Sport", SportTypeBox);
            SportBox.Enabled = false;
            CategoryLabel.Visible = false;
            CategoryBox.Visible = false;
            PlaceLabel.Visible = false;
            PlaceBox.Visible = false;
            PlaceBox.Enabled = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (SportTypeBox.Text == "" || SportBox.Text == "" || NameBox.Text == "" || (CategoryBox.Text == "" && PlaceBox.Text == ""))
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка");
                return;
            }
            int currYear = DateTime.Now.Year;
            int year = DateBox.Value.Year;
            int diff = currYear - year;
            if (diff < 0)
            {
                MessageBox.Show("Неверная дата достижения!", "Ошибка");
                return;
            }
            //сохранение достижения
            string queryString = $"select sport_id from Sport where min_age <= {mainWnd.currUser.age - diff} and max_age >= {mainWnd.currUser.age - diff} and sport_name ='{SportBox.Text}'";
            SqlCommand command = new SqlCommand(queryString, mainWnd.authWnd.dataBase.GetConnection());
            mainWnd.authWnd.dataBase.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            int sport_id;
            if (reader.Read())
            {
                sport_id = (reader.GetInt32(0));
            }
            else
            {
                MessageBox.Show("Возраст и дата достижения несовместимы!", "Ошибка");
                mainWnd.authWnd.dataBase.CloseConnection();
                return;
            }

            mainWnd.authWnd.dataBase.CloseConnection();
            queryString = $"insert into Achievement (regUser_id, sport_id, achievement_name, achievement_type, category, competition_result, achievement_date) values ({mainWnd.currUser.id}, {sport_id},'{NameBox.Text}', '{AchievementTypeBox.Text}', '{CategoryBox.Text}','{PlaceBox.Text}',{year});";
            command = new SqlCommand(queryString, mainWnd.authWnd.dataBase.GetConnection());
            this.mainWnd.authWnd.dataBase.OpenConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Данные успешно сохранены", "Успех");
            }
            else
            {
                MessageBox.Show("Ошибка insert запроса!", "Ошибка");
                return;
            }
            mainWnd.authWnd.dataBase.CloseConnection();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены?", "Предупреждение", MessageBoxButtons.YesNo);

            if (res == DialogResult.No)
            {
                return;
            }

            Close();
        }

        private void SportTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SportTypeBox.SelectedIndex != -1)
            {
                SportBox.Items.Clear();
                SetCombo("sport_name", "Sport", $"olympic_type = '{SportTypeBox.Text}'", SportBox);
                SportBox.Enabled = true;
            }
        }

        private void AchievementTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AchievementTypeBox.Text == "Разряд")
            {
                PlaceLabel.Visible = false;
                PlaceBox.Visible = false;
                PlaceBox.Enabled = false;
                CategoryLabel.Visible = true;
                CategoryBox.Visible = true;
                CategoryBox.Enabled = true;
            }
            else
            {
                CategoryBox.Enabled = false;
                CategoryLabel.Visible = false;
                CategoryBox.Visible = false;
                PlaceLabel.Visible = true;
                PlaceBox.Visible = true;
                PlaceBox.Enabled = true;
            }

        }

        private void PlaceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PlaceBox.SelectedIndex != -1)
            {
                CategoryBox.SelectedIndex = -1;
            }
        }

        private void CategoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryBox.SelectedIndex != -1)
            {
                PlaceBox.SelectedIndex = -1;
            }
        }

        private void AddAchieve_FormClosing(object sender, FormClosingEventArgs e)
        {
            editInfoWnd.AchievesBox.Items.Clear();
            editInfoWnd.SetAchieves(editInfoWnd.AchievesBox);
            editInfoWnd.AchieveButton.Enabled = true;
        }
    }
}
