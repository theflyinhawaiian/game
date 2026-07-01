
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
        var targetedUnit = hero;

        var damageCore = new Item("DamageCore", new List<ItemEffect> { new ItemEffect(1.1f, OperatorHandler.Multiply, Stat.DamageModifier), new ItemEffect(3f, OperatorHandler.Add, Stat.Speed) });
        var sacsPizza = new Item("SacsPizza", new List<ItemEffect> { new ItemEffect(3f, OperatorHandler.Add, Stat.Speed) });
        var sniperScope = new Item("SniperScope", new List<ItemEffect> { new ItemEffect(.1f, OperatorHandler.Add, Stat.CritChance)});
        var coolItem = new Item("CoolItem", new List<ItemEffect> { new ItemEffect(3f, OperatorHandler.Add, Stat.Movement), new ItemEffect(1f, OperatorHandler.Add, Stat.Speed) });
        var gen1Mech = new Item("Gen1Mech", new List<ItemEffect> { new ItemEffect((Convert.ToSingle(currentUnit.EffectiveSpeed) / 100), OperatorHandler.Add, Stat.CritChance) });

        var list = new List<Item> {};

        list.Add(damageCore);
        list.Add(sacsPizza);
        list.Add(sniperScope);
        list.Add(coolItem);
        list.Add(gen1Mech);

        currentUnit.Inventory = new Inventory(list, currentUnit);

        Console.WriteLine(currentUnit.EffectiveDamage.ToString());
        Console.WriteLine(currentUnit.EffectiveDamageModifier.ToString());


        currentUnit.Inventory.InventoryDisplay();
        currentUnit.Inventory.InventoryModify();

        Console.WriteLine(currentUnit.EffectiveDamage.ToString());
        Console.WriteLine(currentUnit.EffectiveDamageModifier.ToString());
        Console.WriteLine(currentUnit.EffectiveCritChance.ToString());

        attackingDamage = currentUnit.EffectiveDamage * currentUnit.EffectiveDamageModifier;
        attackingDamageInt = (int)MathF.Round(attackingDamage);
        targetedUnit.CurrentHP -= attackingDamageInt;

        hero.CurrentHP = targetedUnit.CurrentHP;


        Console.WriteLine(hero.CurrentHP.ToString());



    }
}