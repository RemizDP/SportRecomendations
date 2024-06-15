using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Приложение_консультант_по_подбору_спортивных_секций
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; } = "Неизвестно";
        public string email { get; set; }
        public int height { get; set; } = 0;
        public int weight { get; set; } = 0;
        public int age { get; set; } = 0;
        public bool sex { get; set; } = false; //false == мужской
        public string location { get; set; } = "Неизвестно";
        public double maxRating { get; set; } = 0;
        public double meanRating {  get; set; } = 0;

        public User(string email)
        {
            this.email = email;
        }
        public User() { }
        public void EditInfo(string name, int height, int weight, int age, bool sex, string location)
        {
            this.name = name;
            this.height = height;
            this.weight = weight;
            this.age = age;
            this.sex = sex;
            this.location = location;
        }

        public double BMI()
        {
            return this.weight * 10000 / (this.height * this.height);
        }
    }
}
