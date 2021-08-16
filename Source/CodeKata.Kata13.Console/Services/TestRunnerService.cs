using System;
using System.Collections.Generic;
using System.Text;

namespace CodeKata.Kata13.Console.Services
{
    public class TestRunnerService : ITestRunnerService
    {
        readonly ILineCountingService _lineCoutingService;
        readonly string[] _inputStringArray = new string[] { "asdfasd", "asdflkkk", "kkslkkss" };

        public TestRunnerService(ILineCountingService lineCountingService)
        {
            _lineCoutingService = lineCountingService;
        }

        public int GetUsersInputTestScenario()
        {

            System.Console.WriteLine("Please enter a number corresponding to the desired test scenario to run.");
            System.Console.Write($"The number entered should vary between 1 and {_inputStringArray.Length}: ");

            var testScenarioString = System.Console.ReadLine();
            int testScenario;

            while (!int.TryParse(testScenarioString, out testScenario) || testScenario < 1 || testScenario > 3)
            {
                System.Console.WriteLine("Please enter a valid integer between 1 and 3");
                testScenarioString = System.Console.ReadLine();
            }

            return testScenario;
        }

        public int RunTestScenario(int testScenario)
        {
            return _lineCoutingService.GetNumberOfLines(_inputStringArray[testScenario - 1]);
        }
    }
}
