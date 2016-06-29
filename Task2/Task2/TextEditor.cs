using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class TextEditor
    {
        string text;

        public TextEditor(string text)
        {
            this.text = text;
        }

        public string GetEditedText()
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
            if (text.Length != 0)
            {
                editedText = editedText + GetTimeStamp() + " " + text;
            }
            return editedText;
        }

        public string GetTimeStamp()
        {
            DateTime currentTime = DateTime.Now;
            string dateTimeFormat = "MM/dd/yyyy hh:mm:ss:ff";
            return currentTime.ToString(dateTimeFormat);
        }
    }
}
