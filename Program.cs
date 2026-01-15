
using System;
using System.Linq;
using System.Runtime.InteropServices;

public class Program
{
    static int numberOfCardsInDeck = 13;
    

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

    static int[] DealHand(int[] cardsInPlay, int cardsToDeal)
    {

        int[] hand = new int[cardsToDeal];

        for (int i = 0; i < cardsToDeal; i++)
        {
            hand[i] = -1;
        }



        var cardsInHand = 0;

        int[] totalCards = cardsInPlay.Concat(hand).ToArray();

        

        while (cardsInHand < cardsToDeal)
        {
            var random = new Random();
            var cardID = random.Next(numberOfCardsInDeck);
            var duplicateCard = false;


            for (int i = 0; i < totalCards.Length; i++)
            {
                if (totalCards[i] == cardID)
                {
                    duplicateCard = true;
                }
            }

            if (duplicateCard) { continue; }

            hand[cardsInHand] = cardID;
            totalCards[cardsInPlay.Length + cardsInHand] = cardID;
            cardsInHand++;

        }

        return hand;
    }

    public static void Main(string[] args)
    {
        int numberOfCardsInHand = 2;

        int[] cardsInPlay = new int[numberOfCardsInDeck];

        for (int i = 0; i < cardsInPlay.Length; i++)
        {
            cardsInPlay[i] = -1;
        }



        var playerHand = DealHand(cardsInPlay, numberOfCardsInHand);
        cardsInPlay = cardsInPlay.Concat(playerHand).ToArray();
        PrintHand(playerHand, numberOfCardsInHand);
        Console.WriteLine("-------");

        var dealerHand = DealHand(cardsInPlay, numberOfCardsInHand);
        cardsInPlay = cardsInPlay.Concat(dealerHand).ToArray();
        Console.WriteLine("Card Hidden");
        Console.WriteLine("The hidden card is: " + dealerHand[0]);
        PrintCard(dealerHand[1]);
        

    }
}