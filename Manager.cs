using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace game
{
    public class Manager
    {
        public Game game;
        public enum State
        {
            Started,
            InRoom,
            Combat,
            Inventory
        }
        State GameState = new State();

        public Manager()
        {
            
        }

        public void StartGame()
        {
            game = new Game();
            game.start();
            GameState = State.Started;
        }

        public void Run()
        {
            
            while (game.isRunning)
            {
                Console.Clear();
                game.PrintTurnDetails();
                var input = Console.ReadLine();
                // bool turnCompleted = false;
                // while (!turnCompleted)
                // {
                    
                // }
            }
        }
    }
}