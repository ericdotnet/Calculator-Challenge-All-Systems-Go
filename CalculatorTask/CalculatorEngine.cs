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
            private bool _limitTwoNumbers = true;

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

                // Process default delimiters (comma and newline)
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
                var delimiterMatch = Regex.Match(input, @"^//(\[.*?\]|.)\n");
                if (!delimiterMatch.Success)
                {
                    throw new InvalidOperationException("Invalid custom delimiter format.");
                }

                string delimitersPart = delimiterMatch.Groups[1].Value;
                string numbersPart = input.Substring(delimiterMatch.Length);

                var delimiters = new List<string>();

                if (delimitersPart.StartsWith("[") && delimitersPart.EndsWith("]"))
                {
                    // Extract multiple delimiters or delimiters of arbitrary length
                    foreach (Match match in Regex.Matches(delimitersPart, @"\[([^\]]+?)\]"))
                    {
                        delimiters.Add(match.Groups[1].Value);
                    }
                }
                else
                {
                    // Single character delimiter
                    delimiters.Add(delimitersPart);
                }

                // Replace custom delimiters with a comma
                foreach (var delimiter in delimiters)
                {
                    numbersPart = numbersPart.Replace(delimiter, ",");
                }

                return ProcessNumbers(numbersPart);
            }

            private string ProcessNumbers(string numbers)
            {
                // Split the numbers by comma
                var numList = numbers.Split(',')
                                      .Select(s => s.Trim())
                                      .Select(s =>
                                      {
                                          if (int.TryParse(s, out int result))
                                          {
                                              return result > 1000 ? 0 : result;
                                          }
                                          return 0; // Invalid numbers converted to 0
                                      })
                                      .ToList();

                // Handle negative numbers
                var negatives = numList.Where(n => n < 0).ToList();
                if (negatives.Any())
                {
                    throw new InvalidOperationException("Negative numbers not allowed: " + string.Join(", ", negatives));
                }

                // Initial requirement: limit to 2 numbers
                if (_limitTwoNumbers && numList.Count > 2)
                {
                    throw new InvalidOperationException("A maximum of 2 numbers is allowed.");
                }

                // Calculate the sum of valid numbers
                int sum = numList.Sum();
                return sum.ToString();
            }

            public void RemoveNumberLimit()
            {
                _limitTwoNumbers = false;
            }
        
    }
}





