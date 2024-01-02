using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.ProjectWindowCallback;
using UnityEditor;
#endif
/*
[Serializable]
public class CardFXContainer : ScriptableObject
{
    public CardFX? cardFX;

    public int teste;

    public MonoScript CurrentScript 
    {
        get 
        {
            return CurrentScript;
        }
        set
        {
            if(value == null) { return; }
            System.Type t = value.GetClass();
            if(t == null) { return; }
            if(typeof(CardFX).IsAssignableFrom(t)) 
            { 
                CurrentScript = value;
                cardFX = Activator.CreateInstance(t) as CardFX;
            }
        }
    }

    public CardFXContainer(CardFX value)
    {
        this.cardFX = value;
    }
    
}*/

[Serializable]
public abstract class CardEffect : ScriptableObject, ICardFX
{
    public abstract void execute(CardEventCircumstances circumstances);

    public abstract string getCardEffectName();
    
    public static List<Type> ListSimilarCardEffects()
    {
        List<Type> fxList = new List<Type>();
        //TODO - List all classes that inherit from this one
        return fxList;
    }

    #if UNITY_EDITOR
        public class CreateCardFXAsset
        {
            [MenuItem("Assets/Create/Card/Create new Card Effect", priority = 2)]
            public static void CreateAsset()
            {
                ProjectWindowUtil.CreateAssetWithContent("NewCardFX.cs",
                "public class newCardFX : CardEffect\n{\n\tpublic override void execute (CardEventCircumstances circumstances) { return; }\n}",
                EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D);
            }
        }
    #endif
}