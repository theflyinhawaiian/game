
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Security.Cryptography;

public class Program
{
    public static void Main(string[] args)
    {

        var flareShot = new Ability("Flare Shot", new List<AbilityMode> { new AbilityMode("ImpactShot", 50, 3, AbilityType.Rigid), new AbilityMode("Flare Spread", 20, 5, AbilityType.Rigid) });

        //This is functionally equivalent to list.Add(flareshot)
        var princessAbilities = new List<Ability> {flareShot};
        var heroAbilities = new List<Ability>();
        

        var princess = new Unit("the princess", 1, 100, 5, 16, .05f, 6, 15, 1.0f, 1.0f, princessAbilities);
        var hero = new Unit("the hero", 1, 140, 5, 10, .05f, 4, 20, 1.0f, 1.0f, heroAbilities);

        var currentUnit = princess;
        var targetedUnit = hero;

        var attackingDamage = currentUnit.Ability[0].Mode[0].Damage * currentUnit.EffectiveDamageModifier;
        var attackingDamageInt = (int) MathF.Round(attackingDamage);
        targetedUnit.CurrentHP -= attackingDamageInt;

        Console.WriteLine(hero.CurrentHP.ToString());

        

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

        attackingDamage = currentUnit.Ability[0].Mode[0].Damage * currentUnit.EffectiveDamageModifier;
        attackingDamageInt = (int)MathF.Round(attackingDamage);
        targetedUnit.CurrentHP -= attackingDamageInt;

        hero = targetedUnit;
        princess = currentUnit;


        Console.WriteLine(hero.CurrentHP.ToString());



    }
}