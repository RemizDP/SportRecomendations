using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Приложение_консультант_по_подбору_спортивных_секций
{
    public class SportSection
    {
        public int id {  get; set; }
        public string sport { get; set; }
        public string olympic_type { get; set; }
        public string name { get; set; }
        public string description {  get; set; }
        public int minAge { get; set; }
        public int maxAge { get; set; }
        public int lessonsPerWeek { get; set; }
        public int cost { get; set; }
        public string location { get; set; }
        public string contacts { get; set; }
        public bool wishlist { get; set; } = false;
        public int relevance { get; set; } = 0;
        public double averageRating { get; set; } = 0;
        public double normalizedRating { get; set; } = 0;


    }
}
