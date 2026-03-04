namespace game
{
    public class DisplayManager
    {
        public Game game;
        public DisplayManager(Game game)
        {
            this.game = game;
        }

        public void PrintTurnDetails(List<Action> actions)
        {
            game.player.PrintDetails();
            Console.WriteLine("\n");
            PrintRoom(game.playerLocation);
            Console.WriteLine("\n\n\nWhat will you do?");    
            Console.WriteLine(new string('-', 100));
            PrintActions(actions);
        }  

        public void PrintRoom(Room room)
        {
            Console.WriteLine(room.description);
            Console.WriteLine(EnemiesStr(room));
            
        }

        public string EnemiesStr(Room room)
        {
            Dictionary<string, int> typeCount = new Dictionary<string, int>();
            if(room.enemies.Count() == 0)
            {
                return "This area looks safe";
            }
            else
            {
                foreach(Enemy e in room.enemies)
                {
                    if (!typeCount.ContainsKey(e.type))
                    {
                        typeCount.Add(e.type, 1);
                    } else
                    {
                        typeCount[e.type]++;
                    }
                }
            }

            var typesSorted = from entry in typeCount orderby entry.Value descending select entry;
            List<string> counts = new List<string>();
            foreach(var tc in typesSorted)
            {
                if(tc.Value == 1)
                {
                    counts.Add($"a {tc.Key}");
                }
                else
                {
                    counts.Add($"{tc.Value} {tc.Key}s");
                }
            }

            string outputStr = "There ";
            if(typesSorted.ElementAt(0).Value == 1)
            {
                outputStr += "is ";
            }
            else
            {
                outputStr += "are ";
            }

            switch (counts.Count())
            {
                case 1:
                    {
                        outputStr += counts[0] + " in here.";
                        break;
                    }
                case 2:
                    {
                        outputStr += counts[0] + " and " + counts[1] + " in here.";
                        break;    
                    }
                default:
                    {
                        for(int i = 0; i < counts.Count(); i++)
                        {
                            if(i == counts.Count() - 1)
                            {
                                
                                outputStr += "and " + counts[i] + " in here.";
                                break;
                            }
                            outputStr += counts[i] + ", ";
                        }
                        break;
                    }
            }
            return outputStr;
        }
        public string RoomNeighborsStr(Room room)
        {
            string n = "";
            foreach(Action x in room.exits)
            {
                n += x.description + " ";
            }
            return n;
        }

        public void PrintActions(List<Action> actions)
        {
            foreach(Action a in actions)
            {
                Console.WriteLine($"[{a.inputChar}] {a.description}");
            }
        }

        public void PrintMap(Map map)
        {
            Console.WriteLine($"Current Map ({map.allRooms.Count()} rooms):\n");
            foreach(var entry in map.allRooms)
            {
                var r = entry.Value;
                Console.WriteLine($"Room id {entry.Key}'s description: {r.description}");
                Console.WriteLine($"Neighbors: {RoomNeighborsStr(r)}\n");
            }
        }
    }
}