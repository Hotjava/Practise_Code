using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordCounter.FileReaders
{
    public class LineReaders : IFileReaFileReader
    {
        public override  string ReadFile(string path)
        {
            StringBuilder sb  = new StringBuilder();
            StreamReader reader;
            using (reader = new StreamReader(File.Open(path, FileMode.Open)))
            {
                while (reader.Peek() >= 0)
                {
                   sb.Append(reader.ReadLine());
                }
            }
            return sb.ToString();
        }
    }
}
