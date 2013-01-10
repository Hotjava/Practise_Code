using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordCounter.FileReaders
{
    public interface IFileReader
    {
        IList<strstring ReadFile(string path);
    }
}
