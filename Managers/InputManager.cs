namespace game
{
    public class InputManager
    {
        public Game game;
        public InputManager(Game game)
        {
            this.game = game;
        }

        public string PromptYesOrNo()
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

        public Action SelectAction(List<Action> actions)
        {
            var rawInput = Console.ReadLine();
            bool found = false;
            Action act = new Action();
            while(!found){
                foreach(Action action in actions)
                {
                    if(action.inputChar == rawInput)
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
    }
}