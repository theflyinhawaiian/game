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

    public void InventorySort()
    {
        foreach (var item in Items)
        {
            Console.WriteLine(item.Effects);
        }
    }
}
