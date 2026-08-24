using System;

public enum TriggerType
{
	Combat, //source, target, ability used
	OnRoundStart, //source
	OnChestOpen, //source
	OnEquip, //source
	OnLevelUp, //source
	OnCrit, //source
	OnKill //source
}
