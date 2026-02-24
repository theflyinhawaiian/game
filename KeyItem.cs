using System;


public enum KeyValue
{
	Safe,
	Gate
}



public class KeyItem : Item
{
	private KeyValue KeyValue;

	public KeyItem(KeyValue keyValue, string itemName)
	{
		KeyValue = keyValue;
		ItemName = itemName;
	}
}



