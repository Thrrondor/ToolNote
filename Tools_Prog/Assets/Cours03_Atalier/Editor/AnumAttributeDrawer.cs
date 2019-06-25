using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(EnumeAttribute))]
public class AnumAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect aPosition, SerializedProperty aProperty, GUIContent aLabel)
    {
        EnumeAttribute enumAtt = (EnumeAttribute)attribute;

        if(aProperty.propertyType == SerializedPropertyType.String)
        {
            aPosition = EditorGUI.PrefixLabel(aPosition, aLabel);

            int index = System.Array.IndexOf(enumAtt.m_Items, aProperty.stringValue);
            index =  EditorGUI.Popup(aPosition, index, enumAtt.m_Items);

            if(index >= 0)
            {
                aProperty.stringValue = enumAtt.m_Items[index];
            }
        }
        else
        {
            EditorGUI.LabelField(aPosition, aLabel.text,"use EnumAttribute with string!");
        }
    }
}
