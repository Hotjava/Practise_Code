using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WordCounter.FileReaders
{
    public abstract  class FileReader:IFileReader

    {
       
        public IList<string> ProcessFile(string path)
        {
            string content = ReadFile(path);
            return ProcessText(content);

        }

        protected IList<string> ProcessText(string original)
        {
            // if the word not start with a number or letter, it is not a word.

            Regex regExp = new Regex("[^a-zA-Z0-9 -]");
            regExp.Replace(original, " ");

            return original.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        }

        public  abstract  string ReadFile(string path);
    }
}
