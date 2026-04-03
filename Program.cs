using System;

public class Program
{
    public static void Main(string[] args)
    {
        var myWeapon = new Weapon("sword", 8, 60);
        Console.WriteLine(myWeapon.ToString());

        var player = new Player(20, 1, 2);
        var enemy = new Enemy(20, 6, 1, "Probe");

        string nEnemyApproaches = "A " + enemy.EnemyName + " approaches from the shadows. What would you like to do?";
        string nActionReadout = "\n    Fight (f)     Items (i)     Talk (t)";

        player.Inventory.EquipWeapon(myWeapon);
        player.Inventory.GainArmorPotion();
        player.Inventory.GainHealthPotion();

        Console.WriteLine(nEnemyApproaches + nActionReadout);
        var input = Console.ReadLine();

        while (enemy.CurrentHealth > 0)
        {
            if (input == "f" || input == "fight" || input == "attack" || input == "a")
            {
                var playerDamage = player.CurrentAttackStat - enemy.DefenseStat;
                enemy.TakeDamage(playerDamage);


                if (enemy.CurrentHealth > 0)
                {
                    var enemyDamage = enemy.AttackStat - player.DefenseStat;
                    player.TakeDamage(enemyDamage);

                    if (player.CurrentHealth > 0)
                    {
                        Console.WriteLine("You are left at " + player.CurrentHealth + " health. The enemy has " + enemy.CurrentHealth + " health. What would you like to do?");
                    }
                    else
                    {
                        Console.WriteLine("Oh no!!!!  you have lost :(");
                        break;
                    }
                }

            
            }

            if (input == "i" || input == "item" || input == "inventory")
            {
                Console.WriteLine(player.Inventory.Describe());
                Console.WriteLine("\n Which item would you like to use?");

                Console.WriteLine(player.Inventory.Options());
            }
            
            input = Console.ReadLine();
        }


    }


}