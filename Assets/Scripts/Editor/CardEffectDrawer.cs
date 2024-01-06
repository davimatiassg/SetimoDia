using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

[CustomPropertyDrawer(typeof(CardEffect))]
public class CardEffectDrawer : PropertyDrawer {

    private bool isCollapsed;
    
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float propHeight = EditorGUIUtility.singleLineHeight;
        if(property.objectReferenceValue == null) { return propHeight; }
        if(!property.isExpanded) { return 2*propHeight; }
        foreach(SerializedProperty p in property)
        {
            propHeight += EditorGUI.GetPropertyHeight(p);
        }
        return propHeight;
    } 
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        float propHeight = EditorGUIUtility.singleLineHeight;
        Rect nullRect = new Rect(position.x, position.y, position.width, propHeight);
        
        EditorGUI.BeginProperty(position, label, property);
        var script = EditorGUI.ObjectField( nullRect, label, property.objectReferenceValue, typeof(MonoScript), false ) as MonoScript;

        if(script != null){
            System.Type scriptClass = script.GetClass();
            if( (typeof(CardEffect)).IsAssignableFrom(scriptClass) )
            {
                if(property.objectReferenceValue == null) 
                {  
                    CardEffect cardfx = ScriptableObject.CreateInstance(scriptClass) as CardEffect;
                    AssetDatabase.CreateAsset(cardfx, string.Format("Assets/Cards/CardEffects/{0}.asset", scriptClass));
                    property.objectReferenceValue = cardfx;
                }
            }
        }
       
        if(property.objectReferenceValue != null) 
        {
            Rect foldoutRect = new Rect(position.x, position.y + propHeight, position.width, propHeight);
            property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded, label);
            if(property.isExpanded)
            {
                EditorGUI.indentLevel ++;
                string lastPropPath = "";
                SerializedProperty iterator = new SerializedObject(property.objectReferenceValue).GetIterator();
                iterator.NextVisible(true);
                iterator.NextVisible(true);
                EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);
                do
                {
                    Debug.Log("Hello?");
                    if(!string.IsNullOrEmpty(lastPropPath) && iterator.propertyPath.Contains(lastPropPath))
                    {
                        
                        continue; 
                    }
                    lastPropPath = iterator.propertyPath;
                    EditorGUILayout.PropertyField(iterator, true);
                } while (iterator.NextVisible(false));
                EditorGUI.indentLevel --;
            }
        }
        EditorGUI.EndProperty();
    }
/*
        property.IsExpanded = EditorGUI.Foldout()
        EditorGUILayout.EndProperty();
        VisualElement inspector = new();
        inspector.AddToClassList("panel");
        Debug.Log(string.Format("Nome da propriedade: {0}, tipo {1}, path: {2}", Property.name, Property.type, Property.propertyPath));

        ObjectField objf = new ObjectField();
        objf.objectType = typeof(CardEffect);
        objf.BindProperty(Property);
        inspector.Add(objf);

        if(Property.objectReferenceValue == null) { Debug.Log("lol kk"); return inspector; }

    public override VisualElement CreatePropertyGUI(SerializedProperty Property)
    {
        VisualElement inspector = new();
        inspector.AddToClassList("panel");
        Debug.Log(string.Format("Nome da propriedade: {0}, tipo {1}, path: {2}", Property.name, Property.type, Property.propertyPath));

        ObjectField objf = new ObjectField();
        objf.objectType = typeof(CardEffect);
        objf.BindProperty(Property);
        inspector.Add(objf);

        if(Property.objectReferenceValue == null) { Debug.Log("lol kk"); return inspector; }
        
        return base.CreatePropertyGUI(Property);
    }*/
}
