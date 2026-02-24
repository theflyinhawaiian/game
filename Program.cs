using System;

public class Program
{
    public static void Main(string[] args)
    {
        var myWeapon = new Weapon("sword", 8, 60);
        Console.WriteLine(myWeapon.ToString());

        var myWeapon2 = new Weapon("gun", 100);
        Console.WriteLine(myWeapon2.ToString());

        

        var player = new Player(20, 2, 2);
        player.CurrentHealth = 5;
        Console.WriteLine(player.CurrentHealth);
        player.Inventory.GainHealthPotion();
        player.Inventory.HealthPotionAmount();
        player.Inventory.Consumables[0].UseHealthPotion(); 
        Console.WriteLine(player.CurrentHealth);
        Console.WriteLine(player.Inventory.HealthPotionAmount());


    }
}