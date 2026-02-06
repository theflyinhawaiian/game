using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace game
{
    public class Room
    {
        private static int nextRoomId = 0;
        public string? description;
        public int id;
        public List<int> neighbors = new List<int>();

        public Room(List<int>? n = null, string? desc = null)
        {
            id = nextRoomId;
            neighbors = n;
            description = desc;
            nextRoomId++;
        }
        public Room()
        {
            id = nextRoomId;
            nextRoomId++;
        }


        public void print()
        {
            Console.WriteLine($"You are in room {id}");
            Console.WriteLine(description);
            if(neighbors.Count() != 0)
            {
                Console.WriteLine($"You can see {neighbors.Count()} path");
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