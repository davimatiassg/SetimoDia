using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardData   
{
    
    [Tooltip("The card's name")]
    [SerializeField]
    public string name;

    [TextArea]
    [Tooltip("Description of the card's effects.")]
    [SerializeField]
    public string description;
    [TextArea]
    [Tooltip("Description of the card's meaning storywise.")]
    [SerializeField]
    public string loreText;
    
    [SerializeField]
    public int Impact;

    [Tooltip("The card's main texture")]
    [SerializeField]
    public Texture mainTexture;

    [Tooltip("The card's background texture")]
    [SerializeField]
    public Texture backTexture;

    [Tooltip("The card's effects")]
    [SerializeField]
    public List<CardFXContainer> cardEffectList;
}

