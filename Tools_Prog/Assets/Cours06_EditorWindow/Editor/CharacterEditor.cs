using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Character))]
public class CharacterEditor : Editor
{
    private const string HEALTH = "m_Health";
    private const string ATTACK_TYPE = "m_AttackType";
    private const string VALUES = "m_Values";
    private const string ARRAY_SIZE = "Array.size";

    private string[] m_AttackType = new string[]
    {
        "Slash",
        "Blunt",
        "Cuddle"
    };

    private bool m_ListFoldout;
    private Character m_Character;

    private void OnEnable()
    {
        m_Character = (Character)target;
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI(); show all
        //DrawDefaultInspector(); // same shit as the first one 
        //DrawPropertiesExcluding(serializedObject, "m_Health"); show all but health

        if(GUILayout.Button("Progress Bar"))
        {
            int count = 1000;
            for(int i = 0; i < count; i++)
            {
                Debug.Log(i);
                float progress = i/(float)count;
                if(EditorUtility.DisplayCancelableProgressBar("Progress Bar Test", "Current pprogress: " + i.ToString() + "/" + count.ToString(), progress))
                {
                    break;
                }
            }

            EditorUtility.ClearProgressBar();
        }

        SerializedProperty healthprop = serializedObject.FindProperty(HEALTH);
        //facon 1 -   Affichage de propriété par défault
        EditorGUILayout.PropertyField(healthprop);

        //facon 2 - Affichage Custom, mais en gardant le toolyip
        healthprop.floatValue = EditorGUILayout.Slider(new GUIContent(healthprop.displayName, healthprop.tooltip), healthprop.floatValue, 0f, 1f);

        // on ne peut pas trouver une propriété non sérialisée (Example: Variable privée dans l'attribute SerializeField)
        //serializedObject.FindProperty("m_test").stringValue = "Salut";


        SerializedProperty attackTypeProp = serializedObject.FindProperty(ATTACK_TYPE);
        int index = ArrayUtility.IndexOf(m_AttackType, attackTypeProp.stringValue);
        index = EditorGUILayout.Popup(attackTypeProp.displayName, index, m_AttackType);
        if(index >= 0)
        {
            attackTypeProp.stringValue = m_AttackType [index];
        }

        SerializedProperty LisProp = serializedObject.FindProperty(VALUES);
        EditorGUILayout.PropertyField(LisProp, true);

        ShowCustomList(LisProp);

        serializedObject.ApplyModifiedProperties();

    }

    private void ShowCustomList(SerializedProperty aListprop)
    {
        m_ListFoldout = EditorGUILayout.Foldout(m_ListFoldout, "Values", true);

        if(m_ListFoldout)
        {
            EditorGUI.indentLevel ++;
            EditorGUILayout.PropertyField(aListprop.FindPropertyRelative(ARRAY_SIZE));

            for(int i =0; i < aListprop.arraySize; i++)
            {
                EditorGUILayout.BeginHorizontal(GUI.skin.box);


                EditorGUILayout.PropertyField(aListprop.GetArrayElementAtIndex(i), new GUIContent("Object " + i.ToString()));

                EditorGUI.BeginDisabledGroup(i == 0);
                GUI.color = Color.cyan;
                if(GUILayout.Button("▲", EditorStyles.toolbarButton, GUILayout.Width(20f)))
                {
                    aListprop.MoveArrayElement(i, i-1);
                }

                EditorGUI.EndDisabledGroup();

                EditorGUI.BeginDisabledGroup(i == aListprop.arraySize-1);
                GUI.color = Color.magenta;
                if(GUILayout.Button("♥", EditorStyles.toolbarButton, GUILayout.Width(20f)))
                {
                    aListprop.MoveArrayElement(i, i+1);
                }
                EditorGUI.EndDisabledGroup();

                GUI.color = Color.red;
                if(GUILayout.Button("X", EditorStyles.toolbarButton, GUILayout.Width(20f)))
                {
                    aListprop.DeleteArrayElementAtIndex(i);
                    i--;
                }
                GUI.color = Color.red;
                EditorGUILayout.EndHorizontal();
                GUI.color = Color.white;
                {
                    
                };

            }

            EditorGUI.indentLevel --;
        }
    }

}
