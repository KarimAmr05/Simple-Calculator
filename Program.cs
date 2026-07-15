using System;
using System.Collections.Generic;

public static class OperationRegistry
{
    private static readonly Dictionary<string, (string Description, int ArgCount, Func<double[], double> Execute)>
        _operations = new(StringComparer.OrdinalIgnoreCase)
        {
            ["+"] = ("Addition", 2, args => args[0] + args[1]),
            ["-"] = ("Subtraction", 2, args => args[0] - args[1]),
            ["*"] = ("Multiplication", 2, args => args[0] * args[1]),
            ["/"] = ("Division", 2, args => args[1] == 0 ? throw new DivideByZeroException("Cannot divide by zero.") : args[0] / args[1]),
            ["%"] = ("Modulus", 2, args => args[1] == 0 ? throw new DivideByZeroException("Cannot modulus by zero.") : args[0] % args[1]),
            ["^"] = ("Power", 2, args => Math.Pow(args[0], args[1])),
            ["sqrt"] = ("Square Root", 1, args => args[0] < 0 ? throw new ArgumentException("Cannot sqrt negative.") : Math.Sqrt(args[0])),
            ["abs"] = ("Absolute Value", 1, args => Math.Abs(args[0])),
            ["max"] = ("Maximum", 2, args => Math.Max(args[0], args[1])),
            ["min"] = ("Minimum", 2, args => Math.Min(args[0], args[1]))
        };

    public static bool TryGetOperation(string name, out (string Description, int ArgCount, Func<double[], double> Execute) op)
        => _operations.TryGetValue(name, out op);

    public static IEnumerable<(string Name, string Description)> GetMenuItems()
    {
        foreach (var kvp in _operations)
            yield return (kvp.Key, kvp.Value.Description);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Simple Calculator (type 'ans' to use the last result)");

        double? lastResult = null;  // Stores the result of the last successful operation

        while (true)
        {
            PrintMenu();

            Console.Write("\nEnter operation: ");
            string input = Console.ReadLine().Trim();

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

            if (!OperationRegistry.TryGetOperation(input, out var op))
            {
                Console.WriteLine("Invalid operation.");
                continue;
            }

            try
            {
                // Read arguments, passing the last result so the user can use 'ans'
                double[] args = ReadArguments(op.ArgCount, lastResult);
                double result = op.Execute(args);

                Console.WriteLine($"Result = {result}");

                // Store this result for the next operation
                lastResult = result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        Console.WriteLine("\nCalculator closed.");
    }

    private static void PrintMenu()
    {
        Console.WriteLine("\nAvailable operations:");
        foreach (var item in OperationRegistry.GetMenuItems())
            Console.WriteLine($"{item.Name,-5} {item.Description}");
        Console.WriteLine("exit   Exit Calculator");
    }

    private static double[] ReadArguments(int count, double? lastResult)
    {
        double[] args = new double[count];

        for (int i = 0; i < count; i++)
        {
            // Build a helpful prompt
            string label = count == 1 ? "number" : (i == 0 ? "first number" : "second number");
            string lastHint = lastResult.HasValue ? $" (or 'ans' for {lastResult.Value})" : "";
            Console.Write($"Enter {label}{lastHint}: ");

            string userInput = Console.ReadLine().Trim();

            // Check if user wants the last result
            if (userInput.Equals("ans", StringComparison.OrdinalIgnoreCase))
            {
                if (lastResult.HasValue)
                {
                    args[i] = lastResult.Value;
                    Console.WriteLine($"  → Using last result: {args[i]}");
                }
                else
                {
                    Console.WriteLine("  No previous result available. Please enter a number.");
                    i--; // Stay on the same argument and ask again
                }
            }
            else
            {
                // Try to parse as a normal number
                if (double.TryParse(userInput, out double value))
                {
                    args[i] = value;
                }
                else
                {
                    Console.WriteLine("  Invalid input. Please enter a number or 'ans'.");
                    i--; // Retry this argument
                }
            }
        }

        return args;
    }
}