// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, December 6, 2023!");


// Day 6 Pt 1 (Find number of record breaking speeds and multiply)
int[] times = new int[] { 49, 97, 94, 94 };
int[] distances = new int[] { 263, 1532, 1378, 1851 };
int marginOfError = 1;
for (int run = 0; run < times.Length; run++)
{
    int ways = 0;
    for (int i = 1; i < times[run] - 1; i++)
    {
        if (i * (times[run] - i) > distances[run])
        {
            ways++;
        }
    }
    marginOfError *= ways;
}
Console.WriteLine("Total Margin of Error is " + marginOfError);

//////////////////////////////////////////////////////////////////////

// Day 6 Pt 2 (Find Start and End speeds that win race)
double timesPt2 = 49979494;
double distancesPt2 = 263153213781851;
double waysPt2 = 0;
double start = 0;
double end = 0;

// Count forwards and stop
for (int i = 1; i < timesPt2 - 1; i++)
{
    if (i * (timesPt2 - i) > distancesPt2)
    {
        start = i; 
        Console.WriteLine(i + " is the starting point");
        break;
    }
}

// Count backwards and stop
for (double i = timesPt2; i >= start; i--)
{
    if (i * (timesPt2 - i) > distancesPt2)
    {
        Console.WriteLine(i + " is the end point");
        end = i;
        break;
    }
}
Console.WriteLine("Total ways to win Part 2: " + (end - start + 1));
 

