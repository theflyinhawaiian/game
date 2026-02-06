using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace game
{
    public class Player
    {
        public int maxHealth = 100;
        public int hp = 100;
        public int armor  = 1;
        public int inventorySize = 5;
        public int attack = 1;
        public string name = "placeholder";
        public Player(String n)
        {
            name = n;
        }
        public void PrintDetails()
        {
            Console.WriteLine($"{name}:");
            Console.Write($"HP: {hp}/{maxHealth}   |   Armor: {armor}   |   Attack: {attack}");
        }
    }
}
    
