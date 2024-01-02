using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.ProjectWindowCallback;
using UnityEditor;

[CustomPropertyDrawer(typeof(CardFXContainer))]
public class CardFXDrawer : PropertyDrawer
{
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        Rect labelPosition = new Rect(position.x, position.y, position.width, position.height);
        
        position = EditorGUI.PrefixLabel(
            labelPosition, 
            EditorGUIUtility.GetControlID(FocusType.Passive), 
            new GUIContent(property.objectReferenceValue == null ? "Empty" :((CardFXContainer)property.objectReferenceValue).cardFX.getCardEffectName())
        );

        Rect propertyPosition = new Rect(position.x, position.y, position.width/2, position.height);
        Debug.Log(string.Format("Property Path {0}", property.propertyPath));
        SerializedProperty scriptProperty = property.FindPropertyRelative("teste");
        //Debug.Log(string.Format("scriptProperty Path {0}", scriptProperty.propertyPath));
        EditorGUI.PropertyField(propertyPosition, property);

        EditorGUI.EndProperty();
        //if(scriptProperty.objectReferenceValue == null) return;

        //DrawProperties();
    }
}