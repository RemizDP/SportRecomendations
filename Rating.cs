using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Приложение_консультант_по_подбору_спортивных_секций
{
    public class Rating
    {
        public int id {  get; set; }
        public int user_id { get; set; }
        public int section_id { get; set; }
        public int weight { get; set; }
        public DateTime date { get; set; }
        public double Decay()
        {
            return (double)weight / (Convert.ToUInt32((DateTime.Now.Date - date).TotalDays) + 1);
        }
    }
}
