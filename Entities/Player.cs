namespace game
{
    public class Player
    {
        public int maxHealth = 100;
        public int hp = 100;
        public int armor  = 1;
        public int inventorySize = 5;
        public int attack = 1;
        public string name = "placeholder";
        public Player(string n)
        {
            name = n;
        }
        public void PrintDetails()
        {
            Console.WriteLine($"{name}:");
            Console.Write("HP: ");
            if(hp < (0.1 * maxHealth) ) Console.ForegroundColor = ConsoleColor.DarkRed;
            else if (hp < (0.33 * maxHealth)) Console.ForegroundColor = ConsoleColor.Red;
            else if (hp < 0.67 * maxHealth) Console.ForegroundColor = ConsoleColor.Yellow;
            else Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(hp);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"/{maxHealth}   |   Armor:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(armor);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"   |   Attack: {attack}");
        }
    }
}
    
