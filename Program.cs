
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Security.Cryptography;

public class Program
{
    public static void Main(string[] args)
    {
        var burnStatus = new SingleStatus("Burn", 3, Stat.CurrentHp, OperatorHandler.Add, -3f);
        var freezeStatus = new MultiStatus("Freeze", 1, new List<StatusPart> { new StatusPart(Stat.Movement, OperatorHandler.Multiply, 0f), new StatusPart(Stat.Damage, OperatorHandler.Multiply, 0f)});
        var slowStatus = new SingleStatus("Slow", 1, Stat.Movement, OperatorHandler.Multiply, .5f);
        var silenceStatus = new SingleStatus("Silence", 2, Stat.Damage, OperatorHandler.Multiply, 0f);

        var snowballThrow = new Ability("Snowball Throw", 15, 4, 1, AbilityType.Targeted, new List<IStatus> { slowStatus, freezeStatus }, null);

        var flareShot = new Ability("Flare Shot", 15, 3, 1, AbilityType.Rigid, new List<IStatus> { burnStatus }, new List<AbilityEffect> { new AbilityEffect("ImpactShot", 15, 3, burnStatus), new AbilityEffect("Flare Spread", 20, 5, burnStatus) });

        //This is functionally equivalent to list.Add(flareshot)
        var princessAbilities = new List<Ability> {flareShot};
        var placeholderAbilities = new List<Ability>();

        
        var princessStatuses = new List<IStatus>() {silenceStatus, burnStatus, freezeStatus};
        var placeholderStatuses = new List<IStatus>();

        var princess = new Unit("The Princess", 1, 100, 5, 16, .05f, 6, 15, 1.0f, 1.0f, princessAbilities, princessStatuses);
        var hero = new Unit("The Hero", 1, 140, 5, 10, .05f, 4, 20, 1.0f, 1.0f, placeholderAbilities, placeholderStatuses);
        var savior = new Unit("The Savior", 1, 70, 4, 12, .10f, 3, 12, 1.0f, 1.0f, placeholderAbilities, placeholderStatuses);
        var feeder = new Unit("The Mayor", 1, 80, 4, 9, .05f, 5, 5, 1.0f, 1.0f, placeholderAbilities, placeholderStatuses);

        var unitList = new List<Unit>();
        unitList.Add(princess); 
        unitList.Add(hero);
        unitList.Add(savior);
        unitList.Add(feeder);

        var currentUnit = princess;
        var targetedUnit = hero;

        var attackingDamage = currentUnit.Abilities[0].Damage * currentUnit.EffectiveDamageModifier;
        var attackingDamageInt = (int) MathF.Round(attackingDamage);
        targetedUnit.CurrentHP -= attackingDamageInt;



        var damageCore = new Item("DamageCore", new List<ItemEffect> { new ItemEffect(1.1f, OperatorHandler.Multiply, Stat.DamageModifier, TriggerType.Combat, ctx => true), new ItemEffect(3f, OperatorHandler.Add, Stat.Speed, TriggerType.Combat, ctx => true) });
        var sacsPizza = new Item("SacsPizza", new List<ItemEffect> { new ItemEffect(3f, OperatorHandler.Add, Stat.Speed, TriggerType.Combat, ctx => true) });
        var sniperScope = new Item("SniperScope", new List<ItemEffect> { new ItemEffect(.1f, OperatorHandler.Add, Stat.CritChance, TriggerType.Combat, ctx => true)});
        var coolItem = new Item("CoolItem", new List<ItemEffect> { new ItemEffect(3f, OperatorHandler.Add, Stat.Movement, TriggerType.Combat, ctx => true), new ItemEffect(1f, OperatorHandler.Add, Stat.Speed, TriggerType.Combat, ctx => true) });
        var gen1Mech = new Item("Gen1Mech", new List<ItemEffect> { new ItemEffect((Convert.ToSingle(currentUnit.EffectiveSpeed) / 100), OperatorHandler.Add, Stat.CritChance, TriggerType.Combat, ctx => true) });
        var testDamageReductionItem = new Item("ArmorItem", new List<ItemEffect> { new ItemEffect(.7f, OperatorHandler.Multiply, Stat.DamageReduction, TriggerType.Combat, ctx => true) });
        var twoEffectItem = new Item("test", new List<ItemEffect> { new ItemEffect(5f, OperatorHandler.Add, Stat.CritChance, TriggerType.Combat, ctx => true), new ItemEffect(1.15f, OperatorHandler.Multiply, Stat.DamageModifier, TriggerType.Combat, ctx => ctx.AbilityUsed.AbilityType == AbilityType.Rigid ) });
        var amyr = new Item("Amyr", new List<ItemEffect> { new ItemEffect(1.2f, OperatorHandler.Multiply, Stat.DamageModifier, TriggerType.Combat, ctx => ctx.AbilityUsed.AbilityType == AbilityType.Melee && ctx.Target.EffectiveDamageReduction <= 1.0f), new ItemEffect(1.5f, OperatorHandler.Multiply, Stat.DamageModifier, TriggerType.Combat, ctx => ctx.Target.EffectiveDamageReduction > 1.0f && ctx.AbilityUsed.AbilityType == AbilityType.Melee) });


        var list = new List<Item> {};

        list.Add(damageCore);
        list.Add(sacsPizza);
        list.Add(sniperScope);
        list.Add(coolItem);
        list.Add(gen1Mech);
        list.Add(testDamageReductionItem);

        currentUnit.Inventory = new Inventory(list, currentUnit);

        currentUnit.Inventory.InventoryDisplay();
        currentUnit.Inventory.InventoryModify();

        attackingDamage = currentUnit.Abilities[0].Damage * currentUnit.EffectiveDamageModifier;
        attackingDamageInt = (int)MathF.Round(attackingDamage);
        targetedUnit.CurrentHP -= attackingDamageInt;

        CheckStatUnit(princess);
        DamageCalculation(princess, hero);
        CheckStatUnit(princess);
    }

    public static void CheckStatusEffect(Unit unit)
    {
        var concateStatus = "";
        for (int i = 0; i < unit.Statuses.Count; i++)
        {
            concateStatus += "(" + unit.Statuses[i].Name + ", " + unit.Statuses[i].Duration.ToString() + " turns)";
        }
        Console.WriteLine($"- {unit.Name} [{unit.CurrentHP}/{unit.EffectiveMaxHP}] {concateStatus} ");
    }

    public static void UpdateStatusEffect(Unit unit)
    {
        var concateStatus = "";
        for (int i = 0; i < unit.Statuses.Count; i++)
        {
            unit.Statuses[i].Duration -= 1;
            concateStatus += "(" + unit.Statuses[i].Name + ", " + unit.Statuses[i].Duration.ToString() + " turns)";
        }
        Console.WriteLine($"- {unit.Name} [{unit.CurrentHP}/{unit.EffectiveMaxHP}] {concateStatus} ");
    }

    public static void ApplyStatusEffect(Unit unit)
    {
        foreach(var status in unit.Statuses)
        {
            status.ApplyStatus(unit);
        }
    }


    public static void CheckStatUnit(Unit unit)
    {
        Console.WriteLine($"\n {unit.Name} \n");
        Console.WriteLine($"Level:  {unit.Level} ");
        Console.WriteLine($"Hp:     {unit.CurrentHP}/{unit.EffectiveMaxHP}");
        Console.WriteLine($"Move:   {unit.EffectiveMovement}");
        Console.WriteLine($"Crit %: {unit.EffectiveCritChance}");
        Console.WriteLine($"Speed:  {unit.EffectiveSpeed}");
        Console.WriteLine($"Energy: {unit.CurrentEnergy}/{unit.MaxEnergy}");
        Console.WriteLine($"Damage: {unit.EffectiveDamage}");

        var concateStatus = "";

        for (int i = 0; i < unit.Statuses.Count; i++)
        {
            concateStatus += "(" + unit.Statuses[i].Name + ", " + unit.Statuses[i].Duration.ToString() + " turns)";
        }
        Console.WriteLine($"\n{concateStatus}");

        foreach (var ability in unit.Abilities)
        {
            Console.WriteLine($"{ability.AbilityName}");
            Console.WriteLine($"\n Range:  {ability.Range}");
            Console.WriteLine($"\n Damage: {ability.Damage}");
            if (ability.Multihits > 1)
            {
                Console.WriteLine($"\n Multihits: {ability.Multihits}x");
            }
            
        }
    }

    public static void CheckStatAll(List<Unit> unitList)
    {
        for (int i = 0; i < unitList.Count; i++)
        {
            Console.WriteLine($"\n {unitList[i].Name} \n");
            Console.WriteLine($"Level:  {unitList[i].Level} ");
            Console.WriteLine($"Hp:     {unitList[i].CurrentHP}/{unitList[i].EffectiveMaxHP}");
            Console.WriteLine($"Move:   {unitList[i].EffectiveMovement}");
            Console.WriteLine($"Crit %: {unitList[i].EffectiveCritChance}");
            Console.WriteLine($"Speed:  {unitList[i].EffectiveSpeed}");
            Console.WriteLine($"Energy: {unitList[i].CurrentEnergy}/{unitList[i].MaxEnergy}");
            Console.WriteLine($"DamRed: {unitList[i].EffectiveDamageReduction}");
        }
    }

    public static void DamageCalculation(Unit attackingUnit, Unit defendingUnit)
    {
        var attackingDamage = attackingUnit.Abilities[0].Damage * attackingUnit.EffectiveDamageModifier;
        var contextTrigger = new TriggerContext { Source = attackingUnit, Target = defendingUnit, AbilityUsed = attackingUnit.Abilities[0] };
        var activeEffects = attackingUnit.Inventory.GetActiveItemEffects(contextTrigger);

        foreach (var effect in activeEffects) { Console.WriteLine(effect.ToString()); }

        attackingDamage = attackingDamage * defendingUnit.EffectiveDamageReduction;
        var attackingDamageInt = (int)MathF.Round(attackingDamage);
        defendingUnit.CurrentHP -= attackingDamageInt;

        var abilityStatuses = attackingUnit.Abilities[0].Statuses;
        foreach(var status in abilityStatuses)
        {
            defendingUnit.Statuses.Add(status);
        }
    }




}