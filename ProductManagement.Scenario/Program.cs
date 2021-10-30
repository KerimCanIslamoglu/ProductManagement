using ProductManagement.Scenario.Scenarios;
using System;
using System.Threading.Tasks;

namespace ProductManagement.Scenario
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var firstScenario = new FirstScenario();
            var secondScenario = new SecondScenario();

            Console.WriteLine("First scenario is starting...");
            Console.WriteLine("------------------------------------------------------");

            await firstScenario.Start();

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("First scenario has ended.");


            Console.WriteLine("*****************************************************");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("*****************************************************");

            Console.WriteLine("Second scenario is starting.");
            Console.WriteLine("------------------------------------------------------");

            await secondScenario.Start();

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Second scenario has ended.");

            Console.ReadKey();
        }
    }
}
