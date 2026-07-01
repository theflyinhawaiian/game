
using System.Net.Http.Headers;

public class Program
{
    public static void Main(string[] args)
    {
        var princess = new Unit("the princess", 1, 100, 5, 16, .05f, 6, 15, 1.0f, 1.0f);
        var hero = new Unit("the hero", 1, 140, 5, 10, .05f, 4, 20, 1.0f, 1.0f);

        var attackingDamage = princess.EffectiveDamage * princess.EffectiveDamageModifier;
        var attackingDamageInt = (int) MathF.Round(attackingDamage);
        hero.CurrentHP -= attackingDamageInt;

        Console.WriteLine(hero.EffectiveSpeed.ToString());

        var currentUnit = princess;

        var damageCore = new Item("DamageCore", new List<ItemEffect> { new ItemEffect(1.1f, OperatorHandler.Multiply, Stat.DamageModifier), new ItemEffect(3f, OperatorHandler.Add, Stat.Speed) });
        var sacsPizza = new Item("SacsPizza", new List<ItemEffect> { new ItemEffect(3f, OperatorHandler.Add, Stat.Speed) });
        var sniperScope = new Item("SniperScope", new List<ItemEffect> { new ItemEffect(.1f, OperatorHandler.Add, Stat.CritChance)});
        var coolItem = new Item("CoolItem", new List<ItemEffect> { new ItemEffect(3f, OperatorHandler.Add, Stat.Movement), new ItemEffect(1f, OperatorHandler.Add, Stat.Speed) });
        var gen1Mech = new Item("Gen1Mech", new List<ItemEffect> { new ItemEffect((currentUnit.EffectiveSpeed / 100), OperatorHandler.Add, Stat.CritChance) });

        var list = new List<Item> {};

        list.Add(damageCore);
        list.Add(sacsPizza);
        list.Add(sniperScope);
        list.Add(coolItem);
        list.Add(gen1Mech);

        princess.Inventory = new Inventory(list, princess);

        Console.WriteLine(princess.EffectiveDamage.ToString());
        Console.WriteLine(princess.EffectiveDamageModifier.ToString());


        princess.Inventory.InventoryDisplay();
        princess.Inventory.InventoryModify();

        Console.WriteLine(princess.EffectiveDamage.ToString());
        Console.WriteLine(princess.EffectiveDamageModifier.ToString());
        Console.WriteLine(princess.EffectiveCritChance.ToString());

        attackingDamage = princess.EffectiveDamage * princess.EffectiveDamageModifier;
        attackingDamageInt = (int)MathF.Round(attackingDamage);
        hero.CurrentHP -= attackingDamageInt;



        Console.WriteLine(hero.CurrentHP.ToString());



    }
}