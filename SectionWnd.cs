using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Приложение_консультант_по_подбору_спортивных_секций
{
    public partial class SectionWnd : Form
    {
        public SectionWnd()
        {
            InitializeComponent();

        }

        public MainWnd mainWnd;
        public int section_id;
        public bool wishlist;
        public int pos_x, pos_y;
        public int height, width;


        public bool FindId(SportSection section)
        {
            return section_id == section.id;
        }
        private void WishListBox_CheckedChanged(object sender, EventArgs e)
        {
            int k = mainWnd.sections.FindIndex(section => mainWnd.FindSectionById(section, section_id));
            if (WishListBox.Checked)
            {
                //запрос об изменении в бд 
                string queryString = $"insert into Rating (regUser_id, section_id, explicit_, rating_weight, rating_type, rating_date) values ({mainWnd.currUser.id}, {section_id}, 0, 7, 'желаемое', GETDATE());";
                SqlCommand command = new SqlCommand(queryString, mainWnd.authWnd.dataBase.GetConnection());
                mainWnd.authWnd.dataBase.OpenConnection();
                command.ExecuteNonQuery();
                mainWnd.authWnd.dataBase.CloseConnection();

                mainWnd.sections[k].wishlist = true;
                mainWnd.AddStarToLabel(StarLabel, k);
                mainWnd.Controls.Remove(mainWnd.panels[k]);
                mainWnd.panels[k] = mainWnd.CreatePanel(mainWnd, k, pos_x, pos_y, height, width);
                Show();
            }
            else
            {
                // запрос об изменении в бд
                string queryString = $"delete from Rating where (regUser_id = {mainWnd.currUser.id} AND section_id = {section_id} AND rating_type = 'желаемое')";
                SqlCommand command = new SqlCommand(queryString, mainWnd.authWnd.dataBase.GetConnection());
                mainWnd.authWnd.dataBase.OpenConnection();
                command.ExecuteNonQuery();
                mainWnd.authWnd.dataBase.CloseConnection();

                mainWnd.sections[k].wishlist = false;
                StarLabel.Text = "";
                mainWnd.Controls.Remove(mainWnd.panels[k]);
                mainWnd.panels[k] = mainWnd.CreatePanel(mainWnd, k, pos_x, pos_y, height, width);
                Show();
            }
        }

        private void RequestButton_Click(object sender, EventArgs e)
        {
            //запрос оставления заявки
            string queryString = $"insert into Rating (regUser_id, section_id, explicit_, rating_weight, rating_type, rating_date, request_text) values ({mainWnd.currUser.id}, {section_id}, 0, 10, 'заявка', GETDATE(), '{RequestBox.Text}');";
            SqlCommand command = new SqlCommand(queryString, mainWnd.authWnd.dataBase.GetConnection());
            mainWnd.authWnd.dataBase.OpenConnection();
            command.ExecuteNonQuery();
            mainWnd.authWnd.dataBase.CloseConnection();
            RequestButton.Enabled = false;
        }



        private void SectionWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (RateBox.SelectedIndex != -1)
            {
                //удаление старой оценки
                string queryString = $"delete from Rating where (regUser_id = {mainWnd.currUser.id} AND section_id = {section_id} AND rating_type = 'оценка пользователем')";
                SqlCommand command = new SqlCommand(queryString, mainWnd.authWnd.dataBase.GetConnection());
                mainWnd.authWnd.dataBase.OpenConnection();
                command.ExecuteNonQuery();
                mainWnd.authWnd.dataBase.CloseConnection();
                //добавление новой оценки
                queryString = $"insert into Rating (regUser_id, section_id, explicit_, rating_weight, rating_type, rating_date) values ({mainWnd.currUser.id}, {section_id}, 1, {(Convert.ToInt32(RateBox.Text) - 3) * 4}, 'оценка пользователем', GETDATE());";
                command = new SqlCommand(queryString, mainWnd.authWnd.dataBase.GetConnection());
                mainWnd.authWnd.dataBase.OpenConnection();
                command.ExecuteNonQuery();
                mainWnd.authWnd.dataBase.CloseConnection();
            }
        }

        private void SectionWnd_Load(object sender, EventArgs e)
        {
            if (!wishlist)
            {
                WishListBox.CheckState = CheckState.Unchecked;
            }
        }
    }
}
