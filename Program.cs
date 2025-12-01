
using System;
using System.Runtime.InteropServices;

public class Program
{
    public static void Main(string[] args)
    {

        var random = new Random();
        var ranNum = random.Next(52) + 1;

        Console.WriteLine(ranNum);

        

        var rankNum = ranNum%13;
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

        var card = rank + " of " + suit;
        Console.WriteLine(card);

    }
}