using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ClearAttribute))]
public class ClearAttributeDrawer : PropertyDrawer
{
    private const float BUTTON_SIZE = 20F;

    public override void OnGUI(Rect aPosition, SerializedProperty aProperty, GUIContent aLabel)
    {
        aPosition.width -= BUTTON_SIZE;

        EditorGUI.PropertyField(aPosition, aProperty, aLabel);

        Rect buttonRect = aPosition;
        buttonRect.x += buttonRect.width;
        buttonRect.width = BUTTON_SIZE;

        GUI.color = Color.red;
        if(GUI.Button(buttonRect, "X"))
        {
            switch(aProperty.propertyType)
            {
                case SerializedPropertyType.Color:
                    aProperty.colorValue = Color.white;
                    break;
                case SerializedPropertyType.Integer:
                    aProperty.intValue = 0;
                    break;
                case SerializedPropertyType.String:
                    aProperty.stringValue = "";
                    break;
                case SerializedPropertyType.Vector3:
                    aProperty.vector3Value = Vector3.zero;
                    break;
                default:
                    Debug.LogError("Type not supported");
                    break;
                

            }
        }
        GUI.color = Color.white;
    }
}
