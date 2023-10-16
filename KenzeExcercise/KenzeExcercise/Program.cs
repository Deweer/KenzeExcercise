using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KenzeExcercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lines = FetchLines(@"C:\Temp\input.txt");
            //remove duplicates
            //var newLines = lines.Distinct().ToList();
            var result = Process(lines.ToList(), 6, true);
            PrintResult(result);
        }

        private static void PrintResult(List<Result> result)
        {
            result.ForEach(x => Console.WriteLine(x));
        }

        private static string[] FetchLines(string path)
        {
            return File.ReadAllLines(path); ;
        }

        public static List<Result> Process(List<string> allInput, int desiredCharacters, bool allowSelfPasting)
        {
            var result = new List<Result>();

            var desiredResults = allInput
                .Where(x => x.Length == desiredCharacters)
                .ToList();
            if (!desiredResults.Any())
                return new List<Result>();

            var groupedInput = allInput
                .Where(x => x.Length < desiredCharacters)
                .GroupBy(x => x.Length)
                .ToList();
            foreach (var x in groupedInput)
            {
                foreach (var y in groupedInput.Where(group => group.Key + x.Key == desiredCharacters))
                {
                    result.AddRange(GetMatches(x.ToList(), y.ToList(), desiredResults, allowSelfPasting));
                }
            }
            return result;
        }

        private static IEnumerable<Result> GetMatches(List<string> input1, List<string> input2, List<string> possibleResults, bool allowSelfReferencing)
        {
            foreach (var x in input1)
            {
                bool hasFoundSelf = allowSelfReferencing;
                foreach (var y in input2)
                {
                    // first time strings are equal, it's possibly just the same value from the input. skip this unless this was allowed
                    if (x == y && !hasFoundSelf)
                    {
                        hasFoundSelf = true;
                        continue;
                    }
                    if (possibleResults.Contains(x + y))
                        yield return new Result(new List<string>() { x, y }, x + y);

                }
            }
            yield break;
        }
    }
}
