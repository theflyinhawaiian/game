namespace game
{
    public class Room
    {
        public string? description;
        public List<Enemy> enemies = new List<Enemy>();
        public List<Action> exits = new List<Action>();

       public Room(string? desc = null,  List<Action>? exits = null, List<Enemy>? enemies = null)
        {
            description = desc;
            this.exits = exits ?? new List<Action>();
            this.enemies = enemies ?? new List<Enemy>();
        }
    }
}