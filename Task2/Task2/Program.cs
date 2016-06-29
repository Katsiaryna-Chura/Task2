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
                TextEditor editor = new TextEditor(fileText);
                string editedText = editor.GetEditedText();
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
    }
}
