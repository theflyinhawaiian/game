using System;

public class Inventory
{
	public List<Item> Items {  get; set; }

    public Inventory()
    {
        Items = new List<Item>();
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
}
