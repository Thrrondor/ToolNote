using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DragAndDropExample : EditorWindow
{
    [MenuItem("Tools/DranAndDrop Example...")]
    private static void Init()
    {
        EditorWindow.GetWindow<DragAndDropExample>().Show();
    }

    private void OnGUI()
    {
        DrawDrag("Drag Example", 50f, OndragPerformed);

        if(GUILayout.Button("Create object"))
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            Undo.RegisterCreatedObjectUndo(obj, "Premitive Cration"); // tp
        }
    }

    private void OndragPerformed(Object[] aObjects)
    {
        for(int i = 0; i < aObjects.Length; i++)
        {
            Debug.Log(aObjects[i].name);
        }
    }

    private void DrawDrag(string aTitle, float aHeight = 20f, System.Action<Object[]> aOndragPerformed = null)
    {
        Rect dropArea = GUILayoutUtility.GetRect(0f, aHeight);
        GUI.Box(dropArea, aTitle);

        Event current = Event.current;
        Vector2 mousPos = current.mousePosition;

        if(!dropArea.Contains(mousPos))
        {
            return;
        }

        if(current.type == EventType.DragUpdated || current.type == EventType.DragPerform)
        {
            DragAndDrop.visualMode = DragAndDropVisualMode.Generic;

            if(current.type == EventType.DragPerform)
            {
                DragAndDrop.AcceptDrag();
                if(aOndragPerformed != null)
                {
                    aOndragPerformed(DragAndDrop.objectReferences);
                }
            }

            current.Use();
        }
    }
}
