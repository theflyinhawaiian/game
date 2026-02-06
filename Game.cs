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
        public Map? map;
        public Room? spawn;
        public Game()
        {
            
        }
        public string SelectName()
        {
            var input = "";
            while (string.IsNullOrWhiteSpace(input)) {
                Console.WriteLine("What is your name, traveller?");
                input = Console.ReadLine();
                if (input == "nameless") 
                {
                    Console.WriteLine("bruh really \n");
                    input = ""; // clear input
                }
                else if (!string.IsNullOrWhiteSpace(input))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You cannot be nameless");
                }
            }
            return input;
        }

        public string AskYesOrNo()
        {
            string s = "";
            while (string.IsNullOrWhiteSpace(s))
            {
                Console.Write("y/n \n");
                var input = Console.ReadLine();
                if (input == "y" || input == "n")
                {
                    s = input;
                    break;
                }
                else
                {
                    Console.Write("Invalid input: ");
                }
            }
            return s;
        }


        public void start()
        {
            Console.Clear();
            isRunning = true;
            player = new Player(SelectName());
            Console.WriteLine($"\nYour name is {player.name}?");
            Console.WriteLine("This is where a lot of BS introduction would go");
            //TODO: tutorial? controls explained? idk
            Console.WriteLine("does this make sense yadda yadda");
            var input = AskYesOrNo();
            if(input == "y")
            {
                Console.WriteLine("yippeee game!!! woooooo start!!!!");
            }
            else
            {
                Console.WriteLine(":( okay but we're starting anyway");
            }
            map = new Map();
            map.GenerateMap();
            spawn = map.spawn;
            player.location = spawn;
        }

        public void MovePlayer(Room newRoom)
        {
            Room oldLocation = player.location;
            Console.Clear();
            newRoom.print();
            player.location = newRoom;
        }

        public void PrintTurnDetails()
        {
            player.PrintDetails();
            Console.WriteLine("\n");
            player.location.print();
            Console.WriteLine("\nWhat will you do?");    
        }

    
    }
}