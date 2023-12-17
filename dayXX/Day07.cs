using System;

namespace Day07
{
    public class Day07
    {
        /*
         * Group hands by group
         * Then sort them by ranking
         * AKQJT98765432 (High -> Lowest)
         */
        public enum HandType
        {
            HighCard,   // 5 cards
            OnePair,    // 4 cards, max = 2
            TwoPair,    // 3 cards, max 2 of each
            ThreeOfAKind, // 3 cards, max 3 
            FullHouse,      // 2 cards, max 3 of each
            FourOfAKind,    //  2 cards, max 4
            FiveOfAKind     // 1 card, max 5
        }
        public class Hand
        {
            public Hand(string hand, int bid)
            {
                this.hand = hand;
                this.bid = bid;
            }
            public string hand;
            public int bid;
            public HandType handType;
            private Dictionary<char, int> sortedCards = new Dictionary<char, int>();

            /// <summary>
            /// Converts a string to a dictionary of cards
            /// </summary>
            public void CountCards()
            {
                foreach (char c in this.hand)
                {
                    if (sortedCards.ContainsKey(c))
                    {
                        sortedCards[c]++;
                    }
                    else
                    {
                        sortedCards[c] = 1;
                    }
                }
            }

            public void DisplayCards()
            {
                foreach (char c in sortedCards.Keys)
                {
                    Console.WriteLine("\t" + c + ": " + sortedCards[c]);
                }
            }

            //private void CategorizeHand(Dictionary<string, int> sortedHand)
            //{
            //    if (sortedHand.Count == 5)
            //    {
            //        this.handType = HandType.HighCard;
            //    }
            //    else if (sortedHand.Count == 4)
            //    {
            //        this.handType = HandType.FourOfAKind;
            //    }
            //    else if (sortedHand.Contains("AAA"))
            //    {
            //        this.handType = HandType.ThreeOfAKind;
            //    }
            //    else if (sortedHand.Contains("AA"))
            //    {
            //        this.handType = HandType.TwoPair;
            //    }
            //    else if (sortedHand.Contains("A"))
            //    {
            //        this.handType = HandType.OnePair;
            //    }
            //    else
            //    {
            //        this.handType = HandType.HighCard;
            //    }
            //}
        }
        public static void Day07A()
        {
            try
            {
                using (var sr = new StreamReader("data07.txt"))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine("\t" + line);
                        string[] play = line.Split(" ");
                        Hand hand1 = new Hand(play[0], int.Parse(play[1]));
                        hand1.CountCards();
                        hand1.DisplayCards();
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