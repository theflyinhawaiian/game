
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Net.WebSockets;
using System.Security.Cryptography;

public class Program
{
    public static void Main(string[] args)
    {
        var burnStatus = new SingleStatus("Burn", 3, Stat.CurrentHp, OperatorHandler.Add, -3f);
        var freezeStatus = new MultiStatus("Freeze", 1, new List<StatusPart> { new StatusPart(Stat.Movement, OperatorHandler.Multiply, 0f), new StatusPart(Stat.Damage, OperatorHandler.Multiply, 0f) });
        var slowStatus = new SingleStatus("Slow", 1, Stat.Movement, OperatorHandler.Multiply, .5f);
        var silenceStatus = new SingleStatus("Silence", 2, Stat.Damage, OperatorHandler.Multiply, 0f);

        var snowballThrow = new Ability("Snowball Throw", 15, 4, 1, AbilityType.Targeted, new List<IStatus> { slowStatus, freezeStatus }, null);

        var flareShot = new Ability("Flare Shot", 15, 3, 1, AbilityType.Rigid, new List<IStatus> { burnStatus }, new List<AbilityEffect> { new AbilityEffect("ImpactShot", 15, 3, burnStatus), new AbilityEffect("Flare Spread", 20, 5, burnStatus) });

        //This is functionally equivalent to list.Add(flareshot)
        var princessAbilities = new List<Ability> { flareShot };
        var placeholderAbilities = new List<Ability>();


        var princessStatuses = new List<IStatus>() { silenceStatus, burnStatus, freezeStatus };
        var placeholderStatuses = new List<IStatus>();

        var princess = new Unit("princess", 100, 5, 16, .05f, 6, 15, princessAbilities, princessStatuses);
        var hero = new Unit("hero", 140, 5, 10, .05f, 4, 20, placeholderAbilities, placeholderStatuses);
        var savior = new Unit("savior", 70, 4, 12, .10f, 3, 12, placeholderAbilities, placeholderStatuses);
        var feeder = new Unit("mayor", 80, 4, 9, .05f, 5, 5, placeholderAbilities, placeholderStatuses);

        var unitList = new List<Unit>() { princess, hero, savior, feeder };

        var currentUnit = princess;
        var targetedUnit = hero;


        var damageCore = new Item("Damage Core", new List<ItemEffect> { new ItemEffect(1.1f, OperatorHandler.Multiply, Stat.DamageModifier) });
        var sacsPizza = new Item("Sacs Pizza", new List<ItemEffect> { new ItemEffect(2f, OperatorHandler.Add, Stat.Energy) { TriggerType = TriggerType.OnEquip } });
        var sniperScope = new Item("Sniper Scope", new List<ItemEffect> { new ItemEffect(.1f, OperatorHandler.Add, Stat.CritChance) });
        var selerity = new Item("Selerity", new List<ItemEffect> { new ItemEffect(1f, OperatorHandler.Add, Stat.Movement) { TriggerType = TriggerType.OnEquip } });
        var gen1Mech = new Item("Generation 1 Mech", new List<ItemEffect> { new ItemEffect((Convert.ToSingle(currentUnit.EffectiveSpeed) / 100), OperatorHandler.Add, Stat.CritChance) });
        var armorGames = new Item("ArmorItem", new List<ItemEffect> { new ItemEffect(.85f, OperatorHandler.Multiply, Stat.DamageReduction) });
        var cardinalOrnament = new Item("Cardinal Ornament", new List<ItemEffect> { new ItemEffect(1.15f, OperatorHandler.Multiply, Stat.DamageModifier) { TriggerCondition = ctx => ctx.AbilityUsed.AbilityType == AbilityType.Rigid } });
        var amyr = new Item("Amyr", new List<ItemEffect> { new ItemEffect(1.2f, OperatorHandler.Multiply, Stat.DamageModifier) { TriggerCondition = ctx => ctx.AbilityUsed.AbilityType == AbilityType.Melee && ctx.Target.EffectiveDamageReduction <= 1.0f }, new ItemEffect(1.5f, OperatorHandler.Multiply, Stat.DamageModifier) { TriggerCondition = ctx => ctx.Target.EffectiveDamageReduction > 1.0f && ctx.AbilityUsed.AbilityType == AbilityType.Melee } });  
        var gielinorCrest = new Item("GielinorCrest", new List<ItemEffect> { new ItemEffect(currentUnit.CurrentHP / currentUnit.EffectiveMaxHP +.5f, OperatorHandler.Multiply, Stat.DamageModifier) });
        var crowbar = new Item("Crowbar", new List<ItemEffect> { new ItemEffect(2f, OperatorHandler.Multiply, Stat.DamageModifier) { TriggerCondition = ctx => ctx.Target.CurrentHP / ctx.Target.EffectiveMaxHP > 90f / 100f } });
        var maidenlessEdge = new Item("Maidenless Edge", new List<ItemEffect> { new ItemEffect(1.25f, OperatorHandler.Multiply, Stat.DamageModifier) { TriggerCondition = ctx => ctx.AbilityUsed.AbilityType == AbilityType.Melee } });
        var puttPuttItem = new Item("How2Play PuttPutt Walkthrough HD", new List<ItemEffect> { new ItemEffect(1.15f, OperatorHandler.Multiply, Stat.DamageModifier) { TriggerCondition = ctx => ctx.AbilityUsed.AbilityType == AbilityType.Targeted } });
        var radiantKnightWard = new Item("Radiant Knight Ward", new List<ItemEffect> { new ItemEffect(1.2f, OperatorHandler.Multiply, Stat.DamageReduction), new ItemEffect(1f, OperatorHandler.Add, Stat.Speed) { TriggerType = TriggerType.OnLevelUp } });
        var berryHP = new Item("Berry that triggers when you get to low hp", new List<ItemEffect> { new ItemEffect(2f, OperatorHandler.Add, Stat.Movement) { TriggerCondition = ctx => ctx.Source.CurrentHP / ctx.Source.EffectiveMaxHP < 15f / 100f }, new ItemEffect(1.5f, OperatorHandler.Multiply, Stat.Speed) { TriggerCondition = ctx => ctx.Source.CurrentHP / ctx.Source.EffectiveMaxHP < 15f / 100f }, new ItemEffect(1.2f, OperatorHandler.Multiply, Stat.DamageModifier) { TriggerCondition = ctx => ctx.Source.CurrentHP / ctx.Source.EffectiveMaxHP < 15f / 100f }, new ItemEffect(.15f, OperatorHandler.Add, Stat.CritChance) { TriggerCondition = ctx => ctx.Source.CurrentHP / ctx.Source.EffectiveMaxHP < 15f / 100f } });
        var highRoller = new Item("High Roller", new List<ItemEffect> { new ItemEffect(1f, OperatorHandler.Add, Stat.Energy) { TriggerType = TriggerType.OnCrit } });
        var hausRebuttal = new Item("Haus' Rebuttal", new List<ItemEffect> { new ItemEffect(0f, OperatorHandler.Add, Stat.DamageModifier) { Status = burnStatus } }); 

        var list = new List<Item> {};

        list.Add(gielinorCrest);
        list.Add(radiantKnightWard);
        list.Add(hausRebuttal);

        currentUnit.Inventory = new Inventory(list, currentUnit);

        currentUnit.Inventory.InventoryDisplay();
        //currentUnit.Inventory.InventoryModify();

        DamageCalculation(currentUnit, targetedUnit, currentUnit.Abilities[0]);
        CheckStatUnit(targetedUnit);

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

    public static void DamageCalculation(Unit attackingUnit, Unit defendingUnit, Ability abilityUsed)
    {
        var attackingContextTrigger = new TriggerContext { Source = attackingUnit, Target = defendingUnit, AbilityUsed = abilityUsed };
        var defendingContextTrigger = new TriggerContext { Source = defendingUnit, Target = attackingUnit, AbilityUsed = abilityUsed };
        var activeAttackingEffects = attackingUnit.Inventory.GetActiveItemEffects(attackingContextTrigger);
        var activeDefendingEffects = defendingUnit.Inventory.GetActiveItemEffects(defendingContextTrigger);

        foreach (var effect in activeAttackingEffects) { MathHelper.ApplyEffect(effect.ModificationNumber, effect.OperatorSign, effect.StatModified, attackingUnit); }
        foreach (var effect in activeDefendingEffects) { MathHelper.ApplyEffect(effect.ModificationNumber, effect.OperatorSign, effect.StatModified, defendingUnit); }

        var attackingDamage = abilityUsed.Damage * attackingUnit.EffectiveDamageModifier;
        attackingDamage = attackingDamage * defendingUnit.EffectiveDamageReduction;
        var attackingDamageInt = (int)MathF.Round(attackingDamage);
        defendingUnit.CurrentHP -= attackingDamageInt;


        attackingUnit.TimesAttacked++; defendingUnit.TimesDefended++;

        foreach (var itemEffect in activeAttackingEffects)
        {
            if (itemEffect.Status != null)
            {
                abilityUsed.Statuses.Add(itemEffect.Status);
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


}