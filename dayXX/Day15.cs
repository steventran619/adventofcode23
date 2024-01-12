using System;

namespace Day15
{
    public class Day15
    {
        static public int HashAlgorithm(string hashString)
        {
            int sum = 0;
            foreach (char c in hashString)
            {
                int asciiValue = (int)c;
                sum += asciiValue;
                sum *= 17;
                sum %= 256;
            }
            return sum;
        }
      
        public static void Day15A()
        {
            int totalSum = 0;
            try
            {
                using (var sr = new StreamReader("data15.txt"))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        List<string> steps = line.Split(',').ToList();
                        foreach (string num in steps)
                        {
                            int stepHash = HashAlgorithm(num);
                            totalSum += stepHash;
                        }
                    }
                    Console.WriteLine("\nGrand Total is " + totalSum);
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