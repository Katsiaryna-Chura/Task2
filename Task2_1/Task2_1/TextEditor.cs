using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1
{
    public class TextEditor
    {
        string text;
        List<string> sentences;

        public TextEditor(string text)
        {
            this.text = text;
            sentences = new List<string>();
            ParseTextToSentences();
        }

        private void ParseTextToSentences()
        {
            char[] endOfSentence = { '.', '!', '?' };
            int index;
            while ((index = text.IndexOfAny(endOfSentence)) != -1)
            {
                char nextSymbol;
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
                nextSymbol = text[index + 1];
                if (nextSymbol == '\n')
                {
                    sentences.Add(text.Substring(0, index + 1));
                    text = text.Substring(index + 2);
                    continue;
                }
                sentences.Add(text.Substring(0, index + 1));
                text = text.Substring(index + 1);
            }
            if (text.Length != 0)
            {
                sentences.Add(text);
            }
        }

        public void ChangeToLowerCase()
        {
            for (int i = 0; i < sentences.Count; i++)
            {
                sentences[i] = sentences[i].ToLower();
            }
        }

        public void AddNewLines()
        {
            for (int i = 0; i < sentences.Count; i++)
            {
                sentences[i] += "\n";
            }
        }

        public void AddTimeStamps()
        {
            for (int i = 0; i < sentences.Count; i++)
            {
                sentences[i] = GetTimeStamp() + " " + sentences[i];
            }
        }

        public string GetEditedText()
        {
            string editedText = "";
            foreach (var sentence in sentences)
            {
                editedText += sentence;
            }
            return editedText;
        }

        public string GetTimeStamp()
        {
            DateTime currentTime = DateTime.Now;
            string dateTimeFormat = "dd-MM-yyyy hh:mm:ss:fff";
            return currentTime.ToString(dateTimeFormat);
        }
    }
}

