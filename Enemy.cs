namespace game
{
    public class Enemy
    {
        public int maxHealth;
        public int hp;
        public string name;
        public string type;
        public int attack;
        public int defense;

        public Enemy(int maxHealth = 2, int hp = 2, string name = "Jeff", string type = "blob", int attack = 2, int defense = 2)
        {
            this.maxHealth = maxHealth;
            this.hp = hp;
            this.name = name;
            this.type = type;
            this.attack = attack;
            this.defense = defense;
        }


        public void DealDamage(int incoming)
        {
            this.hp -= incoming - defense;
        }

        public void PrintEnemy()
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"   |   Attack: {attack}");
        }
    }
}