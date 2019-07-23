using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TagFinder : EditorWindow
{
    [MenuItem("Tools/Tag Finder...")]
    private static void Init()
    {
        GetWindow<TagFinder>().Show();
    }

    private enum MyType
    {
        Test,
        Pikachu,
        Malfunction
    }
    
    private string m_CurrentTag;
    private MyType m_MyType;

    private void OnGUI()
    {
        m_MyType = (MyType)EditorGUILayout.EnumPopup("My Type", m_MyType);

        string[] tags = UnityEditorInternal.InternalEditorUtility.tags;

        int index = ArrayUtility.IndexOf(tags, m_CurrentTag);
        index = EditorGUILayout.Popup("Filter Tag", index, tags);
        if(index != -1)
        {
            m_CurrentTag = tags[index];
        }

        if(GUILayout.Button("Select First"))
        {
            GameObject firstObj = GameObject.FindGameObjectWithTag(m_CurrentTag);

            Selection.activeGameObject = firstObj;
            
        }
        
        if(GUILayout.Button("Select All"))
        {
            GameObject[] allObj = GameObject.FindGameObjectsWithTag(m_CurrentTag);

            Selection.objects = allObj;
        }

    }
}
