using System;
using System.Collections;
using System.Collections.Generic;

public interface ICardFX
{
    public void execute(CardEventCircumstances circumstances);

    public string getCardEffectName();
}