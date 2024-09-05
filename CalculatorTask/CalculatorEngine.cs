using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorTask
{
    public class CalculatorEngine
    {
        public string Calculate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "0";
            }

            // Check for custom delimiter
            if (input.StartsWith("//"))
            {
                return ProcessCustomDelimiter(input);
            }

            // Process default delimiters
            string[] delimiters = { ",", "\n" };
            string numbers = input;

            foreach (string delimiter in delimiters)
            {
                if (numbers.Contains(delimiter))
                {
                    numbers = numbers.Replace(delimiter, ",");
                }
            }

            return ProcessNumbers(numbers);
        }

        public string ProcessCustomDelimiter(string input)
        {
            var delimiterMatch = Regex.Match(input, @"^//(\[.*?\])\n");
            if (!delimiterMatch.Success)
            {
                throw new InvalidOperationException("Invalid custom delimiter format.");
            }

            string delimitersPart = delimiterMatch.Groups[1].Value;
            string numbersPart = input.Substring(delimiterMatch.Length);

            // Extract delimiters
            var delimiters = new List<string>();
            foreach (Match match in Regex.Matches(delimitersPart, @"\[([^\]]+?)\]"))
            {
                delimiters.Add(match.Groups[1].Value);
            }

            // Replace custom delimiters with comma
            foreach (var delimiter in delimiters)
            {
                numbersPart = numbersPart.Replace(delimiter, ",");
            }

            return ProcessNumbers(numbersPart);
        }

        private string ProcessNumbers(string numbers)
        {
            var numList = numbers.Split(',')
                                  .Select(s => s.Trim())
                                  .Select(s =>
                                  {
                                      if (int.TryParse(s, out int result))
                                      {
                                          return result > 1000 ? 0 : result;
                                      }
                                      return 0;
                                  })
                                  .ToList();

            var negatives = numList.Where(n => n < 0).ToList();
            if (negatives.Any())
            {
                throw new InvalidOperationException("Negative numbers not allowed: " + string.Join(", ", negatives));
            }

            int sum = numList.Sum();
            return sum.ToString();
        }
    }
}





