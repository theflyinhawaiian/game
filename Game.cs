using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace game
{
    public class Game
    {
        public bool isRunning = false;
        public Player? player;
        public Game()
        {
            
        }
        public string SelectName()
        {
            var input = "";
            while (string.IsNullOrWhiteSpace(input)) {
                Console.WriteLine("What is your name, traveller?");
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    break;
                }
                else if (input == "nameless")
                {
                    Console.WriteLine("bruh really");
                }
                else
                {
                    Console.WriteLine("You cannot be nameless");
                }
            }
            return input;
        }


        public void start()
        {
            isRunning = true;
            player = new Player(SelectName());
            Console.WriteLine($"Your name is {player.Name}?");
            Console.WriteLine("This is where a lot of BS introduction would go");
            //TODO: tutorial? controls explained? idk
            Console.WriteLine("does this make sense yadda yadda y/n");
            var input = Console.ReadLine();
            if(input == "y")
            {
                Console.WriteLine("yippeee game!!! woooooo start!!!!");
            }
            else
            {
                Console.WriteLine(":( okay but we're starting anyway");
            }

        }
    }
}