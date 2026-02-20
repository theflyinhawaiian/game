namespace game
{
    public class Room
    {
        public string? description;
        public List<int> neighbors = new List<int>();
        public List<Enemy> enemies = new List<Enemy>();

        public Room(List<int>? n = null, string? desc = null)
        {
            neighbors = n ?? new List<int>();
            description = desc;
        }


        public void print()
        {
            Console.WriteLine(description);
            Console.WriteLine(EnemiesStr());
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

        public string EnemiesStr()
        {
            Dictionary<string, int> typeCount = new Dictionary<string, int>();
            if(enemies.Count() == 0)
            {
                return "This area looks safe";
            }
            else
            {
                foreach(Enemy e in enemies)
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
    }
}