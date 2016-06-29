using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2
{
    public class DataHandler
    {
        List<int> intList;
        List<double> doubleList;
        List<string> stringList;

        public DataHandler(List<string> list)
        {
            int i;
            double d;
            intList = new List<int>();
            doubleList = new List<double>();
            stringList = new List<string>();
            NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat;
            foreach (var listItem in list)
            {
                if (Int32.TryParse(listItem, out i))
                {
                    intList.Add(i);
                }
                else if (Double.TryParse(listItem.Replace(',', '.').Replace('.', nfi.NumberDecimalSeparator[0]), out d))
                {
                    doubleList.Add(d);
                }
                else
                {
                    stringList.Add(listItem);
                }
            }
        }

        public int GetNumberOfIntegers()
        {
            return intList.Count;
        }

        public List<int> GetListOfIntegers()
        {
            return intList;
        }

        public double GetIntegersAverage()
        {
            if (intList.Count == 0)
            {
                return 0;
            }
            return intList.Average();
        }

        public int GetNumberOfDoubles()
        {
            return doubleList.Count;
        }

        public List<double> GetListOfDoubles()
        {
            return doubleList;
        }

        public double GetDoublesAverage()
        {
            if (doubleList.Count == 0)
            {
                return 0;
            }
            return doubleList.Average();
        }

        public List<string> GetSortedStrings()
        {
            return stringList.OrderBy(a => a.Length).ThenBy(a => a).ToList();
        }
    }
}
