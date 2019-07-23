using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorPrefsExample : EditorWindow
{
    private enum PrefsKey
    {
        Bool,
        Int,
        Float,
        String

    }

    private const string EXAMPLE_KEY = "EditorPrefsExample.Key";

    private bool m_Bool;
    private int m_Int;
    private float m_Float;
    private string m_string;

    [MenuItem("Tools/Editor Pref...")]
    private static void Init()
    {
        GetWindow<EditorPrefsExample>().Show();
    }

    private void OnGUI()
    {
        // Delete toutes les préférence de l'éditeur. DANGEREUX
        //EditorPref.DeleteALL();

        int enumCount = System.Enum.GetNames(typeof(PrefsKey)).Length;
        for(int i = 0; i < enumCount; i++)
        {
            PrefsKey key = (PrefsKey)i;
            bool keyExists = EditorPrefs.HasKey(key.ToString());
            EditorGUI.BeginDisabledGroup(!keyExists);
            if(GUILayout.Button("Remove " + key.ToString()))
            {
                EditorPrefs.DeleteKey(key.ToString());
                GUI.FocusControl("");
            }
            EditorGUI.EndDisabledGroup();
        }

        m_Bool = EditorPrefs.GetBool(PrefsKey.Bool.ToString(), true);

        EditorGUI.BeginChangeCheck();
        m_Bool = EditorGUILayout.Toggle("bool", m_Bool);
        if(EditorGUI.EndChangeCheck())
        {
            EditorPrefs.SetBool(PrefsKey.Bool.ToString(), m_Bool);
        }

        m_Int = EditorPrefs.GetInt(PrefsKey.Int.ToString(), -1);
        EditorGUI.BeginChangeCheck();
        m_Int = EditorGUILayout.IntField("INT", m_Int);
        if(EditorGUI.EndChangeCheck())
        {
            EditorPrefs.SetInt(PrefsKey.Int.ToString(), m_Int);
        }

        m_Float = EditorPrefs.GetFloat(PrefsKey.Float.ToString(), 10f);
        EditorGUI.BeginChangeCheck();
        m_Float = EditorGUILayout.FloatField("Flaot", m_Float);
        if(EditorGUI.EndChangeCheck())
        {
            EditorPrefs.SetFloat(PrefsKey.Float.ToString(), m_Float);
        }

        m_string = EditorPrefs.GetString(PrefsKey.String.ToString(), "Default");
        EditorGUI.BeginChangeCheck();
        m_string = EditorGUILayout.TextField("String", m_string);
        if(EditorGUI.EndChangeCheck())
        {
            EditorPrefs.SetString(PrefsKey.String.ToString(), m_string);
        }
    }
}
