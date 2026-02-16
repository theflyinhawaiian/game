using System;

public class Program
{
    public static void Main(string[] args)
    {
        var myWeapon = new Weapon("sword", 8, 60);
        Console.WriteLine(myWeapon.ToString());

        var myWeapon2 = new Weapon("gun", 100);
        Console.WriteLine(myWeapon2.ToString());
    }
}