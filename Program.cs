using System;

public class Program
{
    public static void Main(string[] args)
    {
        var myWeapon = new Weapon("sword", 8, 60);
        Console.WriteLine(myWeapon.ToString());

        var myWeapon2 = new Weapon("gun", 100);
        Console.WriteLine(myWeapon2.ToString());

        

        var player = new Player(20, 3, 2);
        var enemy = new Enemy(5, 3, 1, "Probe");

        Console.WriteLine("You see a " + enemy.EnemyName + " heading towards you. What would you like to do?");
        var input = Console.ReadLine();
        
        while (input == "a")
        {
            var playerDamage = player.AttackStat - enemy.DefenseStat;
            enemy.TakeDamage(playerDamage);
            var enemyDamage = enemy.AttackStat - player.DefenseStat;
            player.TakeDamage(enemyDamage);
            if (enemy.CurrentHealth > 0 && player.CurrentHealth > 0)
            {
                Console.WriteLine("You are left at " + player.CurrentHealth + " health. The enemy has " + enemy.CurrentHealth + " health. What would you like to do?");
            }
            input = Console.ReadLine();
        }


    }


}