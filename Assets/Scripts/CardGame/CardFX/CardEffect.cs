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
            [MenuItem("Assets/Create/Card/CardEffect/Create new Card Effect", priority = 1)]
            public static void CreateAsset()
            {
                string content = "using System;\nusing System.Collections;\nusing System.Collections.Generic;\nusing UnityEngine;\n\n[Serializable]\npublic class newCardFX : CardEffect\n{\n\t[SerializeField]\n\tprivate int testVariable1 = 0;\n\tpublic override void execute (CardEventCircumstances circumstances)\n\t{\n\t\t\n\t}\n\tpublic override string getCardEffectName()\n\t{\n\t\treturn \"\";\n\t}\n}" ;
                ProjectWindowUtil.CreateAssetWithContent("NewCardFX.cs", content, EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D);
            }
        }
    #endif
}