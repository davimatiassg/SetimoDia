using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.ProjectWindowCallback;
using UnityEditor;
#endif

public abstract class CardFX : ScriptableObject
{
    public abstract void execute(CardEventCircumstances circumstances);


    
    #if UNITY_EDITOR
        public class newCardFX : CardFX
        {
            public override void execute(CardEventCircumstances circumstances)
            {
                return;
            }
        }

        public class CreateMyScriptAsset
        {
            [MenuItem("Assets/Create/Card/Create new Card Effect", priority = 2)]
            public static void CreateAsset()
            {
                ProjectWindowUtil.CreateAssetWithContent("NewCardFX.cs",
                "public class newCardFX : CardFX\n{\n\tpublic override void execute (CardEventCircumstances circumstances) { return; }\n}",
                EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D);
            }
        }



        
    #endif
}
