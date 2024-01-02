using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
public class AssetHandler
{
    [OnOpenAsset()]
    public static bool OpenEditor(int instanceId, int line)
    {
        Card obj = EditorUtility.InstanceIDToObject(instanceId) as Card;
        if(obj == null) { return false; }
        CardDataEditorWindow.Open(obj);
        return true;
    }
}

[CustomEditor(typeof(Card))]
public class CardDataCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if(GUILayout.Button("Open Editor"))
        {
            CardDataEditorWindow.Open((Card)target);
        }
    }
}

[CustomEditor(typeof(CardFX))]
public class CardFXCustomEditor : Editor{
/*
    public override void OnInspectorGUI()
    {
        CardFX data = (CardFX)target;

        bool CardFXGroup = false;
        int size = data.effects.Count;
        CardFXGroup = EditorGUILayout.BeginFoldoutHeaderGroup(CardFXGroup, "Card Effects");
        size = (int)EditorGUILayout.IntField(size);
        
    }
    
    public CardFX? createCardField(CardFX defValue, out bool match)
    {
        
        MonoScript script = EditorGUILayout.ObjectField(defValue, typeof(MonoScript), false) as MonoScript;
        if(script == null){ match = false; return null; }
        System.Type t = script.GetClass();
        if(!typeof(CardFX).IsAssignableFrom(t)){ match = true; return null; }
        match = true;
        return (CardFX)Activator.CreateInstance(t);
    }
*/
}
