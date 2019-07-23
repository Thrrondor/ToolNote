using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

public class EditorWindowExample : EditorWindow
{
    private bool m_GroupEnabled;
    private bool m_Toggle;
    private int m_IntValue;
    private string m_StringValue;
    private Color m_Color;
    private float m_FloatValue = 0f;

    private GameObject m_GameObject;

    private AnimBool m_ShowExtraFields;

    [MenuItem("Tools/Editor Example")]
    private static void Init()
    {
        GetWindow<EditorWindowExample>().Show(); // pour afficher la fenetre
    }

    private void OnEnable()
    {
        m_ShowExtraFields = new AnimBool(true);
        m_ShowExtraFields.valueChanged.AddListener(Repaint);
    }

    private void OnGUI()
    {
        GUI.color = Color.red;
        EditorGUILayout.BeginHorizontal(GUI.skin.box);
        GUI.color = Color.white;

        EditorGUILayout.LabelField("this is a label!", EditorStyles.boldLabel, GUILayout.Width(100f)); // ou utiliser le cal size
        m_FloatValue = EditorGUILayout .FloatField("float Value", m_FloatValue); 

        EditorGUILayout.EndHorizontal();

        m_GroupEnabled = EditorGUILayout.BeginToggleGroup("Toggle groupe", m_GroupEnabled);
        m_Toggle = EditorGUILayout.Toggle("toggle", m_Toggle);
        m_IntValue = EditorGUILayout.IntSlider("Slider", m_IntValue, 0, 100);
        EditorGUILayout.EndToggleGroup();


       
        EditorGUILayout.BeginVertical(GUI.skin.box);

        m_ShowExtraFields.target = EditorGUILayout.ToggleLeft("Show Extra Fields", m_ShowExtraFields.target);
        if(EditorGUILayout.BeginFadeGroup(m_ShowExtraFields.faded))
        {
            EditorGUI.indentLevel++;
            m_Color = EditorGUILayout.ColorField("Color", m_Color);
            
            EditorGUILayout.BeginHorizontal();
            m_StringValue = EditorGUILayout.TextField("String Valur", m_StringValue);
            if(GUILayout.Button("X", /*EditorStyles.toolbarButton,*/ GUILayout.Width(20f))) // style de bouton
            {
                m_StringValue = "";
                GUI.FocusControl("");
            }
            EditorGUILayout.EndHorizontal();
            
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndFadeGroup();
        EditorGUILayout.EndVertical();

        EditorGUI.BeginDisabledGroup(m_Toggle);

        EditorGUI.BeginChangeCheck();
        m_GameObject = (GameObject)EditorGUILayout.ObjectField("gameObjact", m_GameObject, typeof(GameObject), true);
        if(EditorGUI.EndChangeCheck())
        {
            Debug.Log("Game Object Aa Change");
        }

        EditorGUI.EndDisabledGroup();
    }
}
