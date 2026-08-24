
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Net.WebSockets;
using System.Security.Cryptography;

public class Program
{
    public static void Main(string[] args)
    {
        var freezeStatus = new MultiStatus("Freeze", 1, new List<StatusPart> { new StatusPart(Stat.Movement, OperatorHandler.Multiply, 0f), new StatusPart(Stat.DamageModifier, OperatorHandler.Multiply, 0f) });
        var slowStatus = new SingleStatus("Slow", 1, Stat.Movement, OperatorHandler.Multiply, .5f);
        var silenceStatus = new SingleStatus("Silence", 2, Stat.DamageModifier, OperatorHandler.Multiply, 0f);

        var snowballThrow = new Ability("Snowball Throw", 15, 4, 1, AbilityType.Targeted, null) { Statuses = new List<IStatus> { slowStatus, freezeStatus }, };

        var flareShot = new Ability("Flare Shot", 15, 3, 1, AbilityType.Rigid, new List<AbilityEffect> { new AbilityEffect("ImpactShot", 15, 3, slowStatus), new AbilityEffect("Flare Spread", 20, 5, slowStatus) }) { Statuses = new List<IStatus> { slowStatus }, };

        //This is functionally equivalent to list.Add(flareshot)
        var princessAbilities = new List<Ability> { flareShot };
        var placeholderAbilities = new List<Ability>();


        var princessStatuses = new List<IStatus>() { slowStatus };
        var placeholderStatuses = new List<IStatus>();

        var princess = new Unit("The Princess", 100, 5, 16, .05f, 6, princessAbilities, princessStatuses);
        var hero = new Unit("The Hero", 140, 5, 10, .05f, 4, placeholderAbilities, placeholderStatuses);
        var savior = new Unit("The Savior", 70, 4, 12, .10f, 3, placeholderAbilities, placeholderStatuses);
        var feeder = new Unit("The Mayor", 80, 4, 9, .05f, 5, placeholderAbilities, placeholderStatuses);

        var unitList = new List<Unit>() { princess, hero, savior, feeder };

        var currentUnit = princess;
        var targetedUnit = hero;


        var damageCore = new Item("Damage Core", new List<ItemEffect> { new ItemEffect(1.1f, OperatorHandler.Multiply, Stat.DamageModifier) });
        var sacsPizza = new Item("Sacs Pizza", new List<ItemEffect> { new ItemEffect(2f, OperatorHandler.Add, Stat.Energy) { TriggerType = TriggerType.OnEquip } });
        var sniperScope = new Item("Sniper Scope", new List<ItemEffect> { new ItemEffect(.1f, OperatorHandler.Add, Stat.CritChance) });
        var selerity = new Item("Selerity", new List<ItemEffect> { new ItemEffect(1f, OperatorHandler.Add, Stat.Movement) { TriggerType = TriggerType.OnEquip } });
        var gen1Mech = new Item("Generation 1 Mech", new List<ItemEffect> { new ItemEffect((Convert.ToSingle(currentUnit.EffectiveSpeed) / 100), OperatorHandler.Add, Stat.CritChance) });
        var armorGames = new Item("ArmorItem", new List<ItemEffect> { new ItemEffect(.85f, OperatorHandler.Multiply, Stat.DamageReduction) });
        var cardinalOrnament = new Item("Cardinal Ornament", new List<ItemEffect> { new ItemEffect(1.15f, OperatorHandler.Multiply, Stat.DamageModifier) { TriggerCondition = ctx => ctx.AbilityUsed?.AbilityType == AbilityType.Rigid } });
        var amyr = new Item("Amyr", new List<ItemEffect> { new ItemEffect(1.2f, OperatorHandler.Multiply, Stat.DamageModifier) { TriggerCondition = ctx => ctx.AbilityUsed?.AbilityType == AbilityType.Melee && ctx.Target?.EffectiveDamageReduction <= 1.0f }, new ItemEffect(1.5f, OperatorHandler.Multiply, Stat.DamageModifier) { TriggerCondition = ctx => ctx.Target?.EffectiveDamageReduction > 1.0f && ctx.AbilityUsed?.AbilityType == AbilityType.Melee } });  
        var gielinorCrest = new Item("GielinorCrest", new List<ItemEffect> { new ItemEffect(currentUnit.CurrentHP / currentUnit.EffectiveMaxHP +.5f, OperatorHandler.Multiply, Stat.DamageModifier) });
        var crowbar = new Item("Crowbar", new List<ItemEffect> { new ItemEffect(2f, OperatorHandler.Multiply, Stat.DamageModifier) { TriggerCondition = ctx => ctx.Target.CurrentHP / ctx.Target.EffectiveMaxHP > 90f / 100f } });
        var maidenlessEdge = new Item("Maidenless Edge", new List<ItemEffect> { new ItemEffect(1.25f, OperatorHandler.Multiply, Stat.DamageModifier) { TriggerCondition = ctx => ctx.AbilityUsed?.AbilityType == AbilityType.Melee } });
        var puttPuttItem = new Item("How2Play PuttPutt Walkthrough HD", new List<ItemEffect> { new ItemEffect(1.15f, OperatorHandler.Multiply, Stat.DamageModifier) { TriggerCondition = ctx => ctx.AbilityUsed?.AbilityType == AbilityType.Targeted } });
        var radiantKnightWard = new Item("Radiant Knight Ward", new List<ItemEffect> { new ItemEffect(1.2f, OperatorHandler.Multiply, Stat.DamageReduction), new ItemEffect(1f, OperatorHandler.Add, Stat.Speed) { TriggerType = TriggerType.OnLevelUp } });
        var berryHP = new Item("Berry that triggers when you get to low hp", new List<ItemEffect> { new ItemEffect(2f, OperatorHandler.Add, Stat.Movement) { TriggerCondition = ctx => ctx.Source.CurrentHP / ctx.Source.EffectiveMaxHP < 15f / 100f }, new ItemEffect(1.5f, OperatorHandler.Multiply, Stat.Speed) { TriggerCondition = ctx => ctx.Source.CurrentHP / ctx.Source.EffectiveMaxHP < 15f / 100f }, new ItemEffect(1.2f, OperatorHandler.Multiply, Stat.DamageModifier) { TriggerCondition = ctx => ctx.Source.CurrentHP / ctx.Source.EffectiveMaxHP < 15f / 100f }, new ItemEffect(.15f, OperatorHandler.Add, Stat.CritChance) { TriggerCondition = ctx => ctx.Source.CurrentHP / ctx.Source.EffectiveMaxHP < 15f / 100f } });
        var highRoller = new Item("High Roller", new List<ItemEffect> { new ItemEffect(1f, OperatorHandler.Add, Stat.Energy) { TriggerType = TriggerType.OnCrit } });
        var hausRebuttal = new Item("Haus' Rebuttal", new List<ItemEffect> { new ItemEffect(0f, OperatorHandler.Add, Stat.DamageModifier) { Status = slowStatus } });

        //var listOfAllItems = new List<Item> { damageCore , sacsPizza , sniperScope , selerity , gen1Mech , armorGames , cardinalOrnament , amyr , gielinorCrest , crowbar , maidenlessEdge , puttPuttItem , radiantKnightWard , berryHP , highRoller , hausRebuttal };

        var testUnequippedItemsList = new List<Item> { crowbar, berryHP };
        var currentUnitItemList = new List<Item> { damageCore };
        currentUnit.Inventory = new Inventory(currentUnitItemList, testUnequippedItemsList ,currentUnit);

        var targetedUnitItemList = new List<Item> { armorGames };
        targetedUnit.Inventory = new Inventory(targetedUnitItemList, targetedUnit);

        princess = currentUnit;
        hero = targetedUnit;

        //DisplayInfo.CheckStatUnit(targetedUnit);
        //var attackedUnit = UnitAttack(unitList);
        //DisplayInfo.CheckStatUnit(attackedUnit);

        foreach (var item in princess.Inventory.UnequippedItems)
        {
            Console.WriteLine($" {item.ItemName}");
        }
        foreach (var item in savior.Inventory.UnequippedItems)
        {
            Console.WriteLine($" {item.ItemName}");
        }

        ItemThrow(unitList);

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

    public static void DamageCalculation(Unit attackingUnit, Unit defendingUnit, Ability abilityUsed)
    {
        var contextTrigger = new TriggerContext(attackingUnit, TriggerType.Combat) { Target = defendingUnit, AbilityUsed = abilityUsed };
        attackingUnit.CalculateEffectiveStats(contextTrigger);
        defendingUnit.CalculateEffectiveStats(contextTrigger);
        var attackingDamage = abilityUsed.Damage * attackingUnit.EffectiveDamageModifier;
        Console.WriteLine($"DamageModifier: {attackingUnit.EffectiveDamageModifier} ");
        Console.WriteLine($"Initial Attack Damage: { abilityUsed.Damage } ");
        attackingDamage = attackingDamage * defendingUnit.EffectiveDamageReduction;
        Console.WriteLine($"Attack Damage after Damage Reduction: { attackingDamage } ");
        var attackingDamageInt = (int)MathF.Round(attackingDamage);
        defendingUnit.CurrentHP -= attackingDamageInt;

        attackingUnit.TimesAttacked++; defendingUnit.TimesDefended++;
        var activeAttackingEffects = attackingUnit.Inventory.GetActiveItemEffects(contextTrigger);

        foreach (var itemEffect in activeAttackingEffects)
        {
            if (itemEffect.Status != null)
            {
                abilityUsed.Statuses?.Add(itemEffect.Status);
            }
        }
        foreach(var status in abilityUsed.Statuses)
        {
            defendingUnit.Statuses.Add(status);
        }
    }

    public static Unit UnitAttack(List<Unit> unitList)
    {
        Console.WriteLine("Which unit is attacking?");
        var optionInt = 0;
        foreach (var unit in unitList)
        {
            Console.WriteLine($" {optionInt}: {unit.Name}");
            optionInt++;
        }
        var attackingUnitInput = Console.ReadLine();
        var attackingUnit = unitList[Int32.Parse(attackingUnitInput)];

        Console.WriteLine("Which unit is being hit?");
        optionInt = 0;
        foreach (var unit in unitList)
        {
            Console.WriteLine($" {optionInt}: {unit.Name}");
            optionInt++;
        }
        var defendingUnitInput = Console.ReadLine();
        var defendingUnit = unitList[Int32.Parse(defendingUnitInput)];

        Console.WriteLine("What Ability is being used?");
        optionInt = 0;
        foreach (var ability in attackingUnit.Abilities)
        {
            Console.WriteLine($" {optionInt}: {ability.AbilityName}");
            optionInt++;
        }
        var abilityUsedInput = Console.ReadLine();
        var abilityUsed = attackingUnit.Abilities[Int32.Parse(abilityUsedInput)];

        DamageCalculation(attackingUnit, defendingUnit, abilityUsed);

        return defendingUnit;
    }

    public static void ItemThrow(List<Unit> unitList)
    {
        Console.WriteLine("Which unit is throwing?");
        var optionInt = 0;
        foreach (var unit in unitList)
        {
            Console.WriteLine($" {optionInt}: {unit.Name}");
            optionInt++;
        }
        var throwingUnitInput = Console.ReadLine();
        var throwingUnit = unitList[Int32.Parse(throwingUnitInput)];

        Console.WriteLine("Which unit is being thrown to?");
        optionInt = 0;
        foreach (var unit in unitList)
        {
            Console.WriteLine($" {optionInt}: {unit.Name}");
            optionInt++;
        }
        var throwntoUnitInput = Console.ReadLine();
        var throwntoUnit = unitList[Int32.Parse(throwntoUnitInput)];

        Console.WriteLine("Which Item is being thrown?");
        optionInt = 0;
        foreach(var item in throwingUnit.Inventory.UnequippedItems)
        {
            Console.WriteLine($" {optionInt}: {item.ItemName}");
            optionInt++;
        }
        var thrownItemInput = Console.ReadLine();
        var thrownItem = throwingUnit.Inventory.UnequippedItems[Int32.Parse(thrownItemInput)];


        throwntoUnit.Inventory.UnequippedItems.Add(thrownItem);
        throwingUnit.Inventory.UnequippedItems.Remove(thrownItem);

        foreach(var item in throwntoUnit.Inventory.UnequippedItems)
        {
            Console.WriteLine($"{throwntoUnit.Name}: {item.ItemName}");
        }
        foreach (var item in throwingUnit.Inventory.UnequippedItems)
        {
            Console.WriteLine($"{throwingUnit.Name}: {item.ItemName}");
        }
    }


}