using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AdventOfCode
{
    internal static class FileReader
    {
        internal static IEnumerable<string> ReadFile(string filePath)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);

            return File.ReadLines(path);
        }
    }
}