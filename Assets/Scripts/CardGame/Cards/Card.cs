using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Blank Card", menuName = "Card/Create new Card", order = 1)]
[Serializable]
public class Card : ScriptableObject
{
    [SerializeField] private CardData data = new CardData();
}