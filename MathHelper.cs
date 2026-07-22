using System;

public static class MathHelper
{

    public static void ApplyEffect(float modificationNumber, OperatorHandler operatorSign, Stat statModified, Unit unit)
    {
        if (statModified == Stat.MaxHp)
        {
            if (operatorSign == OperatorHandler.Add)
            {
                unit.EffectiveMaxHP = unit.BaseHP + Convert.ToInt32(modificationNumber);
            }
            else if (operatorSign == OperatorHandler.Multiply)
            {
                unit.EffectiveMaxHP = unit.BaseHP * Convert.ToInt32(modificationNumber);
            }
            if (unit.CurrentHP > unit.EffectiveMaxHP) { unit.CurrentHP = unit.EffectiveMaxHP; }
        }
        else if (statModified == Stat.CurrentHp)
        {
            if (operatorSign == OperatorHandler.Add)
            {
                unit.CurrentHP = unit.CurrentHP + Convert.ToInt32(modificationNumber);
            }
            else if (operatorSign == OperatorHandler.Multiply)
            {
                unit.CurrentHP = unit.CurrentHP * Convert.ToInt32(modificationNumber);
            }
            if (unit.CurrentHP > unit.EffectiveMaxHP) { unit.CurrentHP = unit.EffectiveMaxHP; }
        }
        
        else if (statModified == Stat.Movement)
        {
            if (operatorSign == OperatorHandler.Add)
            {
                unit.EffectiveMovement = unit.BaseMovement + Convert.ToInt32(modificationNumber);
            }
            else if (operatorSign == OperatorHandler.Multiply)
            {
                unit.EffectiveMovement = unit.BaseMovement * Convert.ToInt32(modificationNumber);
            }
        }
        else if (statModified == Stat.CritChance)
        {
            if (operatorSign == OperatorHandler.Add)
            {
                unit.EffectiveCritChance = unit.BaseCritChance + modificationNumber;
            }
            else if (operatorSign == OperatorHandler.Multiply)
            {
                unit.EffectiveCritChance = unit.BaseCritChance * modificationNumber;
            }
        }
        else if (statModified == Stat.Speed)
        {
            if (operatorSign == OperatorHandler.Add)
            {
                unit.EffectiveSpeed = unit.BaseSpeed + Convert.ToInt32(modificationNumber);
            }
            else if (operatorSign == OperatorHandler.Multiply)
            {
                unit.EffectiveSpeed = unit.BaseSpeed * Convert.ToInt32(modificationNumber);
            }
        }
        else if (statModified == Stat.Energy)
        {
            if (operatorSign == OperatorHandler.Add)
            {
                unit.CurrentEnergy = unit.CurrentEnergy + Convert.ToInt32(modificationNumber);
            }
            else if (operatorSign == OperatorHandler.Multiply)
            {
                unit.CurrentEnergy = unit.CurrentEnergy * Convert.ToInt32(modificationNumber);
            }

            if (unit.CurrentEnergy > unit.MaxEnergy)
            {
                unit.CurrentEnergy = unit.MaxEnergy;
            }
        }
        else if (statModified == Stat.Damage)
        {
            if (operatorSign == OperatorHandler.Add)
            {
                unit.EffectiveDamage = unit.BaseDamage + Convert.ToInt32(modificationNumber);
            }
            else if (operatorSign == OperatorHandler.Multiply)
            {
                unit.EffectiveDamage = unit.BaseDamage * Convert.ToInt32(modificationNumber);
            }
        }
        else if (statModified == Stat.DamageModifier)
        {
            if (operatorSign == OperatorHandler.Add)
            {
                unit.EffectiveDamageModifier = unit.BaseDamageModifier + modificationNumber;
            }
            else if (operatorSign == OperatorHandler.Multiply)
            {
                unit.EffectiveDamageModifier = unit.BaseDamageModifier * modificationNumber;
            }
        }
        else if (statModified == Stat.DamageReduction)
        {
            if (operatorSign == OperatorHandler.Add)
            {
                unit.EffectiveDamageReduction = unit.BaseDamageReduction + Convert.ToInt32(modificationNumber);
            }
            else if (operatorSign == OperatorHandler.Multiply)
            {
                unit.EffectiveDamageReduction = unit.BaseDamageReduction * Convert.ToInt32(modificationNumber);
            }
        }
    }

}
