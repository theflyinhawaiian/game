
public class Program
{
    public static void Main(string[] args)
    {
        var princess = new Unit("the princess", 1, 100, 5, 16, .05f, 6, 15, 1.0f);
        var hero = new Unit("the hero", 1, 140, 5, 10, .05f, 4, 20, 1.0f);

        var attackingDamage = princess.Damage * princess.DamageModifier;
        var attackingDamageInt = (int) MathF.Round(attackingDamage);
        hero.CurrentHP -= attackingDamageInt;

        Console.WriteLine(hero.CurrentHP.ToString());



    }
}