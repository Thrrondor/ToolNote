using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetdatabaseEditor : EditorWindow
{
    private enum Action
    {
        copy,
        Move,
        Open,
        Rename
    }

    private const string TEXTURE_PATH = "Assets/Cours02_GUI/spyduck.png";

    private Action m_Action;
    private Object m_Directory;
    private string m_Rename;
    private Texture m_Texture;

    private Object m_AssetObject;

    [MenuItem("Tools/AssetDataBase Window...")]
    private static void Init()
    {
        GetWindow<AssetdatabaseEditor>().Show();
    }

    private void OnGUI()
    {
        m_AssetObject = EditorGUILayout.ObjectField("Asset Object", m_AssetObject, typeof(Object), false);

        if(GUILayout.Button("show Asset Path"))
        {
            string assetPath = AssetDatabase.GetAssetPath(m_AssetObject);
            Debug.Log(assetPath + " | GUID => " + AssetDatabase.AssetPathToGUID(assetPath));
        }

        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUILayout.LabelField("Action", EditorStyles.centeredGreyMiniLabel);

        m_Action = (Action)EditorGUILayout.EnumPopup("Action", m_Action);

        ShowActionParameters();

        EditorGUI.BeginDisabledGroup(m_AssetObject == null);
        if(GUILayout.Button(m_Action.ToString() + " Asset", EditorStyles.toolbarButton))
        {
            PerformAction();
        }
        EditorGUI.EndDisabledGroup();
        
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUILayout.LabelField("Misc", EditorStyles.centeredGreyMiniLabel);
        if(GUILayout.Button("load Texture"))
        {
            m_Texture = AssetDatabase.LoadAssetAtPath<Texture>(TEXTURE_PATH);
        }

        if(m_Texture != null)
        {
            GUILayout.Label(m_Texture);
        }
        EditorGUILayout.EndVertical();
    }

    private void ShowActionParameters()
    {
        switch(m_Action)
        {
            case Action.copy:
            case Action.Move:
                EditorGUI.BeginChangeCheck();
                m_Directory = EditorGUILayout.ObjectField("Directory", m_Directory, typeof(Object), false);
                if (EditorGUI.EndChangeCheck() && m_Directory != null)
                {
                    string assetPath = AssetDatabase.GetAssetPath(m_Directory);
                    // Extension => Exemple: Asset/Object.prefab => .Prefab  si folder pas d'extention
                    string extension = System.IO.Path.GetExtension(assetPath);
                    if(!string.IsNullOrEmpty(extension))
                    {
                        m_Directory = null;
                        Debug.LogWarning("this isn't a Folder!");
                    }
                }
                break;
                case Action.Rename:
                    m_Rename = EditorGUILayout.TextField("Rename", m_Rename);
                    break;

        }
    }

    private void PerformAction()
    {
        string assetPath = AssetDatabase.GetAssetPath(m_AssetObject);
        bool actionSucces = false;

        switch (m_Action)
        {
            case Action.copy:
            case Action.Move:
                if(m_Directory != null)
                {
                    string directoryPath = AssetDatabase.GetAssetPath(m_Directory);
                    directoryPath += "/" + GetAssetFullName(assetPath);

                    if(m_Action == Action.copy)
                    {
                        actionSucces = AssetDatabase.CopyAsset(assetPath, directoryPath);
                    }
                    else
                    {
                        AssetDatabase.MoveAsset(assetPath, directoryPath);
                    }
                }

                break;
            case Action.Open:
                AssetDatabase.OpenAsset(m_AssetObject);
                break;
            case Action.Rename:
                if(!string.IsNullOrEmpty(m_Rename))
                {
                    actionSucces = string.IsNullOrEmpty(AssetDatabase.RenameAsset(assetPath, m_Rename));
                }
                break;
        }

        if(actionSucces)
        {
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    } 

    private string GetAssetFullName(string aAssetPath)
    {
        string[] splits = aAssetPath.Split('/');
        return splits[splits.Length-1];
    }

}
