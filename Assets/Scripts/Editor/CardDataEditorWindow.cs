using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CardDataEditorWindow : ExtendedEditorWindow
{
    public static void Open(Card cardData)
    {
        CardDataEditorWindow window = GetWindow<CardDataEditorWindow>("Card Data Editor");
        window.serializedObject = new SerializedObject(cardData);
    }

    private void OnGUI()
    {
        currentProperty = serializedObject.FindProperty("data");
        DrawProperties(currentProperty, true);
    }
}
