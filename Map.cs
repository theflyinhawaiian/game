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
        public Room spawn;
        private List<Room> allRooms = new List<Room>();

        public void AddPath(Room a, Room b)
        {
            if(!a.neighbors.Contains(b))
            {
                a.neighbors.Add(b);
            }
            if (!b.neighbors.Contains(a))
            {
                b.neighbors.Add(a);
            }
        }

        public void RemovePath(Room a, Room b)
        {
            if(!a.neighbors.Contains(b))
            {
                a.neighbors.Remove(b);
            }
            if (!b.neighbors.Contains(a))
            {
                b.neighbors.Remove(a);
            }
        }

        public Map()
        {
            spawn = CreateNewRoom(desc:"This is where you start");
            GenerateMap();
        }

        public Room CreateNewRoom(List<Room>? n = null, string? desc = null)
        {
            n ??= new List<Room>();
            Room r = new Room(n, desc);
            allRooms.Add(r);
            foreach(Room x in allRooms)
            {
                if (r.neighbors.Contains(x))
                {
                    AddPath(x, r);
                }
            }
            return r;
        }

        private void GenerateMap()
        {
            Room r1 = CreateNewRoom(new List<Room>(){spawn}, "hallwayy??????");
            Room r2 = CreateNewRoom(new List<Room>(){r1}, "this is definitely a room");
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

        public Room GetRoomByID(string input)
        {
            int id = int.Parse(input);
            foreach(Room r in allRooms)
            {
                if(r.id == id);
                return r;
            }
            return spawn; //room not found
        }
    }
}