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

    public List<ItemEffect> GetActiveItemEffects(TriggerContext triggerContext)
    {
        var itemEffectList = new List<ItemEffect>();
        foreach (var item in Items)
        {
            foreach (var effect in item.ListOfEffects)
            {
                if (effect.TriggerCondition(triggerContext) && effect.TriggerType == triggerContext.TriggerType)
                {
                    itemEffectList.Add(effect);
                }
            }
        }
        return itemEffectList;
    }
}
