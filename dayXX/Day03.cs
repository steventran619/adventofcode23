using System;

namespace Day03
{
    public class Day03
    {
        public static void Day03A()
        {
            try
            {
                using (var sr = new StreamReader("data03.txt"))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }

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