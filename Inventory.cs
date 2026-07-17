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


    //public void NewInventoryModify(Stat stat, OperatorHandler operatorsign, )

    public void InventoryModify()
    {
        foreach(var item in Items)
        {
            foreach( var effect in item.listOfEffects)
            {
                MathHelper.ApplyEffect(effect.ModificationNumber, effect.OperatorSign, effect.StatModified, Unit);
            }
        }
    }
}
