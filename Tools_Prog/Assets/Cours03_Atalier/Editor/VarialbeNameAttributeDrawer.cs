using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(VariableNameAttribute))]
public class VarialbeNameAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect aPosition, SerializedProperty aProperty, GUIContent aLabel)
    {
        VariableNameAttribute variableName = (VariableNameAttribute)attribute;

        aLabel.text = variableName.m_VarName;

        EditorGUI.PropertyField(aPosition, aProperty, aLabel);
    }
}
