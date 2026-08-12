
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


        var damageCore = new Item("Damage Core", new List<ItemEffect> { new ItemEffect(1.1f, OperatorHandler.Multiply, Stat.DamageModifier, TriggerType.Combat) });
        var sacsPizza = new Item("Sacs Pizza", new List<ItemEffect> { new ItemEffect(2f, OperatorHandler.Add, Stat.Energy, TriggerType.OnEquip) });
        var sniperScope = new Item("Sniper Scope", new List<ItemEffect> { new ItemEffect(.1f, OperatorHandler.Add, Stat.CritChance, TriggerType.Combat) });
        var selerity = new Item("Selerity", new List<ItemEffect> { new ItemEffect(1f, OperatorHandler.Add, Stat.Movement, TriggerType.OnEquip) });
        var gen1Mech = new Item("Generation 1 Mech", new List<ItemEffect> { new ItemEffect((Convert.ToSingle(currentUnit.EffectiveSpeed) / 100), OperatorHandler.Add, Stat.CritChance, TriggerType.Combat) });
        var armorGames = new Item("ArmorItem", new List<ItemEffect> { new ItemEffect(.85f, OperatorHandler.Multiply, Stat.DamageReduction, TriggerType.Combat) });
        var cardinalOrnament = new Item("Cardinal Ornament", new List<ItemEffect> { new ItemEffect(1.15f, OperatorHandler.Multiply, Stat.DamageModifier, TriggerType.Combat) { TriggerCondition = ctx => ctx.AbilityUsed.AbilityType == AbilityType.Rigid } });
        var amyr = new Item("Amyr", new List<ItemEffect> { new ItemEffect(1.2f, OperatorHandler.Multiply, Stat.DamageModifier, TriggerType.Combat) { TriggerCondition = ctx => ctx.AbilityUsed.AbilityType == AbilityType.Melee && ctx.Target.EffectiveDamageReduction <= 1.0f }, new ItemEffect(1.5f, OperatorHandler.Multiply, Stat.DamageModifier, TriggerType.Combat) { TriggerCondition = ctx => ctx.Target.EffectiveDamageReduction > 1.0f && ctx.AbilityUsed.AbilityType == AbilityType.Melee } });  
        var gielinorCrest = new Item("GielinorCrest", new List<ItemEffect> { new ItemEffect(currentUnit.CurrentHP / currentUnit.EffectiveMaxHP +.5f, OperatorHandler.Multiply, Stat.DamageModifier, TriggerType.Combat) });
        var crowbar = new Item("Crowbar", new List<ItemEffect> { new ItemEffect(2f, OperatorHandler.Multiply, Stat.DamageModifier, TriggerType.Combat) }); crowbar.ListOfEffects[0].TriggerCondition = ctx => ctx.Target.CurrentHP / ctx.Target.EffectiveMaxHP > 90f / 100f;
        var maidenlessEdge = new Item("Maidenless Edge", new List<ItemEffect> { new ItemEffect(1.25f, OperatorHandler.Multiply, Stat.DamageModifier, TriggerType.Combat) { TriggerCondition = ctx => ctx.AbilityUsed.AbilityType == AbilityType.Melee } });
        var puttPuttItem = new Item("How2Play PuttPutt Walkthrough HD", new List<ItemEffect> { new ItemEffect(1.15f, OperatorHandler.Multiply, Stat.DamageModifier, TriggerType.Combat) { TriggerCondition = ctx => ctx.AbilityUsed.AbilityType == AbilityType.Targeted } });
        var radiantKnightWard = new Item("Radiant Knight Ward", new List<ItemEffect> { new ItemEffect(1.2f, OperatorHandler.Multiply, Stat.DamageReduction, TriggerType.Combat), new ItemEffect(1f, OperatorHandler.Add, Stat.Speed, TriggerType.OnLevelUp) });
        var berryHP = new Item("Berry that triggers when you get to low hp", new List<ItemEffect> { new ItemEffect(2f, OperatorHandler.Add, Stat.Movement, TriggerType.Combat) { TriggerCondition = ctx => ctx.Source.CurrentHP / ctx.Source.EffectiveMaxHP < 15f / 100f }, new ItemEffect(1.5f, OperatorHandler.Multiply, Stat.Speed, TriggerType.Combat) { TriggerCondition = ctx => ctx.Source.CurrentHP / ctx.Source.EffectiveMaxHP < 15f / 100f }, new ItemEffect(1.2f, OperatorHandler.Multiply, Stat.DamageModifier, TriggerType.Combat) { TriggerCondition = ctx => ctx.Source.CurrentHP / ctx.Source.EffectiveMaxHP < 15f / 100f }, new ItemEffect(.15f, OperatorHandler.Add, Stat.CritChance, TriggerType.Combat) { TriggerCondition = ctx => ctx.Source.CurrentHP / ctx.Source.EffectiveMaxHP < 15f / 100f } });
        var highRoller = new Item("High Roller", new List<ItemEffect> { new ItemEffect(1f, OperatorHandler.Add, Stat.Energy, TriggerType.OnCrit) });
        var hausRebuttal = new Item("Haus' Rebuttal", new List<ItemEffect> { new ItemEffect(0f, OperatorHandler.Add, Stat.DamageModifier, TriggerType.Combat) }); hausRebuttal.ListOfEffects[0].Status = burnStatus;

        var list = new List<Item> {};

        list.Add(gielinorCrest);
        list.Add(radiantKnightWard);
        list.Add(hausRebuttal);

        currentUnit.Inventory = new Inventory(list, currentUnit);

        currentUnit.Inventory.InventoryDisplay();
        //currentUnit.Inventory.InventoryModify();

        CheckStatUnit(hero);
        DamageCalculation(princess, hero);
        CheckStatUnit(hero);
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
        var attackingContextTrigger = new TriggerContext { Source = attackingUnit, Target = defendingUnit, AbilityUsed = attackingUnit.Abilities[0] };
        var defendingContextTrigger = new TriggerContext { Source = defendingUnit, Target = attackingUnit, AbilityUsed = attackingUnit.Abilities[0] };
        var activeAttackingEffects = attackingUnit.Inventory.GetActiveItemEffects(attackingContextTrigger);
        var activeDefendingEffects = defendingUnit.Inventory.GetActiveItemEffects(defendingContextTrigger);

        foreach (var effect in activeAttackingEffects) { MathHelper.ApplyEffect(effect.ModificationNumber, effect.OperatorSign, effect.StatModified, attackingUnit); }
        foreach (var effect in activeDefendingEffects) { MathHelper.ApplyEffect(effect.ModificationNumber, effect.OperatorSign, effect.StatModified, defendingUnit); }

        var attackingDamage = attackingUnit.Abilities[0].Damage * attackingUnit.EffectiveDamageModifier;
        attackingDamage = attackingDamage * defendingUnit.EffectiveDamageReduction;
        var attackingDamageInt = (int)MathF.Round(attackingDamage);
        defendingUnit.CurrentHP -= attackingDamageInt;


        attackingUnit.TimesAttacked++; defendingUnit.TimesDefended++;

        var abilityStatuses = attackingUnit.Abilities[0].Statuses;

        foreach (var effect in activeAttackingEffects)
        {
            if (effect.Status != null)
            {
                abilityStatuses.Add(effect.Status);
            }
        }

        foreach(var status in abilityStatuses)
        {
            defendingUnit.Statuses.Add(status);
        }
    }




}