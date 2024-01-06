using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Blank Card", menuName = "Card/Create new Card", order = 3)]
[Serializable]
public class CardData : ScriptableObject
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
    public int impact;

    [Tooltip("The card's main texture")]
    [SerializeField]
    public Texture2D mainTexture;

    [Tooltip("The card's background texture")]
    [SerializeField]
    public Texture2D backTexture;

    [Tooltip("The card's effects")]
    [SerializeField]
    public List<EffectPair> effectdDict;

    public CardData()
    {
        name = "";
        description = "";
        loreText = "";
        impact = 0;

        effectdDict = new List<EffectPair>();
    }


    #if UNITY_EDITOR

    [CustomEditor(typeof(CardData))]
    public class CardEditor : Editor
    {       
        public override Texture2D RenderStaticPreview(string assetPath, UnityEngine.Object[] subAssets, int width, int height)
        {
            CardData cardTarget = target as CardData;
            Texture2D newIcon = new Texture2D(width, height);
            if (cardTarget.mainTexture != null) {
                EditorUtility.CopySerialized(cardTarget.mainTexture, newIcon);
                return newIcon;
            }

            return base.RenderStaticPreview(assetPath, subAssets, width, height);
        }
    }
    #endif

}

[Serializable]
public class EffectPair
{
    [SerializeField]
    public string trigger;
    
    [SerializeField]
    public List<CardEffect> list = new List<CardEffect>();
}