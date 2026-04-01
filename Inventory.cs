using System;

public class Inventory
{

	public List<HealthPotion> HealthPotions { get; set; }
	public List<ArmorPotion> ArmorPotions { get; set; }

	public Weapon Weapon { get; set; }

	public Player Player { get; set; }

	public Inventory(Player player)
	{

		HealthPotions = new List<HealthPotion>();
		ArmorPotions = new List<ArmorPotion>();
		Player = player;
	}
	
	public void GainHealthPotion()
	{
		HealthPotions.Add(new HealthPotion(Player));
	}

	public void GainArmorPotion()
	{
		ArmorPotions.Add(new ArmorPotion(Player));
	}

	public int HealthPotionAmount()
	{
		var healthPotionAmount = HealthPotions.Count;
		return healthPotionAmount;
	}

	public int ArmorPotionAmount()
	{
		var armorPotionAmount = ArmorPotions.Count;
		return armorPotionAmount;
	}

	public void UseHealthPotion()
	{
        if (HealthPotionAmount() > 0)
		{
            HealthPotions[0].Use();
            HealthPotions.RemoveAt(0);
        }   
	}

	public void UseArmorPotion()
	{
		if (ArmorPotionAmount() > 0)
		{
			ArmorPotions[0].Use();
			ArmorPotions.RemoveAt(0);
		}
	}

	

	public void EquipWeapon(Weapon weapon)
	{
		Weapon = weapon;
		Player.CurrentAttackStat = Player.BaseAttackStat + Weapon.Damage;
	}


}
