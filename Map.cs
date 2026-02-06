using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace game
{
    public class Map
    {        
        public Room home;
        private List<Room> allRooms = new List<Room>();

        public void AddPath(Room a, Room b)
        {
            if(!a.neighbors.Contains(b.id))
            {
                a.neighbors.Add(b.id);
            }
            if (!b.neighbors.Contains(a.id))
            {
            b.neighbors.Add(a.id);
            }
        }

        public void RemovePath(Room a, Room b)
        {
            a.neighbors.Remove(b.id);
            b.neighbors.Remove(a.id);
        }

        public Map()
        {
            
        }

        public Room CreateNewRoom(List<int>? n = null, string? desc = null)
        {
            n ??= new List<int>();
            Room r = new Room(n, desc);
            allRooms.Add(r);
            foreach(Room x in allRooms)
            {
                if (r.neighbors.Contains(x.id))
                {
                    AddPath(x, r);
                }
            }
            return r;
        }

        public void GenerateMap()
        {
            home = CreateNewRoom(desc:"This is where you start");
            Room r1 = CreateNewRoom(new List<int>(){0,2}, "hallwayy??????");
            Room r2 = CreateNewRoom(new List<int>(){1}, "this is definitely a room");
        }

        public void PrintMap()
        {
            Console.WriteLine($"Current Map ({allRooms.Count()} rooms):\n");
            foreach(Room r in allRooms)
            {
                Console.WriteLine($"Room id {r.id}'s description: {r.description}");
                Console.WriteLine($"Neighbors: {r.NeighborsStr()}\n");
            }
        }

        public string GetRoomDescription()
        {
            string desc = "";


            return desc;
        }
    }
}