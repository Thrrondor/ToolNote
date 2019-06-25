using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AllAssetsPostProcessor : AssetPostprocessor
{
    private static void OnPostprocessAllAssets(string[] a_ImportedAssets, string[] a_DeletedAssets, string[] a_MovedAssets, string[] a_MovedFromAssetPaths)
    {
        foreach(string s in a_ImportedAssets)
        {
            Debug.Log("imported asset: " + s);
        }
        foreach(string s in a_DeletedAssets)
        {
            Debug.Log("Deleted asset: " + s);
        }

        for(int i = 0; i < a_MovedAssets.Length; i++)
        {
            Debug.Log("Moves asset: " + a_MovedAssets[i] + " From " + a_MovedFromAssetPaths[i]);
        }
    }
}
