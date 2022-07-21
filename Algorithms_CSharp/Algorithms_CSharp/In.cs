using System.IO;

namespace Algorithms_CSharp
{
    internal partial class Program
    {
        public class In
        {
            public static IEnumerable<int> ReadInts(string filePath)
            {
                using TextReader tr = File.OpenText(filePath);
                string? lastLine;
                while ( (lastLine = tr.ReadLine()) != null)
                {
                    yield return int.Parse(lastLine);
                }
            }
        }
    }
}