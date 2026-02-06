using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace game
{
    public class Player
    {
        public int Max_health {
            get;
            set;
        } = 100;
        public int Armor {
            get;
            set;
        } = 1;
        public int Inventory_size {
            get;
            set;
        }= 5;
        public int Damage {
            get;
            set;
        } = 1;
        public string Name {
            get;
        }

        public int location = 0;

        public Player(String n)
        {
            Name = n;
        }

    }
}
    
