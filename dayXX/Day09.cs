using System;

namespace Day09
{
    public class Day09
    {
        static public bool AllZeroes(List<int> someList)
        {
            foreach (int num in someList)
            {
                if (num != 0)
                {
                    return false;
                }
            }
            return true;
        }
        static public int GetAdditiveSum(List<int> history)
        {
            int sum = history.Last();
            int count = 1;
            bool difference = false;

            List<int> previousHistory = history.ToList();
            while (!difference) {
                List<int> newHistory = new List<int>(previousHistory.Count - 1);
                newHistory.AddRange(Enumerable.Repeat(0, previousHistory.Count - 1));
                foreach (int num in previousHistory)
                {
                    Console.Write(num + " ");   
                }
                Console.WriteLine();
                for (int i = previousHistory.Count - 1; i > 0; i--)
                {
                    newHistory[i - 1] = previousHistory[i] - previousHistory[i - 1];
                    //Console.Write(newHistory[i - 1] + " ");
                }
                //count++;
                sum += newHistory.Last();
                difference = AllZeroes(newHistory);
                previousHistory = newHistory.ToList();
            }
            return sum;
        }
        static public int GetSubtractiveSum(List<int> history)
        {
            int sum = history.First();
            int count = 1;
            bool difference = false;

            List<int> previousHistory = history.ToList();
            while (!difference)
            {
                List<int> newHistory = new List<int>(previousHistory.Count - 1);
                newHistory.AddRange(Enumerable.Repeat(0, previousHistory.Count - 1));
                foreach (int num in previousHistory)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
                for (int i = previousHistory.Count - 1; i > 0; i--)
                {
                    newHistory[i - 1] = previousHistory[i] - previousHistory[i - 1];
                }
                count++;
                sum -= (int)Math.Pow(-1, count) * newHistory.First();
                difference = AllZeroes(newHistory);
                previousHistory = newHistory.ToList();
            }
            return sum;
        }
        public static void Day09A()
        {
            int totalSum = 0;
            try
            {
                using (var sr = new StreamReader("data09.txt"))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        List<string> row = line.Split(' ').ToList();
                        List<int> rowInts = row.Select(int.Parse).ToList();
                        int RowSum = GetAdditiveSum(rowInts);
                        Console.WriteLine("\t" + RowSum);
                        totalSum += RowSum;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nGrand Total is " + totalSum);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read");
                Console.WriteLine(e.Message);
            }
        }
        public static void Day09B()
        {
            int totalSum = 0;
            try
            {
                using (var sr = new StreamReader("data09.txt"))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        List<string> row = line.Split(' ').ToList();
                        List<int> rowInts = row.Select(int.Parse).ToList();
                        int RowSum = GetSubtractiveSum(rowInts);
                        Console.WriteLine("\t" + RowSum);
                        totalSum += RowSum;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nGrand Total is " + totalSum);
                    Console.ForegroundColor = ConsoleColor.White;
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