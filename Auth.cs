using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Приложение_консультант_по_подбору_спортивных_секций
{
    public partial class Auth : Form
    {
        public Registration? regWnd;

        public DataBase dataBase = new DataBase();

        public Auth()
        {
            InitializeComponent();
        }

        public void LoadUserData(SqlDataReader reader, User user)
        {
            user.id = reader.GetInt32(0);
            user.name = reader.GetString(1);
            user.email = reader.GetString(2);
            user.height = reader.GetInt32(5);
            user.weight = reader.GetInt32(6);
            user.age = reader.GetInt32(7);
            user.sex = reader.GetBoolean(8);
            user.location = reader.GetString(9);
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration regWnd = new Registration();
            this.regWnd = regWnd;
            regWnd.authWnd = this;
            regWnd.Show();
            Hide();
        }

        public void CheckPassword(string password, byte[] key, byte[] salt)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt))
            {
                byte[] newKey = deriveBytes.GetBytes(20);  // derive a 20-byte key

                if (!newKey.SequenceEqual(key))
                    throw new InvalidOperationException("Password is invalid!");
            }
        }
        private void EnterButton_Click(object sender, EventArgs e)
        {
            string queryString = $"select * from RegUser where email ='{EmailBox.Text.ToLower()}'";
            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());
            dataBase.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            byte[] key, salt;
            if (reader.Read())
            {
                //проверка ключа и соли

                key = new byte[20];
                salt = new byte[20];
                reader.GetBytes(3, 0, key, 0, 20);
                reader.GetBytes(4, 0, salt, 0, 20);

                try
                {
                    CheckPassword(PasswordBox.Text, key, salt);
                }
                catch
                {
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка!");
                    dataBase.CloseConnection();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка!");
                dataBase.CloseConnection();
                return;
            }

            MainWnd mainWnd = new MainWnd();
            mainWnd.authWnd = this;
            mainWnd.currUser = new User();

            LoadUserData(reader, mainWnd.currUser);
            dataBase.CloseConnection();
            this.Hide();
            mainWnd.Show();
            EmailBox.Text = "";
            PasswordBox.Text = "";
        }

        private void EmailBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnterButton_Click(sender, e);
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            EmailBox_KeyDown(sender, e);
        }

        private void EnterButton_KeyDown(object sender, KeyEventArgs e)
        {
            EmailBox_KeyDown(sender, e);
        }
    }
}
