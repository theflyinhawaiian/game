
using System;
using System.Runtime.InteropServices;

public class Program
{
    public static void Main(string[] args)
    {
        int[] playerCards = new int[52];
        var cardsDealt = 0;
        

        while (cardsDealt < 2)
        {
            var random = new Random();
            var ranNum = random.Next(52);

            var duplicateCard = false;

            for (int j = 0; j < playerCards.Length; j++)
            {
                if (playerCards[j] == ranNum)
                {
                    duplicateCard = true;
                }
            }

            if (duplicateCard) { continue; }

            var rankNum = (ranNum % 13) + 1;
            var rank = "";

            switch (rankNum)
            {
                case 1:
                    rank = "Ace";
                    break;
                case 11:
                    rank = "Jack";
                    break;
                case 12:
                    rank = "Queen";
                    break;
                case 13:
                    rank = "King";
                    break;
                default:
                    rank = rankNum.ToString();
                    break;
            }

            var suitNum = ranNum / 13;
            var suit = "";

            switch (suitNum)
            {
                case 0:
                    suit = "Spades";
                    break;
                case 1:
                    suit = "Clubs";
                    break;
                case 2:
                    suit = "Hearts";
                    break;
                case 3:
                    suit = "Diamonds";
                    break;
            }

            playerCards[cardsDealt] = ranNum;
            cardsDealt++;

            var cardDisplay = rank + " of " + suit;
            Console.WriteLine(cardDisplay);

        }
        

    }
}