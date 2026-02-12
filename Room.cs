using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace game
{
    public class Room
    {
        public string? description;
        public List<int> neighbors = new List<int>();

        public Room(List<int>? n = null, string? desc = null)
        {
            neighbors = n ?? new List<int>();
            description = desc;
        }


        public void print()
        {
            Console.WriteLine(description);
            if(neighbors.Count() != 0)
            {
                Console.Write($"You can see {neighbors.Count()} path");
                if(neighbors.Count() > 1) Console.Write("s");
            }
        }

        public string NeighborsStr()
        {
            string n = "";
            foreach(int x in neighbors)
            {
                n += x + " ";
            }
            return n;
        }

    }
}