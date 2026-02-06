using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace game
{
    public class Game
    {
        public bool isRunning = false;
        public bool allowClear = true;
        public bool turnEnded = false;
        public Player? player;
        public Room playerLocation;
        public Map? map;
         public enum State
        {
            InRoom,
            Combat,
            Inventory
        }
        State GameState = new State();
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


        public void init()
        {
            if(allowClear) Console.Clear();
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
            playerLocation = map.spawn;
            GameState = State.InRoom;
        }

        public void Start()
        {
            while (isRunning)
            {
                turnEnded = false;
                if(allowClear) Console.Clear();
                List<string> actions = GetActions();
                PrintTurnDetails(actions);
                string a = SelectAction(actions);
                //Console.WriteLine("selected action: " + a);
                DoAction(a);
                if (turnEnded)
                {
                    continue;
                }

                Console.WriteLine("End turn?");
                var ynInput = AskYesOrNo();
                if (ynInput == "y")
                {
                    continue;
                }
            }
        }
        


        public void MovePlayer(Room newRoom)
        {
            //Console.WriteLine("moved player to room " + newRoom.id);
            playerLocation = newRoom;
            turnEnded = true;
        }

        public List<string> GetValidMoveInputs()
        {
            List<string> inputs = new List<string>();
            for (int i = 0; i < playerLocation.neighbors.Count(); i++)
            {
                inputs.Add("[" + (i+1) + "] Room " + playerLocation.neighbors[i].id);
            }
            return inputs;
        }

        public List<string> GetValidActionsInRoom(Room a)
        {
            List<string> actions = new List<string>();
            
            if(a.neighbors.Count != 0)
            {
                actions.Add("[m] Move player");
            }
            return actions;
        }

        public List<string> GetActions()
        {
            List<string> actions = new List<string>();
            switch (GameState)
            {
                case State.InRoom :
                    {
                        var validActionsInRoom = GetValidActionsInRoom(playerLocation);
                        foreach(string act in validActionsInRoom)
                        {
                            actions.Add(act);
                        }
                    }
                    break;
            }
            return actions;
        }

        public void PrintActions(List<string> actions)
        {
            foreach(string a in actions)
            {
                Console.Write($"   {a}   |");
            }
            Console.WriteLine();
        }

        // public string ValidateInput(string input, List<string> actions)
        // {
        //     if (actions.Contains(input))
        //     {
        //         return input;
        //     }
        //     else
        //     {
        //         return null;
        //     }
        // }

        public string SelectAction(List<string> actions)
        {
            var rawInput = Console.ReadLine();
            bool found = false;
            string act = "";
            while(!found){
                foreach(string action in actions)
                {
                    if(action.Substring(1,1) == rawInput)
                    {
                        found = true;
                        act = action;
                        break;
                    }
                } 
                if(found) break;
                Console.WriteLine("Invalid input, try again");
                rawInput = Console.ReadLine();
            }
            return act;
        }

        public void selectRoom()
        {
            
        }

        public void DoAction(string input)
        {
            //Console.WriteLine("do action " + input);
            switch (input.Substring(1,1))
            {
                case "m" :
                    {
                        List<string> validRooms = GetValidMoveInputs();
                        Console.WriteLine("\nMove to where?");
                        Console.WriteLine(new string('-', 100));
                        PrintActions(validRooms);
                        string roomNumber = SelectAction(validRooms)[^1].ToString();
                        MovePlayer(map.GetRoomByID(roomNumber));

                        //MovePlayer();
                        break;
                    }
            }
        }

        public void PrintTurnDetails(List<string> actions)
        {
            player.PrintDetails();
            Console.WriteLine("\n");
            playerLocation.print();
            Console.WriteLine("\n\n\nWhat will you do?");    
            Console.WriteLine(new string('-', 100));
            PrintActions(actions);

        }    
    }
}