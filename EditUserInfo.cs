using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Приложение_консультант_по_подбору_спортивных_секций
{
    public partial class EditUserInfo : Form
    {
        public MainWnd mainWnd;
        public EditUserInfo()
        {
            InitializeComponent();
        }


        public void SetAchieves(ListBox list)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"select achievement_name, sport_name, achievement_date from Achievement inner join Sport on Achievement.sport_id = Sport.sport_id where regUser_id ={mainWnd.currUser.id}; ";
            SqlCommand command = new SqlCommand(queryString, mainWnd.authWnd.dataBase.GetConnection());
            mainWnd.authWnd.dataBase.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Items.Add(reader.GetString(0) + ", " + reader.GetString(1) + ", " + reader.GetInt32(2));
            }
            mainWnd.authWnd.dataBase.CloseConnection();

        }
        private void EditUserInfo_Load(object sender, EventArgs e)
        {
            //подтягивание инфы о пользователе из главной формы
            NameBox.Text = this.mainWnd.currUser.name;
            HeightBox.Text = this.mainWnd.currUser.height.ToString();
            WeightBox.Text = this.mainWnd.currUser.weight.ToString();
            if (this.mainWnd.currUser.sex)
                SexBox.Text = "ж";
            else
                SexBox.Text = "м";
            AgeBox.Text = this.mainWnd.currUser.age.ToString();
            if (this.mainWnd.currUser.weight > 3)
                BMILabel.Text = "ИМТ: " + mainWnd.currUser.BMI().ToString("00.00");
            LocationBox.Text = mainWnd.currUser.location;
            //sql запрос о достижениях
            SetAchieves(AchievesBox);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (HeightBox.Text == "" || WeightBox.Text == "" || AgeBox.Text == "" || SexBox.Text == "" || LocationBox.Text == "")
            {
                DialogResult res = MessageBox.Show("Не все поля были заполнены, рекомендации могут быть недостаточно точными. \n Вы действительно хотите сохранить неполную информацию?", "Предупреждение", MessageBoxButtons.YesNo);

                if (res == DialogResult.No)
                {
                    return;
                }
            }
            int height = Convert.ToInt32(HeightBox.Text);
            int weight = Convert.ToInt32(WeightBox.Text);
            int age = Convert.ToInt32(AgeBox.Text);
            if (height < 85 || height > 225)
            {
                MessageBox.Show("Недопустимый рост", "Ошибка ввода");
                return;
            }
            mainWnd.currUser.height = height;
            if (weight < 3 || weight > 175)
            {
                MessageBox.Show("Недопустимый вес", "Ошибка ввода");
                return;
            }
            mainWnd.currUser.weight = weight;
            if (age < 2 || age > 110)
            {
                MessageBox.Show("Недопустимый возраст", "Ошибка ввода");
                return;
            }
            mainWnd.currUser.age = age;
            string sex = SexBox.Text.ToLower();
            switch (sex)
            {
                case "м":
                    mainWnd.currUser.sex = false;
                    break;
                case "ж":
                    mainWnd.currUser.sex = true;
                    break;
                default:
                    MessageBox.Show("Строка в поле пола не соответствует формату м / ж!", "Ошибка ввода");
                    return;
            }

            mainWnd.currUser.name = NameBox.Text;
            mainWnd.currUser.location = LocationBox.Text.ToLower();

            //sql запрос на сохранение данных о пользователе
            string queryString = $"update RegUser set regUser_name ='{NameBox.Text}', " +
                $"                                  height ='{mainWnd.currUser.height}', " +
                $"                                  weight ='{mainWnd.currUser.weight}', " +
                $"                                  age    ='{mainWnd.currUser.age}', " +
                $"                                  sex    ='{mainWnd.currUser.sex}', " +
                $"                                  location ='{mainWnd.currUser.location}' where email ='{mainWnd.currUser.email}';";

            SqlCommand command = new SqlCommand(queryString, this.mainWnd.authWnd.dataBase.GetConnection());

            this.mainWnd.authWnd.dataBase.OpenConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Данные успешно сохранены", "Успех");
                mainWnd.LoadUserData();
                int k = mainWnd.users.FindIndex(u => mainWnd.FindUserById(u, mainWnd.currUser.id));
                mainWnd.users[k]= mainWnd.currUser;
            }
            mainWnd.authWnd.dataBase.CloseConnection();
            Close();
        }

        private void AchieveButton_Click(object sender, EventArgs e)
        {
            AchieveButton.Enabled = false;
            AddAchieve achieveWnd = new AddAchieve();
            achieveWnd.mainWnd = this.mainWnd;
            achieveWnd.editInfoWnd = this;
            achieveWnd.Show();
        }

        private void EditUserInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainWnd.ProfileButton.Enabled = true;
            mainWnd.WelcomeLabel.Text = "Добро пожаловать, " + NameBox.Text + "!";
            }
    }
}
