// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, December 2, 2023!");

Dictionary<string, int> cubeLimits = new Dictionary<string, int>();
cubeLimits.Add("red", 12);
cubeLimits.Add("green", 13);
cubeLimits.Add("blue", 14);

Dictionary<string, int> cubeMinimum = new Dictionary<string, int>();
cubeMinimum.Add("red", 1);
cubeMinimum.Add("green", 1);
cubeMinimum.Add("blue", 1);

static Dictionary<string, int> ParseStringToDictionary(string input)
{
    Dictionary<string, int> result = new Dictionary<string, int>();

    // Split the input string by commas and spaces
    string[] pairs = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

    foreach (string pair in pairs)
    {
        // Split each pair into color and count
        string[] parts = pair.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 2 && int.TryParse(parts[0], out int count))
        {
            // Add the color and count to the dictionary
            result[parts[1]] = count;
        }
        else
        {
            // Handle invalid input
            Console.WriteLine($"Invalid input: {pair}");
        }
    }

    return result;
}

static Dictionary<string, int> UpdateMaxHand(Dictionary<string, int> hand, Dictionary<string, int> maxHand)
{
    foreach (string color in hand.Keys)
    {
        if (maxHand.ContainsKey(color))
        {
            maxHand[color] = Math.Max(maxHand[color], hand[color]);
        }
        else
        {
            maxHand[color] = hand[color];
        }
    }
    return maxHand;
}

bool CheckPossible(Dictionary<string, int> hand)
{
    foreach (string color in hand.Keys)
    {
        if (hand[color] > cubeLimits[color])
        {
            return false;
        }
    }
    return true;
}



try // Part 1 - Sum up which games are possible
{
    using var sr = new StreamReader("data.txt");
    string line = "";
    int totalGamePoints = 0;

    while ((line = sr.ReadLine()) != null)
    //{   // Part 1
    //    string[] game = line.Split(':');
    //    // Use LINQ to filter out non-digit characters
    //    string numbersOnly = new string(game[0].Where(char.IsDigit).ToArray());
    //    string[] gameNumber = game[0].Split("Game ");
    //    string[] set = game[1].Split(';');
    //    Console.WriteLine($"Game: {numbersOnly}");
    //    bool possible = true;
    //    foreach (string hand in set)
    //    {
    //        var output = ParseStringToDictionary(hand);
    //        if (CheckPossible(output))
    //        {
    //            Console.ForegroundColor = ConsoleColor.Green;
    //            Console.WriteLine($"\tPossible: {hand}");
    //        }
    //        else
    //        {
    //            Console.ForegroundColor = ConsoleColor.Red;
    //            Console.WriteLine($"\tImpossible: {hand}");
    //            possible = false;
    //            break;
    //        }

    //    }
    //    if (possible)
    //    {
    //        totalGamePoints += int.Parse(numbersOnly);
    //    }
    //    Console.ForegroundColor = ConsoleColor.White;

    //}
    //Console.WriteLine($"Total Game Points: {totalGamePoints}");
    {   // Part 2
        string[] game = line.Split(':');
        // Use LINQ to filter out non-digit characters
        string numbersOnly = new string(game[0].Where(char.IsDigit).ToArray());
        string[] gameNumber = game[0].Split("Game ");
        string[] set = game[1].Split(';');
        // Makes a shallow copy of a dictionary
        var maxHand = cubeMinimum.ToDictionary(entry => entry.Key, entry => entry.Value);

        Console.WriteLine($"Game: {numbersOnly}");
        foreach (string hand in set)
        {
            var output = ParseStringToDictionary(hand);
            UpdateMaxHand(output, maxHand);
        }

        int subTotal = 1;
        foreach (string color in maxHand.Keys)
        {
            if (color == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (color == "green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (color == "blue")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.WriteLine($"\t{color}: {maxHand[color]}");
            Console.ForegroundColor = ConsoleColor.White;
            subTotal *= maxHand[color];
        }
        Console.WriteLine($"\tSubtotal: {subTotal}");
        totalGamePoints += subTotal;
        
    }
    Console.WriteLine($"Total Game Points: {totalGamePoints}");

}
catch (IOException e)
{
    Console.WriteLine("The file could not be read");
    Console.WriteLine(e.Message);
}

