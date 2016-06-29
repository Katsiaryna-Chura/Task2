using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            DataHandler dataHandler;
            List<string> list = new List<string>();
            string str;
            do
            {
                Console.WriteLine("Enter string (or 'stop' to stop entering new strings):");
                str = Console.ReadLine();
                if (str != "stop")
                {
                    list.Add(str);
                }
            } while (str != "stop");
            dataHandler = new DataHandler(list);
            Console.WriteLine($"Number of integers: {dataHandler.GetNumberOfIntegers()}");  
            WriteIntegersWithAverage(dataHandler.GetListOfIntegers(), dataHandler.GetIntegersAverage());
            Console.WriteLine($"Number of doubles: {dataHandler.GetNumberOfDoubles()}"); 
            WriteDoublesWithAverage(dataHandler.GetListOfDoubles(), dataHandler.GetDoublesAverage());
            WriteSortedStrings(dataHandler.GetSortedStrings());
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        public static void WriteIntegersWithAverage(List<int> intList, double avg)
        {
            if (intList.Count == 0)
            {
                return;
            }
            foreach (int i in intList)
            {
                Console.WriteLine($"{i,17}");
            }
            Console.WriteLine($"average = {avg,7:0.00}");
        }

        public static void WriteDoublesWithAverage(List<double> doubleList, double avg)
        {
            if (doubleList.Count == 0)
            {
                return;
            }
            foreach (var d in doubleList)
            {
                Console.WriteLine($"{d,17:0.00}");
            }
            Console.WriteLine($"average = {avg,7:0.00}");
        }

        public static void WriteSortedStrings(List<string> sortedList)
        {
            if (sortedList.Count == 0)
            {
                Console.WriteLine("There are no strings that are not numbers.");
                return;
            }
            Console.WriteLine("Sorted strings:");
            foreach (var s in sortedList)
            {
                Console.WriteLine(s);
            }
        }
    }
}
