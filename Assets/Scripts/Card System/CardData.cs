using System;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

#if UNITY_EDITOR

using UnityEditor;

#endif

[CreateAssetMenu(fileName = "Blank Card", menuName = "Card/Create new Card", order = 1)]
public class CardData : ScriptableObject
{

    private struct cardEffectInfo
    {
        public string trigger {get; set;}
        public List<CardFX> effects { get; set; }

        public cardEffectInfo(string t, List<CardFX> fx){ trigger = t; effects = fx;}
    }

    [SerializeField] private Texture mainTexture;
    [SerializeField] private Texture backTexture;
    [SerializeField] private string description;
    [SerializeField] private string cardName;
    [SerializeField] private int impact;

    private List<cardEffectInfo> effects;

    public CardData()
    {
        effects = new List<cardEffectInfo>();
    }

    #region Editor
    #if UNITY_EDITOR

    [CustomEditor(typeof(CardData))]
    public class EffectMapEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            CardData data = (CardData)target;

            EditorGUILayout.PrefixLabel("Card Name");
            data.cardName = (string)EditorGUILayout.TextField(data.cardName);

            EditorGUILayout.PrefixLabel("Card Description");
            data.description = (string)EditorGUILayout.TextArea(data.description, GUILayout.MinHeight(60));

            EditorGUILayout.PrefixLabel("Main Texture");
            data.mainTexture = (Texture)EditorGUILayout.ObjectField(data.mainTexture, typeof(Texture), false);

            EditorGUILayout.PrefixLabel("Background Texture");
            data.backTexture = (Texture)EditorGUILayout.ObjectField(data.backTexture, typeof(Texture), false);

            EditorGUILayout.PrefixLabel("Card Impact");
            data.impact = (int)EditorGUILayout.IntField(data.impact);

            bool CardFXGroup = false;
            int size = data.effects.Count;
            CardFXGroup = EditorGUILayout.BeginFoldoutHeaderGroup(CardFXGroup, "Card Effects");
            if(true)
            {
                
                size = (int)EditorGUILayout.IntField(size);

                while(size > data.effects.Count)
                {
                    data.effects.Add(new cardEffectInfo("", new List<CardFX>()));
                }

                while(size < data.effects.Count)
                {
                    data.effects.RemoveAt(data.effects.Count-1);
                }

                for(int i = 0; i < data.effects.Count; i++)
                {
                    cardEffectInfo item = data.effects[i];
                    EditorGUILayout.PrefixLabel(String.Format("Element {0}", i));
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel("Event");
                    item.trigger = (string)EditorGUILayout.TextArea(item.trigger, GUILayout.MinHeight(60));
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel("Effect");
                    EditorGUILayout.BeginVertical();
                    for(int j = 0; j < item.effects.Count; j++)
                    {
                        item.effects[j] = (CardFX)EditorGUILayout.ObjectField(item.effects[j], typeof(CardFX), false);
                    }
                    CardFX newFX = (CardFX)EditorGUILayout.ObjectField(null, typeof(CardFX), false);
                    if(newFX != null)
                    {
                        item.effects.Add(newFX);
                    }
                    EditorGUILayout.EndVertical();
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.Space();
                }

                //data.ApplyModifiedProperties();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

        }

    }

    #endif    
    #endregion
}
