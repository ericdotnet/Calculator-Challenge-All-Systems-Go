// See https://aka.ms/new-console-template for more information

using CalculatorTask;

var calculator = new CalculatorEngine();

while (true)
{
    try
    {
        Console.Write("Enter calculation string: ");
        string input = Console.ReadLine();
        if (input == null)
        {
            break;
        }

        string result = calculator.Calculate(input);
        Console.WriteLine("Result: " + result);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}
Console.WriteLine("Hello, World!");
