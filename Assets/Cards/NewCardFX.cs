using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class newCardFX : CardEffect
{
	[SerializeField]
	private int testVariable1 = 0;
	public override void execute (CardEventCircumstances circumstances)
	{
		
	}
	public override string getCardEffectName()
	{
		return "";
	}
}