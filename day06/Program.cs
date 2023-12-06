// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// input part 1
int[] times = new int[] { 49, 97, 94, 94 };
int[] distances = new int[] { 263, 1532, 1378, 1851 };
// input part 2
int marginOfError = 1;
for (int run = 0; run < times.Length; run++)
{
    int ways = 0;
    for (int i = 1; i < times[run] - 1; i++)
    {
        Console.WriteLine("For Race " + i);
        if (i * (times[run] - i) > distances[run])
        {
            Console.Write(i + " ");
            ways++;
        }
    }
    marginOfError *= ways;
}



Console.WriteLine("Total Margin of Error is " + marginOfError);