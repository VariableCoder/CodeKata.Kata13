using System;
using System.Collections.Generic;
using System.Text;

namespace CodeKata.Kata13.Console.Services
{
    public interface ITestRunnerService
    {
        int GetUsersInputTestScenario();
        int RunTestScenario(int v);
    }
}
