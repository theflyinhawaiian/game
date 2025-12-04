
using System;
using System.Runtime.InteropServices;

public class Program
{
    static void PrintCard(int cardID)
    {
        var rankNum = (cardID % 13) + 1;
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

        var suitNum = cardID / 13;
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

        var cardDisplay = rank + " of " + suit;
        Console.WriteLine(cardDisplay);
    }

    static void PrintHand(int[] hand, int cardsDealt)
    {
        for(int i = 0; i < cardsDealt; i++)
        {
            PrintCard(hand[i]);

        }
        
    }

    static int[] DealHand(int cardsToDeal)
    {
        int[] hand = new int[52];
        var cardsDealt = 0;


        while (cardsDealt < cardsToDeal)
        {
            var random = new Random();
            var cardID = random.Next(52);

            var duplicateCard = false;

            for (int j = 0; j < hand.Length; j++)
            {
                if (hand[j] == cardID)
                {
                    duplicateCard = true;
                }
            }

            if (duplicateCard) { continue; }

            hand[cardsDealt] = cardID;
            cardsDealt++;

            

        }

        return hand;
    }

    public static void Main(string[] args)
    {
        var playerHand = DealHand(30);
        PrintHand(playerHand, 30);

    }
}