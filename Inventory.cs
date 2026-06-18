using System;

public class Inventory
{
	public List<Item> Items {  get; set; }
    public Unit Unit { get; set; }

    public Inventory(Unit unit)
    {
        Items = new List<Item>();
        Unit = unit;

    }

    public Inventory(List<Item> items)
    {
        Items = items;
    }

    public void InventoryDisplay()
    {
        foreach (var item in Items)
        {
            string str = "";
            foreach(var effect in item.listOfEffects)
            {
                var modNumberStr = effect.ModificationNumber.ToString();
                var operatorSignStr = effect.OperatorSign.ToString();
                var statModifiedStr = effect.StatModified.ToString();

                str = str + statModifiedStr + ": " + operatorSignStr + " " + modNumberStr + "; ";
            }
            Console.WriteLine(str);
        }
    }

    public void InventoryModify()
    {
        foreach(var item in Items)
        {
            foreach( var effect in item.listOfEffects)
            {
                if (effect.StatModified == Stat.Hp) 
                {  
                    if (effect.OperatorSign == OperatorHandler.Add)
                    {
                        Unit.EffectiveMaxHP = Unit.BaseHP + Convert.ToInt32(effect.ModificationNumber);
                    }
                    else if (effect.OperatorSign == OperatorHandler.Multiply)
                    {
                        Unit.EffectiveMaxHP = Unit.BaseHP * Convert.ToInt32(effect.ModificationNumber);
                    }
                }
                else if (effect.StatModified == Stat.Movement) { var modifyingStat = Unit.BaseMovement; }
                else if (effect.StatModified == Stat.CritChance) { var modifyingStat = Unit.BaseCritChance; }
                else if (effect.StatModified == Stat.Speed) { var modifyingStat = Unit.BaseSpeed; }
                else if (effect.StatModified == Stat.Energy) { var modifyingStat = Unit.CurrentEnergy; }
                else if (effect.StatModified == Stat.Damage) { var modifyingStat = Unit.BaseDamage; }
                else if (effect.StatModified == Stat.DamageModifier) { var modifyingStat = Unit.DamageModifier; }
                else if (effect.StatModified == Stat.DamageReduction) { var modifyingStat = Unit.DamageReduction; }

                
            }
        }
    }
}
