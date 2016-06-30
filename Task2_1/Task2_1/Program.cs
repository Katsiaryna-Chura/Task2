using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Data.Path;
            if (File.Exists(path))
            {
                string fileText = File.ReadAllText(path);
                Console.WriteLine("Text from the file before editing:");
                Console.WriteLine(fileText);
                TextEditor editor = new TextEditor(fileText);
                editor.ChangeToLowerCase();
                editor.AddNewLines();
                editor.AddTimeStamps();
                string editedText = editor.GetEditedText();
                Console.WriteLine("Text after editing:");
                Console.WriteLine(editedText);
                File.WriteAllText(path, editedText);
                Console.WriteLine("Text in the file has been edited.");
            }
            else
            {
                Console.WriteLine("There is no such file.");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}

