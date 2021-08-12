using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeKata.Kata13.Console.Services
{
    public class LineCountingService : ILineCountingService
    {
        //Delete all text between opening and closing /* */
        //Split incoming string by newline character
        //Count number of lines

        public int GetNumberOfLines(string inputString)
        {

            inputString = RemoveCharactersBetween(inputString, "/*", "*/");

            var inputStringArray = inputString.Split("\n").ToList();
            var numberOfLines = 0;

            inputStringArray.ForEach(line =>
            {
                line = line.Trim();
                line = line.Replace("\r", "");

                if (IsValidLine(line))
                    numberOfLines++;
            });

            return numberOfLines;
        }

        public bool IsValidLine(string line)
        {
            if (string.IsNullOrEmpty(line))
                return false;

            if (line.StartsWith("//"))
                return false;

            return true;
        }

        public string RemoveCharactersBetween(string inputString, string startingCharacters, string endingCharacters)
        {
            if (!inputString.Contains(startingCharacters) || !inputString.Contains(endingCharacters))
                return inputString;

            int start = inputString.IndexOf(startingCharacters);
            int end = inputString.IndexOf(endingCharacters, start);

            if (end < 0)
            {
                inputString = inputString.Remove(start, startingCharacters.Length);
                return RemoveCharactersBetween(inputString, startingCharacters, endingCharacters);
            }


            inputString = inputString.Remove(start, end + endingCharacters.Length - start);
            return RemoveCharactersBetween(inputString, startingCharacters, endingCharacters);

        }

    }
}
