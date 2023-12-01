using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 0;
            int tens = 0;
            int ones = 0;
            int row = 0;
            try
            {
                // Create a Stream Reader
                using (var sr = new StreamReader("data.txt"))
                {
                    string line = "";
                    //Read each line unless null
                    while ((line = sr.ReadLine()) != null)
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (int.TryParse(line[i].ToString(), out int left))
                            {
                                tens = left * 10;
                                break;
                            }
                        }
                        for (int i = line.Length - 1; i > -1; i--)
                        {
                            if (int.TryParse(line[i].ToString(), out int right))
                            {
                                ones = right;
                                break;
                            }
                        }
                        row = tens + ones;
                        Console.WriteLine(row);
                        total += row;
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
