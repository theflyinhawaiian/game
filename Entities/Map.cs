using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace game
{
    public class Map
    {        
        public Room spawn;
        public Dictionary<int, Room> allRooms = new Dictionary<int, Room>();

        private class MapParser
        {

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
                        var newRoom = new Room(details[1], neighbors);
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


            public class JsonRoom
            {
                public string? Description { get; set; }
                public List<JsonExit> Exits { get; set; } = new();
            }

            public class JsonExit
            {
                public int DestinationID { get; set; }
                public string? Description { get; set; }
            }

            public Dictionary<int, Room> GenerateMapFromJSON(string path)
            {
                Dictionary<int, Room> allRooms = new Dictionary<int, Room>();
                try
                {
                    Console.WriteLine("Reading file");
                    string jsonString = File.ReadAllText(path);
                    Console.WriteLine("File read successfully. Content:");
                    Console.WriteLine(jsonString);

                    Console.WriteLine("deserializing");
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var jsonRooms = JsonSerializer.Deserialize<List<JsonRoom>>(jsonString, options);
                    Console.WriteLine($"Deserialized {jsonRooms.Count} rooms");

                    //embracing claude
                    List<Room> rooms = jsonRooms.Select(jr => new Room(
                        desc: jr.Description
                    )).ToList();

                    for (int i = 0; i < rooms.Count; i++)
                    {
                        int j = 1;
                        foreach (var exit in jsonRooms[i].Exits)
                        {
                            Room destination = rooms[exit.DestinationID];
                            rooms[i].exits.Add(new Action(
                                destinationRoom: destination,
                                act: Action.ActionType.move,
                                description: exit.Description,
                                inputChar: $"{j}" // or however you want to assign this
                            ));
                            j++;
                        }
                        allRooms.Add(i, rooms[i]);
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
            allRooms = parser.GenerateMapFromJSON(path);
            spawn = allRooms[0];
        }

        public Room GetRoomByID(int id)
        {
            return allRooms[id];
        }
    }
}