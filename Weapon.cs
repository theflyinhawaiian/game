using System;

public class Weapon
{
    private string WeaponName { get; set; }
    private int Damage { get; set; }
    private int HitPercentage { get; set; } = 100;

    public Weapon(string weaponName, int damage, int hitPercentage)
    {
        WeaponName = weaponName;
        Damage = damage;
        HitPercentage = hitPercentage;
    }
    public Weapon(string weaponName, int damage)
    {
        WeaponName = weaponName;
        Damage = damage;
    }

    public override string ToString()
    {
        return "This is a " + WeaponName + ". It does " + Damage + " damage, and has a " + HitPercentage + " chance of hitting";
    }
}
