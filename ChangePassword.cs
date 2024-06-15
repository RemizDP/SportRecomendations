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
    public partial class ChangePassword : Form
    {
        public MainWnd mainWnd;
        public ChangePassword()
        {
            InitializeComponent();
        }
        public const string latinHigh = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string latinLow = "abcdefghijklmnopqrstuvwxyz";
        public const string digits = "0123456789";
        public const string specSymbols = ".,<>?|/+-()[]{};:!~`@#$^&*_=";
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
        private void EnterButton_Click(object sender, EventArgs e)
        {
            EnterButton.Enabled = false;
            string queryString = $"select * from RegUser where email ='{mainWnd.currUser.email.ToLower()}'";
            SqlCommand command = new SqlCommand(queryString, mainWnd.authWnd.dataBase.GetConnection());
            mainWnd.authWnd.dataBase.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();

            byte[] key = new byte[20];
            byte[] salt = new byte[20];
            if (reader.Read())
            {
                //проверка ключа и соли

                reader.GetBytes(3, 0, key, 0, 20);
                reader.GetBytes(4, 0, salt, 0, 20);
            }
            mainWnd.authWnd.dataBase.CloseConnection();
            try
            {
                mainWnd.authWnd.CheckPassword(OldPasswordBox.Text, key, salt);
                if (PasswordValidation(PasswordBox1.Text))
                {
                    if (PasswordBox1.Text == PasswordBox2.Text)
                    {
                        using (var deriveBytes = new Rfc2898DeriveBytes(PasswordBox1.Text, 20))
                        {
                            salt = deriveBytes.Salt;
                            key = deriveBytes.GetBytes(20);  // derive a 20-byte key

                            queryString = $"update RegUser set regUser_key=@userKey, salt= @salt where regUser_id = {mainWnd.currUser.id}";

                            command = new SqlCommand(queryString, mainWnd.authWnd.dataBase.GetConnection());
                            SqlParameter param1 = command.Parameters.Add("@userKey", SqlDbType.Binary);
                            param1.Value = key;
                            SqlParameter param2 = command.Parameters.Add("@salt", SqlDbType.Binary);
                            param2.Value = salt;


                            mainWnd.authWnd.dataBase.OpenConnection();
                            if (command.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Пароль изменен.", "Успех!");
                            }

                            mainWnd.authWnd.dataBase.CloseConnection();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают!", "Ошибка"); 
                        EnterButton.Enabled = true;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Пароль должен содержать хотя бы одну прописную и хотя бы одну строчную латинскую букву, хотя бы одну цифру и хотя бы один специальный символ", "Ошибка");
                    EnterButton.Enabled = true;
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Неверный пароль!", "Ошибка!");

                EnterButton.Enabled = true;
                return;
            }
            EnterButton.Enabled = true;
        }

        private void OldPasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnterButton_Click(sender, e);
            }
        }

        private void PasswordBox1_KeyDown(object sender, KeyEventArgs e)
        {
            OldPasswordBox_KeyDown(sender, e);
        }

        private void PasswordBox2_KeyDown(object sender, KeyEventArgs e)
        {
            OldPasswordBox_KeyDown(sender, e);
        }
    }
}
