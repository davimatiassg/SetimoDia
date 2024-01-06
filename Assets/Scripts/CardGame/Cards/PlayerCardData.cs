using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Card", menuName = "Card/Create new Player Card", order = 1)]
[Serializable]
public class PlayerCardData : CardData
{
    [Tooltip("The card's Suit")]
    [SerializeField]
    public PlayerCardSuit suit;
}