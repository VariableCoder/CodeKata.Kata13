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

        public int RunTestScenario(int testScenario)
        {
            return _lineCoutingService.GetNumberOfLines(_inputStringArray[testScenario]);
        }
    }
}
