using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists(FilePath.Path))
            {
                string fileText = File.ReadAllText(FilePath.Path);
                string editedText = GetEditedText(fileText);
                File.WriteAllText(FilePath.Path, editedText);
                Console.WriteLine("Text in the file has been edited.");
            }
            else
            {
                Console.WriteLine("There is no such file.");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        public static string GetTimeStamp()
        {
            DateTime currentTime = DateTime.Now;
            string dateTimeFormat = "MM/dd/yyyy hh:mm:ss.ff";
            return currentTime.ToString(dateTimeFormat);
        }

        public static string GetEditedText(string text)
        {
            text = text.ToLower();
            string editedText = "";
            char[] endOfSentence = { '.', '!', '?' };
            int index;
            while ((index = text.IndexOfAny(endOfSentence)) != -1)
            {
                char nextSymbol = text[index + 1];
                if (nextSymbol == '\n')
                {
                    editedText = editedText + GetTimeStamp() + " " + text.Substring(0, index + 1) + "\n";
                    text = text.Substring(index + 2);                   
                    continue;
                }
                bool moreThanOneDots = false;
                do
                {
                    nextSymbol = text[index + 1];
                    if ((nextSymbol == '.') || (nextSymbol == '?') || (nextSymbol == '!'))
                    {
                        index++;
                        moreThanOneDots = true;
                    }
                    else
                        moreThanOneDots = false;
                } while (moreThanOneDots);
                editedText = editedText + GetTimeStamp() + " " + text.Substring(0, index + 1) + "\n";
                text = text.Substring(index + 1);
            }
            return editedText;
        }
    }   
}
