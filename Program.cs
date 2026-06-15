
public class Program
{
    public static void Main(string[] args)
    {
        var princess = new Unit("the princess", 1, 100, 5, 16, .05f, 6, 15, 1.0f, 1.0f);
        var hero = new Unit("the hero", 1, 140, 5, 10, .05f, 4, 20, 1.0f, 1.0f);

        var attackingDamage = princess.BaseDamage * princess.DamageModifier;
        var attackingDamageInt = (int) MathF.Round(attackingDamage);
        hero.CurrentHP -= attackingDamageInt;

        Console.WriteLine(hero.CurrentHP.ToString());

        var damageCore = new Item("DamageCore", new List<ItemEffect> { new ItemEffect(1.1f, OperatorHandler.Multiply, Stat.DamageModifier), new ItemEffect(3f, OperatorHandler.Add, Stat.Speed) });
        var sacsPizza = new Item("SacsPizza", new List<ItemEffect> { new ItemEffect(3f, OperatorHandler.Add, Stat.Speed) });
        var sniperScope = new Item("SniperScope", new List<ItemEffect> { new ItemEffect(.1f, OperatorHandler.Add, Stat.CritChance)});

        var list = new List<Item> {};

        list.Add(damageCore);
        list.Add(sacsPizza);
        list.Add(sniperScope);

        princess.Inventory = new Inventory(list);

        princess.Inventory.InventorySort();

        attackingDamage = princess.BaseDamage * princess.DamageModifier;
        attackingDamageInt = (int)MathF.Round(attackingDamage);
        hero.CurrentHP -= attackingDamageInt;

        Console.WriteLine(hero.CurrentHP.ToString());



    }
}