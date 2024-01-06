using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sinner Card", menuName = "Card/Create new Sinner Card", order = 2)]
[Serializable]
public class SinnerCardData : CardData
{
    [Tooltip("The card's Suit")]
    [SerializeField]
    public SinnerCardSuit suit;
}