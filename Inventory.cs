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

    public Inventory(List<Item> items, Unit unit)
    {
        Items = items;
        Unit = unit;
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
                else if (effect.StatModified == Stat.Movement) 
                {
                    if (effect.OperatorSign == OperatorHandler.Add)
                    {
                        Unit.EffectiveMovement = Unit.BaseMovement + Convert.ToInt32(effect.ModificationNumber);
                    }
                    else if (effect.OperatorSign == OperatorHandler.Multiply)
                    {
                        Unit.EffectiveMovement = Unit.BaseMovement * Convert.ToInt32(effect.ModificationNumber);
                    }
                }
                else if (effect.StatModified == Stat.CritChance) 
                {
                    if (effect.OperatorSign == OperatorHandler.Add)
                    {
                        Unit.EffectiveCritChance = Unit.BaseCritChance + Convert.ToInt32(effect.ModificationNumber);
                    }
                    else if (effect.OperatorSign == OperatorHandler.Multiply)
                    {
                        Unit.EffectiveCritChance = Unit.BaseCritChance * Convert.ToInt32(effect.ModificationNumber);
                    }
                }
                else if (effect.StatModified == Stat.Speed)
                {
                    if (effect.OperatorSign == OperatorHandler.Add)
                    {
                        Unit.EffectiveSpeed = Unit.BaseSpeed + Convert.ToInt32(effect.ModificationNumber);
                    }
                    else if (effect.OperatorSign == OperatorHandler.Multiply)
                    {
                        Unit.EffectiveSpeed = Unit.BaseSpeed * Convert.ToInt32(effect.ModificationNumber);
                    }
                }
                else if (effect.StatModified == Stat.Energy)
                {
                    if (effect.OperatorSign == OperatorHandler.Add)
                    {
                        Unit.CurrentEnergy = Unit.CurrentEnergy + Convert.ToInt32(effect.ModificationNumber);
                    }
                    else if (effect.OperatorSign == OperatorHandler.Multiply)
                    {
                        Unit.CurrentEnergy = Unit.CurrentEnergy * Convert.ToInt32(effect.ModificationNumber);
                    }

                    if (Unit.CurrentEnergy > Unit.MaxEnergy)
                    {
                        Unit.CurrentEnergy = Unit.MaxEnergy;
                    }
                }
                else if (effect.StatModified == Stat.Damage)
                {
                    if (effect.OperatorSign == OperatorHandler.Add)
                    {
                        Unit.EffectiveDamage = Unit.BaseDamage + Convert.ToInt32(effect.ModificationNumber);
                    }
                    else if (effect.OperatorSign == OperatorHandler.Multiply)
                    {
                        Unit.EffectiveDamage = Unit.BaseDamage * Convert.ToInt32(effect.ModificationNumber);
                    }
                }
                else if (effect.StatModified == Stat.DamageModifier)
                {
                    if (effect.OperatorSign == OperatorHandler.Add)
                    {
                        Unit.EffectiveDamageModifier = Unit.BaseDamageModifier + effect.ModificationNumber;
                    }
                    else if (effect.OperatorSign == OperatorHandler.Multiply)
                    {
                        Unit.EffectiveDamageModifier = Unit.BaseDamageModifier * effect.ModificationNumber;
                    }
                }
                else if (effect.StatModified == Stat.DamageReduction)
                {
                    if (effect.OperatorSign == OperatorHandler.Add)
                    {
                        Unit.DamageReduction = Unit.DamageReduction + Convert.ToInt32(effect.ModificationNumber);
                    }
                    else if (effect.OperatorSign == OperatorHandler.Multiply)
                    {
                        Unit.DamageReduction = Unit.DamageReduction * Convert.ToInt32(effect.ModificationNumber);
                    }
                }
            }
        }
    }
}
