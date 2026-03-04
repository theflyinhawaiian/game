namespace game
{
    public class Map
    {        
        public Room spawn;
        public Dictionary<int, Room> allRooms = new Dictionary<int, Room>();

        private class MapParser
        {

            public Room CreateNewRoom(List<int>? n = null, string? desc = null)
            {
                n ??= new List<int>();
                Room r = new Room(n, desc);
                return r;
            }

            public void CreateConnections(Room room, int id, Dictionary<int, Room> allRooms)
            {
                foreach(int neighborID in room.neighbors)
                {
                    if (allRooms.ContainsKey(neighborID))
                    {
                        if (!allRooms[neighborID].neighbors.Contains(id))
                        {
                            allRooms[neighborID].neighbors.Add(id);
                        }
                    }
                }
            }

            public Dictionary<int, Room> GenerateMapFromTxt(string filepath)
            {
                Dictionary<int, Room> allRooms = new Dictionary<int, Room>();
                int newRoomId = 0;
                try
                {
                    using StreamReader reader = new StreamReader(filepath);
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] details = line.Split(',');
                        string[] ids = details[0].Split(' ');
                        List<int> neighbors = new List<int>();
                        foreach(string id in ids)
                        {
                            if(id == "n") break;
                            neighbors.Add(int.Parse(id));
                        }
                        var newRoom = CreateNewRoom(neighbors, details[1]);
                        allRooms.Add(newRoomId, newRoom);
                        CreateConnections(newRoom, newRoomId, allRooms);
                        newRoomId++;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read: " + e);
                }
                return allRooms;
            }
        }


        public Map(string path)
        {
            var parser = new MapParser();
            allRooms = parser.GenerateMapFromTxt(path);
            spawn = allRooms[0];
        }

        public Room GetRoomByID(int id)
        {
            return allRooms[id];
        }
    }
}