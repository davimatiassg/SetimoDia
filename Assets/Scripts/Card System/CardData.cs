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
    [SerializeField] private Texture mainTexture { get {return mainTexture;} set {mainTexture = value;} }
    [SerializeField] private string description { get {return description;} set {description = value;} }
    [SerializeField] private int impact { get {return impact;} set {impact = value;} }

    private Dictionary<string, UnityAction<CardEventCircumstances>> effects;

    #region Editor
    #if UNITY_EDITOR

    [CustomEditor(typeof(CardData))]
    public class EffectMapEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            CardData data = (CardData)target;
            
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.EndHorizontal();

            foreach (var item in data.effects)
            {
                EditorGUILayout.Space();

            }
            EditorGUILayout.Space();

        }
    }

    #endif    
    #endregion
}
