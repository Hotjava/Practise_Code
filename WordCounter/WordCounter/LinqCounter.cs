using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordCounter
{
    public class LinqCounter
    {
        private List<string> Input;

        public LinqCounter(List<string> input)
        {
            Input = input;
        }

        public List<WordCount> CountWords()
        {
            var distinctWord = (from string word in Input
                                where word.Length > 0
                                group word by word
                                into rowCount
                                select new WordCount(rowCount.Key, rowCount.Count())).ToList();
            return distinctWord;
        }
    }

    public class WordCount
    {
        public string Word;
        public int Count;

        public WordCount(string word, int count)
        {
            Word = word;
            Count = count;
        }

        
    }
}
