using System;
using System.Collections.Generic;
using System.Text;

namespace CodeKata.Kata13.Console.Services
{
    public class LineCountingService : ILineCountingService
    {
        //Delete all text between opening and closing /* */
        //Split incoming string by newline character
        //Count number of lines

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

            return string.Empty;
        }

    }
}
