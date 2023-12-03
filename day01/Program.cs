using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        public static int GetLeftDigit(string line)
        {
            Dictionary<string, int> digits = new Dictionary<string, int>();
            digits.Add("one", 1);
            digits.Add("two", 2);
            digits.Add("three", 3);
            digits.Add("four", 4);
            digits.Add("five", 5);
            digits.Add("six", 6);
            digits.Add("seven", 7);
            digits.Add("eight", 8);
            digits.Add("nine", 9);

            int left = 0;
            int right = 1;

            if (int.TryParse(line[left].ToString(), out int leftDigit))
            {
                Console.WriteLine("Left digit is [left]" + leftDigit);
                return leftDigit;
            }

            while (right < line.Length)
            {
                var currentDigits = digits.ToDictionary(x => x.Key, x => x.Value);
                while ((currentDigits.Count > 0) && (right < line.Length))
                {
                    if (int.TryParse(line[right].ToString(), out int rightDigit))
                    {
                        Console.WriteLine("Left digit is [right]" + rightDigit);
                        return rightDigit;
                    }
                    string substring = line.Substring(left, right - left + 1);
                    List<string> keysToRemove = new List<string>();
                    foreach (var digit in currentDigits)
                    {
                        if (digit.Key == substring)
                        {
                            Console.WriteLine("Left digit is" + digit.Value);
                            return digit.Value;
                        }
                        if (!digit.Key.StartsWith(substring))
                        {
                            keysToRemove.Add(digit.Key);
                        }
                    }
                    foreach (var key in keysToRemove)
                    {
                        currentDigits.Remove(key);
                    }
                    right++;
                }
                left++;
                right = left + 1;
            }
            return 0;
        }
        public static int GetRightDigit(string line)
        {
            Dictionary<string, int> digits = new Dictionary<string, int>();
            digits.Add("one", 1);
            digits.Add("two", 2);
            digits.Add("three", 3);
            digits.Add("four", 4);
            digits.Add("five", 5);
            digits.Add("six", 6);
            digits.Add("seven", 7);
            digits.Add("eight", 8);
            digits.Add("nine", 9);

            
            int right = line.Length - 1;
            int left = right - 1;

            if (int.TryParse(line[right].ToString(), out int rightDigit))
            {
                Console.WriteLine("[R] Right digit is [rightmost]" + rightDigit);
                return rightDigit;
            }

            while (left > -1)
            {
                var currentDigits = digits.ToDictionary(x => x.Key, x => x.Value);
                while ((currentDigits.Count > 0) && (left > -1))
                {
                    if (int.TryParse(line[left].ToString(), out int leftMost))
                    {
                        Console.WriteLine("[R] Right digit is [leftmost] " + leftMost);
                        return leftMost;
                    }
                    string substring = line.Substring(left, right - left + 1);
                    List<string> keysToRemove = new List<string>();
                    foreach (var digit in currentDigits)
                    {
                        if (digit.Key == substring)
                        {
                            Console.WriteLine("[R] Right digit is" + digit.Value);
                            return digit.Value;
                        }
                        if (!digit.Key.EndsWith(substring))
                        {
                            keysToRemove.Add(digit.Key);
                        }
                    }
                    foreach (var key in keysToRemove)
                    {
                        currentDigits.Remove(key);
                    }
                    left--;
                }
                //right = left + 1;
                right--;
                left = right - 1;
            }
            return 0;
        }

        static void Main(string[] args)
        {
            int total = 0;
            int tens = 0;
            int ones = 0;
            int row = 0;
            int rowIndex = 1;

            try
            {
                // Create a Stream Reader
                using (var sr = new StreamReader("data.txt"))
                //using (var sr = new StreamReader("tests.txt"))

                {
                    string line = "";
                    //Read each line unless null

                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine("\n" + rowIndex + "\t" + line);
                        tens = GetLeftDigit(line) * 10;
                        //for (int i = 0; i < line.Length; i++)
                        //{
                        //    if (int.TryParse(line[i].ToString(), out int left))
                        //    {
                        //        tens = left * 10;
                        //        break;
                        //    }
                        //}
                        ones = GetRightDigit(line);
                        //for (int i = line.Length - 1; i > -1; i--)
                        //{
                        //    if (int.TryParse(line[i].ToString(), out int right))
                        //    {
                        //        ones = right;
                        //        break;
                        //    }
                        //}
                        row = tens + ones;
                        Console.WriteLine(row);
                        total += row;
                        rowIndex++;
                    }
                    sr.Close();
                    Console.WriteLine("Grand Total is " + total);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read");
                Console.WriteLine(e.Message);
            }
        }
    }
}
