using Syed.StringCalculator.Core;
using Syed.StringCalculator.Core.Exceptions;
using System;

namespace Syed.AddNumbers.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            var calculator = new BasicStringCalculator();

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Basic String Calculator. Type 'Exit' to quit.");
            Console.WriteLine("Multi line input not supported - run Acceptance Tests to demo multi line support.");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();

            do
            {
                try
                {
                    var result = calculator.Add(input);
                    Console.WriteLine($"Sum = {result}");
                    Console.WriteLine();
                }
                catch (InvalidNumbersException iex)
                {
                    Console.WriteLine(iex.Message);
                }

                Console.WriteLine("Enter some delimited numbers...");
                input = Console.ReadLine();

            } while (!input.Equals("exit", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
