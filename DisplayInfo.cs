using System;
using System.Diagnostics;

public static class DisplayInfo
{
    public static void CheckStatusEffect(Unit unit)
    {
        var concateStatus = "";
        for (int i = 0; i < unit.Statuses.Count; i++)
        {
            concateStatus += "(" + unit.Statuses[i].Name + ", " + unit.Statuses[i].Duration.ToString() + " turns)";
        }
        Console.WriteLine($"- {unit.Name} [{unit.CurrentHP}/{unit.EffectiveMaxHP}] {concateStatus} ");
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
    public static void CheckInventory(Unit unit)
    {
        Console.WriteLine($"{unit.Name}'s Inventory");
        Console.WriteLine($"\nEquipped Items: \n");
        foreach (var item in unit.Inventory.EquippedItems)
        {
            Console.WriteLine($"   {item.Name}");
        }
        Console.WriteLine($"\nUnequipped Items: \n");
        foreach (var item in unit.Inventory.UnequippedItems)
        {
            Console.WriteLine($"   {item.Name}");
        }
    }


}
