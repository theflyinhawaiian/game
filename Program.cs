
using System;
using System.CodeDom;
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

    static void PrintStateOfGame(int[] playerHand, int[] dealerHand, bool finishedWithRound = false)
    {
        Console.Clear();
        Console.WriteLine("Player Hand: \n");
        PrintHand(playerHand);
        Console.WriteLine("-------");
        Console.WriteLine("Dealer Hand: \n");
        if (finishedWithRound == true)
        {
            PrintHand(dealerHand);
        }
        else
        {
            Console.WriteLine("Card Hidden");
            PrintCard(dealerHand[1]);
        }
        
    }

    static void PlayGameOfBlackJack()
    {
        var finishedWithRound = false;

        int startingNumberOfCardsInHand = 2;

        int[] cardsInPlay = new int[numberOfCardsInDeck];

        for (int i = 0; i < cardsInPlay.Length; i++)
        {
            cardsInPlay[i] = -1;
        }

        var playerHand = DealCards(cardsInPlay, startingNumberOfCardsInHand);
        cardsInPlay = cardsInPlay.Concat(playerHand).ToArray();

        var dealerHand = DealCards(cardsInPlay, startingNumberOfCardsInHand);
        cardsInPlay = cardsInPlay.Concat(dealerHand).ToArray();

        PrintStateOfGame(playerHand, dealerHand);

        var playerHandScore = ScoreHand(playerHand);
        var dealerHandScore = ScoreHand(dealerHand);

        if (playerHandScore == 21 && dealerHandScore == 21)
        {
            Console.WriteLine("Wow! It's a tie! You both got Blackjack");
            return;
        }
        if (playerHandScore == 21)
        {
            Console.WriteLine("\n \nBLACKJACK! \n \nYou beat the dealer");
            return;
        }
        if (dealerHandScore == 21)
        {
            Console.WriteLine("\n \nYou have lost... \n \nThe dealer got BlackJack");
            return;
        }



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

        finishedWithRound = true;

        Console.WriteLine("\n \nYou are at " + playerHandScore);

        if (playerHandScore <= 21)
        {
            while (dealerHandScore < 17)
            {
                var dealtCard = DealCards(cardsInPlay, 1);
                cardsInPlay = cardsInPlay.Concat(dealtCard).ToArray();
                dealerHand = dealerHand.Concat(dealtCard).ToArray();

                dealerHandScore = ScoreHand(dealerHand);
            }

            PrintStateOfGame(playerHand, dealerHand, finishedWithRound);

            if (dealerHandScore > 21)
            {
                Console.WriteLine("\n \nDealer Busts! You win!!");
            }
            else if (playerHandScore > dealerHandScore)
            {
                Console.WriteLine("\n \nYou have won! \n \nYou beat the dealer " + playerHandScore + " to " + dealerHandScore);
            }
            else if (playerHandScore <= dealerHandScore)
            {
                Console.WriteLine("\n \nYou have lost... \n \nThe dealer beat you " + playerHandScore + " to " + dealerHandScore);
            }
        }
        else if (playerHandScore > 21)
        {
            Console.WriteLine("BUST!");
        }
    }

    public static void Main(string[] args)
    {
        var finishedPlaying = false;
        while(finishedPlaying == false)
        {
            PlayGameOfBlackJack();

            Console.WriteLine("\n \n \nWould you like to play again?");
            var playAgain = "";

            while(playAgain != "yes" && playAgain != "y" && playAgain != "no" && playAgain != "n")
            {
                playAgain = Console.ReadLine();

                if (playAgain == "yes" || playAgain == "y")
                {
                    finishedPlaying = false;
                }
                else if (playAgain == "no" || playAgain == "n")
                {
                    finishedPlaying = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Not a valid input. Please try again");
                }
            }
        }
    }
}