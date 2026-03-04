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
    }
}