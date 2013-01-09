using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordCounter.FileReaders
{
    public class LineReaders : IFileReader
    {
        public IList<string> ReadFile(string path)
        {
            StreamReader reader = new StreamReader(File.Open(path,FileMode.Open));

            List<string> words = new List<string>();

            while (reader.ReadBlock())
            {
                
            }
        }
    }
}
