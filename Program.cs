
using System;
using System.Linq;
using System.Runtime.InteropServices;

public class Program
{
    static int numberOfCardsInDeck = 52;
    

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

    static int ScoreCard(int cardID)
    {
        var rankNum = (cardID % 13) + 1;
        var cardScore = 0;

        if (rankNum >= 2 && rankNum <= 10)
        {
            cardScore = rankNum;
        }
        else if (rankNum >= 11 && rankNum <= 13)
        {
            cardScore = 10;
        }
        else
        {
            cardScore = 11;
        }
        return cardScore;
    }

    static int ScoreHand(int[] hand)
    {
        var totalHandScore = 0;
        var aceCounter = 0;

        for (int i = 0; i < hand.Length; i++)
        {
            if (ScoreCard(hand[i]) == 11) { aceCounter++; }

            totalHandScore = totalHandScore + ScoreCard(hand[i]);

            while (totalHandScore > 21 && aceCounter > 0)
            {
                totalHandScore = totalHandScore - 10;
                aceCounter--;
            }
        }
        return totalHandScore;
    }


    static void PrintHand(int[] hand)
    {
        for(int i = 0; i < hand.Length; i++)
        {
            PrintCard(hand[i]);

        }
        
    }

    static int[] DealCards(int[] cardsInPlay, int cardsToDeal)
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

    static void PrintStateOfGame(int[] playerHand, int[] dealerHand)
    {
        Console.Clear();
        Console.WriteLine("Player Hand: \n");
        PrintHand(playerHand);
        Console.WriteLine("-------");
        Console.WriteLine("Dealer Hand: \n");
        Console.WriteLine("Card Hidden");
        PrintCard(dealerHand[1]);
    }

    public static void Main(string[] args)
    {
        int numberOfCardsInHand = 2;

        int[] cardsInPlay = new int[numberOfCardsInDeck];

        for (int i = 0; i < cardsInPlay.Length; i++)
        {
            cardsInPlay[i] = -1;
        }

        var playerHand = DealCards(cardsInPlay, numberOfCardsInHand);
        cardsInPlay = cardsInPlay.Concat(playerHand).ToArray();

        var dealerHand = DealCards(cardsInPlay, numberOfCardsInHand);
        cardsInPlay = cardsInPlay.Concat(dealerHand).ToArray();

        PrintStateOfGame(playerHand, dealerHand);

        var playerHandScore = ScoreHand(playerHand);

        while (playerHandScore < 21)
        {
            Console.WriteLine("\n \nYou are at " + playerHandScore + ". Would you like to hit or stay?");

            var input = Console.ReadLine();

            if (input == "hit")
            {
                var dealtCard = DealCards(cardsInPlay, 1);
                cardsInPlay = cardsInPlay.Concat(dealtCard).ToArray();
                playerHand = playerHand.Concat(dealtCard).ToArray();

                playerHandScore = ScoreHand(playerHand);

                PrintStateOfGame(playerHand, dealerHand);
            }
            else if (input == "stay")
            { 
                Console.WriteLine("\nYou have chosen to stay at " + playerHandScore);
                break;
            }
            else
            {
                PrintStateOfGame(playerHand, dealerHand);

                Console.WriteLine("Not a valid input. Please try again.\n\n");
            }
        }
        Console.WriteLine("\n \n You are at " + playerHandScore);
        if (playerHandScore <= 21)
        {
            
        }
        else if (playerHandScore > 21)
        {
            Console.WriteLine("BUST!");
        }

    }
}