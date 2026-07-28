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
            foreach(var effect in item.ListOfEffects)
            {
                var modNumberStr = effect.ModificationNumber.ToString();
                var operatorSignStr = effect.OperatorSign.ToString();
                var statModifiedStr = effect.StatModified.ToString();
                var activationCondition = effect.TriggerType.ToString();

                str = str + statModifiedStr + ": " + operatorSignStr + " " + modNumberStr + "; Activation Condition: " + activationCondition;
            }
            Console.WriteLine(str);
        }
    }


    //public void NewInventoryModify(Stat stat, OperatorHandler operatorsign, )

    public void InventoryModify()
    {
        foreach(var item in Items)
        {
            foreach( var effect in item.ListOfEffects)
            {   
               
                {
                    MathHelper.ApplyEffect(effect.ModificationNumber, effect.OperatorSign, effect.StatModified, Unit);
                }
            }
        }
    }

    public List<ItemEffect> GetActiveItemEffects(TriggerContext triggerContext)
    {
        var itemEffectList = new List<ItemEffect>();
        foreach (var item in Items)
        {
            foreach (var effect in item.ListOfEffects)
            {
                if (effect.TriggerCondition(triggerContext))
                {
                    itemEffectList.Add(effect);
                }
            }
        }
        return itemEffectList;
    }
}
