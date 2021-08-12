using System;
using System.Collections.Generic;
using System.Text;

namespace CodeKata.Kata13.Console.Services
{
    public interface ILineCountingService
    {
        bool IsValidLine(string line);
        string RemoveCharactersBetween(string inputString, string startingCharacters, string endingCharacters);
        int GetNumberOfLines(string inputString);
    }
}
