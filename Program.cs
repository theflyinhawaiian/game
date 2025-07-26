using System;
public class Program
{
    public static void Main(string[] args)
    {
        bool playAgain = true;
        int[] playerGuesses = new int[]
        {
            10,10,10,10,10,10,10,10
        };

        while (playAgain == true)
        {
            Console.WriteLine("Guess a number between 1-20:");
            var input = Console.ReadLine();
            int intTemp = Convert.ToInt32(input);


            var random = new Random();
            var ranNum = random.Next(20);
            ranNum = ranNum + 1;

            int guessCounter = 1;

            while (intTemp != ranNum)
            {
                if (intTemp >= ranNum)
                {
                    Console.WriteLine("the number im thinking of is lower");
                }
                if (intTemp <= ranNum)
                {
                    Console.WriteLine("the number im thinking of is higher");
                }
                guessCounter++;
                Console.WriteLine("guess again");

                input = Console.ReadLine();
                intTemp = Convert.ToInt32(input);

            }

            playerGuesses[6] = guessCounter;

            int topFiveGuesses = 5;

            Array.Sort(playerGuesses, (a, b) => a.CompareTo(b));
            for (int i = 0; i < topFiveGuesses; i++)
            {
                Console.WriteLine(playerGuesses[i]);
            }
            

            Console.WriteLine($"nice job :) it took you {guessCounter} guesses. Would you like to play again? y/n ");
            var playResponse = Console.ReadLine();

            if (playResponse == "y")
            {
                Console.WriteLine("okay <3 yay :)");
            }
            if (playResponse == "n")
            {
                Console.WriteLine("what the fuck");
                playAgain = false;
            }
        }
        


       
    }
}