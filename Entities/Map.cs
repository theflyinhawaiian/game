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

            public class JsonRoom
            {
                public string? Description { get; set; }
                public List<JsonExit> Exits { get; set; } = new();
                public List<JsonEnemy> Enemies { get; set; } = new();
            }

            public class JsonExit
            {
                public int DestinationID { get; set; }
                public string? Description { get; set; }
            }

            public class JsonEnemy
            {
                public int MaxHealth { get; set; } = 2;
                public int Hp { get; set; } = 2;
                public string Name { get; set; } = "Jeff";
                public string Type { get; set; } = "blob";
                public int Attack { get; set; } = 2;
                public int Defense { get; set; } = 2;
            }

            public Dictionary<int, Room> GenerateMapFromJSON(string path)
            {
                Dictionary<int, Room> allRooms = new Dictionary<int, Room>();
                try
                {
                    string jsonString = File.ReadAllText(path);
                    Console.WriteLine(jsonString);

                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var jsonRooms = JsonSerializer.Deserialize<List<JsonRoom>>(jsonString, options);

                    //embracing claude (initializes rooms)
                    List<Room> rooms = jsonRooms.Select(jr => new Room(
                        desc: jr.Description
                    )).ToList();


                    for (int i = 0; i < rooms.Count; i++)
                    {
                        //assign room exits
                        int j = 1;
                        foreach (var exit in jsonRooms[i].Exits)
                        {
                            Room destination = rooms[exit.DestinationID];
                            rooms[i].exits.Add(new Action(
                                destinationRoom: destination,
                                act: Action.ActionType.move,
                                description: exit.Description,
                                inputChar: $"{j}"
                            ));
                            j++;
                        }

                        //assign room enemies
                        foreach (var enemy in jsonRooms[i].Enemies)
                        {
                            rooms[i].enemies.Add(new Enemy(
                                maxHealth: enemy.MaxHealth,
                                hp: enemy.Hp,
                                name: enemy.Name,
                                type: enemy.Type,
                                attack: enemy.Attack,
                                defense: enemy.Defense
                            ));
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