using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Приложение_консультант_по_подбору_спортивных_секций
{
    public class SectionRating
    {
        [LoadColumn(0)]
        public float userId;
        [LoadColumn(1)]
        public float sectionId;
        [LoadColumn(2)]
        public float Label;
    }
}
