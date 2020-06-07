using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class StringAnalyzer
    {
        public static string[] FindMoreThanAverage(string[] array)
        {
            int avg = CountAverageLength(array);
            return Array.FindAll(array, str => str.Length > avg);
        }

        public static int CountAverageLength(string[] array)
        {
            int sum = 0;

            foreach (string str in array)
            {
                sum += str.Length;
            }

            if (array.Length == 0) return 0;
            return sum / array.Length;
        }
    }
}
