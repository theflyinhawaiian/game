
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Security.Cryptography;

public class Program
{
    public static void Main(string[] args)
    {

        var flareShot = new Ability("Flare Shot", new List<AbilityMode> { new AbilityMode("ImpactShot", 15, 3, AbilityType.Rigid), new AbilityMode("Flare Spread", 20, 5, AbilityType.Rigid) });

        //This is functionally equivalent to list.Add(flareshot)
        var princessAbilities = new List<Ability> {flareShot};
        var heroAbilities = new List<Ability>();

        var silenceStatus = new Status("silence", 2, new List<StatusEffect>());
        var princessStatuses = new List<Status>() {silenceStatus};
        var heroStatuses = new List<Status>();

        var princess = new Unit("the princess", 1, 100, 5, 16, .05f, 6, 15, 1.0f, 1.0f, princessAbilities, princessStatuses);
        var hero = new Unit("the hero", 1, 140, 5, 10, .05f, 4, 20, 1.0f, 1.0f, heroAbilities, heroStatuses);

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

        StatusEffectRelay(princess);
        StatusEffectUpdate(princess);
        StatUpdate(princess);
    }

    public static void StatusEffectRelay(Unit unit)
    {
        Console.WriteLine($"- {unit.Name} [{unit.CurrentHP.ToString()}/{unit.EffectiveMaxHP.ToString()}] ({unit.Statuses[0].Name}, {unit.Statuses[0].Duration.ToString()} turns)");
    }

    public static void StatusEffectUpdate(Unit unit)
    {
        var concateStatus = "";

        for (int i = 0; i < unit.Statuses.Count; i++)
        {
            unit.Statuses[i].Duration -= 1;
            concateStatus += unit.Statuses[i].Name + "," + unit.Statuses[i].Duration.ToString() + "turns)";
            
        }
        Console.WriteLine($"- {unit.Name} [{unit.CurrentHP.ToString()}/{unit.EffectiveMaxHP.ToString()}] ({concateStatus} )");
    }

    public static void StatUpdate(Unit unit)
    {
        var statText = "";
        Console.WriteLine(unit.Name);
        Console.WriteLine($"\nLevel:  {unit.Level} ");
        Console.WriteLine($"Hp:     {unit.CurrentHP}/{unit.EffectiveMaxHP}");
        Console.WriteLine($"Move:   {unit.EffectiveMovement}");
        Console.WriteLine($"Crit %: {unit.EffectiveCritChance}");
        Console.WriteLine($"Speed:  {unit.EffectiveSpeed}");
        Console.WriteLine($"Energy: {unit.CurrentEnergy}/{unit.MaxEnergy}");
    }
}