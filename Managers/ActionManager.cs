using System.Data;

namespace game
{
    public class ActionManager
    {
        public Game game;
        public ActionManager(Game game)
        {
            this.game = game;
        }

        public List<Action> GetActions(GameManager.State state)
        {
            List<Action> actions = new List<Action>();
            switch (state)
            {
                case GameManager.State.InRoom :
                    {
                        foreach(Action exit in game.playerLocation.exits)
                        {
                            actions.Add(exit);
                        }
                    }
                    break;
            }
            return actions;
        }
    }
}