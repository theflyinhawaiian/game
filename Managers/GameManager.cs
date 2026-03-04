namespace game
{
    public class GameManager
    {
        private static bool isRunning = false;
        private static bool turnEnded = false;
        public Game game;
        public DisplayManager displayManager;
        public InputManager inputManager;
        public ActionManager actionManager;
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


        public GameManager(Game game)
        {
            this.game = game;
            displayManager = new DisplayManager(game);
            inputManager = new InputManager(game);
            actionManager = new ActionManager(game);

        }
        public void init()
        {
            if(allowClear) Console.Clear();
            isRunning = true;
            game.player = new Player(inputManager.SelectName());
            Console.WriteLine($"\nYour name is {game.player.name}?");
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
            game.map = new Map("map2.json");
            game.playerLocation = game.map.spawn;
            GameState = State.InRoom;
        }

        public void Run()
        {
            while (isRunning)
            {
                turnEnded = false;
                if(allowClear) Console.Clear();
                List<Action> actions = actionManager.GetActions(GameState);
                if(allowPrintMap) actions.Add(new Action(Action.ActionType.printMap, "Print map", "p"));
                displayManager.PrintTurnDetails(actions);
                Action a = inputManager.SelectAction(actions);
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
            game.playerLocation = newRoom;
            turnEnded = true;
        }

        public void DoAction(Action a)
        {
            //Console.WriteLine("do action " + input);
            switch (a.act)
            {
                case Action.ActionType.move :
                    MovePlayer(a.destinationRoom);
                    break;
                case Action.ActionType.printMap :
                    displayManager.PrintMap(game.map);
                    break;
            }
        }
    }
}