// See https://aka.ms/new-console-template for more information
using System.Numerics;

Console.WriteLine("Hello, World!");

double totalPoints = 0;


//try // Part 1
//{
//    using var sr = new StreamReader("data.txt");
//    string line = "";
//    while ((line = sr.ReadLine()) != null)
//    {
//        //Console.WriteLine(line);
//        string[] card = line.Split(':');
//        string[] numbers = card[1].Split('|');
//        var winningNumbers = numbers[0].Split(' ');
//        var myNumbers = numbers[1].Split(' ');
//        HashSet<int> winningSet = new HashSet<int>();
//        int tally = 0;
//        Console.ForegroundColor = ConsoleColor.White;

//        foreach (var number in winningNumbers)
//        {
//            if (int.TryParse(number, out int result))
//            {
//                winningSet.Add(result);
//            }
//        }

//        //Console.WriteLine("Available: ");
//        foreach (var number in myNumbers)
//        {
//            if (int.TryParse(number, out int result) && (result != 0))
//            {
//                if (winningSet.Contains(result))
//                {
//                    Console.ForegroundColor = ConsoleColor.Green;
//                    Console.Write(result + " ");
//                    tally += 1;
//                }
//                else
//                {
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.Write(result + " ");
//                }
//            }
//        }
//        Console.ForegroundColor = ConsoleColor.White;
//        double cardPoints = tally > 0 ? Math.Pow(2, tally - 1) : 0;
//        totalPoints += cardPoints;
//        Console.WriteLine(card[0] + " = " + cardPoints.ToString());
//        Console.WriteLine();

//    }
//}
//catch (IOException e)
//{
//    Console.WriteLine("The file could not be read");
//    Console.WriteLine(e.Message);
//}



try // Part 2
{
    using var sr = new StreamReader("data.txt");
    string line = "";
    int cardNumber = 1;
    Dictionary <int, int> cardCount = new Dictionary<int, int>();
    cardCount.Add(1, 1);

    while ((line = sr.ReadLine()) != null)
    {
        //Console.WriteLine(line);
        string[] card = line.Split(':');
        string[] numbers = card[1].Split('|');
        var winningNumbers = numbers[0].Split(' ');
        var myNumbers = numbers[1].Split(' ');
        HashSet<int> winningSet = new HashSet<int>();
        int tally = 0;
        Console.ForegroundColor = ConsoleColor.White;

        foreach (var number in winningNumbers)
        {
            if (int.TryParse(number, out int result))
            {
                winningSet.Add(result);
            }
        }

        //Console.WriteLine("Available: ");
        foreach (var number in myNumbers)
        {
            if (int.TryParse(number, out int result) && (result != 0))
            {
                if (winningSet.Contains(result))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(result + " ");
                    tally += 1;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(result + " ");
                }
            }
        }
        Console.ForegroundColor = ConsoleColor.White;

        //Check for current card number in dictionary
        if (cardCount.ContainsKey(cardNumber) == false)
        {
            cardCount.Add(cardNumber, 1);
        }
        // Update following cards
        for (int i = cardNumber + 1; i <= cardNumber + tally; i++)
        {
            if (cardCount.ContainsKey(i) == false)
            {
                cardCount.Add(i, 1);
            }
            cardCount[i] += cardCount[cardNumber]   ;
        }
        totalPoints += cardCount[cardNumber];
        Console.WriteLine(card[0] + " Copies = " + cardCount[cardNumber].ToString());
        Console.WriteLine();
        cardNumber++;

    }
}
catch (IOException e)
{
    Console.WriteLine("The file could not be read");
    Console.WriteLine(e.Message);
}

Console.WriteLine("Total Points = " + totalPoints.ToString());