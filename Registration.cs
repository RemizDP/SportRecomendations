using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Приложение_консультант_по_подбору_спортивных_секций
{
    public partial class Registration : Form
    {
        public Auth? authWnd;


        public const string latinHigh = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string latinLow = "abcdefghijklmnopqrstuvwxyz";
        public const string digits = "0123456789";
        public const string specSymbols = ".,<>?|/+-()[]{};:!~`@#$^&*_=";
        public Registration()
        {
            InitializeComponent();
        }
        public bool PasswordValidation(string password)
        {
            if (password == "")
                return false;

            bool latH = false;
            bool latL = false;
            bool dig = false;
            bool spec = false;
            foreach (char s in password)
            {
                if (latinHigh.IndexOf(s) != -1)
                    latH = true;
                if (latinLow.IndexOf(s) != -1)
                    latL = true;
                if (digits.IndexOf(s) != -1)
                    dig = true;
                if (specSymbols.IndexOf(s) != -1)
                    spec = true;
            }

            return (latH && latL && dig && spec);
        }

        public bool EmailValidation(string email)
        {
            if (email != "")
            {
                try
                {
                    MailAddress m = new MailAddress(email);
                    return true;
                }
                catch (FormatException)
                {
                    return false;
                }
            }
            return false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.authWnd.Show();
            this.authWnd.regWnd = null;
            Close();
        }
        public void LoadUserData(MainWnd mainWnd)
        {
            string queryString = $"select * from RegUser where email ='{EmailBox.Text.ToLower()}'";
            SqlCommand command = new SqlCommand(queryString, this.authWnd.dataBase.GetConnection());
            this.authWnd.dataBase.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                this.authWnd.LoadUserData(reader, mainWnd.currUser);
            }

            this.authWnd.dataBase.CloseConnection();
        }
        private void EnterButton_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"select regUser_id from RegUser where email = '{EmailBox.Text.ToLower()}'";
            SqlCommand command = new SqlCommand(queryString, this.authWnd.dataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 0)
            {
                if (EmailValidation(EmailBox.Text) && PasswordValidation(PasswordBox1.Text))
                    if (PasswordBox1.Text == PasswordBox2.Text)
                    {
                        using (var deriveBytes = new Rfc2898DeriveBytes(PasswordBox1.Text, 20))
                        {
                            byte[] salt = deriveBytes.Salt;
                            byte[] key = deriveBytes.GetBytes(20);  // derive a 20-byte key

                            User currUser = new User(EmailBox.Text);
                            queryString = $"insert into RegUser (regUser_name, email, regUser_key, salt, height, weight, age, sex, location) values ('Неизвестно', '{EmailBox.Text.ToLower()}', @userKey, @salt, 0, 0, 0,'{false}','Неизвестно');";
                            
                            command = new SqlCommand(queryString, this.authWnd.dataBase.GetConnection());
                            SqlParameter param1 = command.Parameters.Add("@userKey", SqlDbType.Binary);
                            param1.Value = key;
                            SqlParameter param2 = command.Parameters.Add("@salt", SqlDbType.Binary);
                            param2.Value = salt;


                            this.authWnd.dataBase.OpenConnection();
                            if (command.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Аккаунт успешно создан!", "Успех!");

                                MainWnd mainWnd = new MainWnd();
                                mainWnd.authWnd = this.authWnd;
                                mainWnd.currUser = new User();
                                LoadUserData(mainWnd);
                                mainWnd.Show();

                                EditUserInfo editInfoWnd = new EditUserInfo();
                                editInfoWnd.mainWnd = mainWnd;
                                editInfoWnd.ShowDialog();
                                this.authWnd.regWnd = null;
                                this.Close();
                            }
                            else
                                MessageBox.Show("Аккаунт не создан!", "Ошибка!");
                            this.authWnd.dataBase.CloseConnection();
                        }
                    }
                    else
                        MessageBox.Show("Пароли не совпадают!", "Ошибка");
                else
                {
                    MessageBox.Show("Пароль должен содержать хотя бы одну прописную и хотя бы одну строчную латинскую букву, хотя бы одну цифру и хотя бы один специальный символ  \n" +
                                    "Email должен содержать символы @ и . и соответствовать формату example@domen", "Ошибка");
                }
            }
            else
                MessageBox.Show("Пользователь с таким email уже существует!", "Ошибка");
        }

        private void EmailBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnterButton_Click(sender, e);
            }
        }

        private void PasswordBox1_KeyDown(object sender, KeyEventArgs e)
        {
            EmailBox_KeyDown(sender, e);
        }

        private void PasswordBox2_KeyDown(object sender, KeyEventArgs e)
        {
            EmailBox_KeyDown(sender, e);
        }
    }
}
