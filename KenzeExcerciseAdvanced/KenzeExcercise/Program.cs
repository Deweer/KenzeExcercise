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
            //var newLines = 
            var result = Process(lines.Distinct().ToList(), 6, true);
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
            // call fill matches with correect inputs lists

            return result;
        }

        private static void FillMatches(List<List<string>> inputs, List<string> currentPickedWords, List<string> possibleResults, List<Result> matches)
        {
            // the final list is queued, check if word matches
            if (!inputs.Any())
            {
                //if matches, add to result
                var result = string.Join("", currentPickedWords);
                if (possibleResults.Contains(result))
                {
                    matches.Add(new Result(currentPickedWords, result));
                }
                return;
            }

            // if final list s not yet queued, pick another word from the list and pass the remaining to be checked lists
            foreach(var list in inputs)
            {
                foreach(var input in list)
                {
                    var tempList = inputs.GetRange(1, inputs.Count - 2);
                    currentPickedWords.Add(input);
                    FillMatches(tempList, currentPickedWords, possibleResults, matches);
                    currentPickedWords.RemoveAt(currentPickedWords.Count - 1);
                }
            }
        }
    }
}
