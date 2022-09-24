using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get;}

        public double CaoloriesPerMinutr { get; }

        public Activity(string name, double caloriesPerMinute)
        {
            //Проверка
            Name = name;
            CaoloriesPerMinutr = caloriesPerMinute;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
