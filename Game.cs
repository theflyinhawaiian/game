namespace game
{
    public class Game
    {
        private static bool isRunning = false;
        private static bool turnEnded = false;
        public Player player;
        public Room playerLocation;
        public Map? map;
        public DisplayManager displayManager;
        public InputManager inputManager;
        public enum State
        {
            InRoom,
            Combat,
            Inventory
        }
        State GameState = new State();

        //debug bools
        private static bool allowClear = true;
        private static bool allowPrintMap = true;

        public Game()
        {
            displayManager = new DisplayManager(this);
            inputManager = new InputManager(this);
        }

        public void init()
        {
            if(allowClear) Console.Clear();
            isRunning = true;
            player = new Player(inputManager.SelectName());
            Console.WriteLine($"\nYour name is {player.name}?");
            Console.WriteLine("This is where a lot of BS introduction would go");
            //TODO: tutorial? controls explained? idk
            Console.WriteLine("does this make sense yadda yadda");
            var input = inputManager.PromptYesOrNo();
            if(input == "y")
            {
                Console.WriteLine("yippeee game!!! woooooo start!!!!");
            }
            else
            {
                Console.WriteLine(":( okay but we're starting anyway");
            }
            map = new Map("map1.txt");
            playerLocation = map.spawn;
            GameState = State.InRoom;
        }

        public void Run()
        {
            while (isRunning)
            {
                turnEnded = false;
                if(allowClear) Console.Clear();
                List<string> actions = GetActions();
                displayManager.PrintTurnDetails(actions);
                string a = inputManager.SelectAction(actions);
                //Console.WriteLine("selected action: " + a);
                DoAction(a);
                if (turnEnded)
                {
                    continue;
                }

                Console.WriteLine("End turn?");
                var ynInput = inputManager.PromptYesOrNo();
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
                inputs.Add("[" + (i+1) + "] Room " + playerLocation.neighbors[i]);
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
            if(allowPrintMap) actions.Add("[p] print map");
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

        public void DoAction(string input)
        {
            //Console.WriteLine("do action " + input);
            switch (input.Substring(1,1))
            {
                case "b" :
                    //This is where the eventual back button should go
                    break;
                case "m" :
                    {
                        List<string> validRooms = GetValidMoveInputs();
                        Console.WriteLine("\nMove to where?");
                        Console.WriteLine(new string('-', 100));
                        displayManager.PrintActions(validRooms);
                        var neighborIndex = int.Parse(inputManager.SelectAction(validRooms).Substring(1,1)) - 1;
                        MovePlayer(map.GetRoomByID(playerLocation.neighbors[neighborIndex]));
                        break;
                    }
                case "p":
                    {
                        displayManager.PrintMap(map);
                        break;
                    }
            }
        }
  
    }
}